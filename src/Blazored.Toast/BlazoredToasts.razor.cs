using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazored.Toast
{
    public enum IconType { FontAwesome, Material };

    public partial class BlazoredToasts
    {
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public IconType? IconType { get; set; }
        [Parameter] public string PrimaryClass { get; set; }
        [Parameter] public string PrimaryIcon { get; set; }
        [Parameter] public string SecondaryClass { get; set; }
        [Parameter] public string SecondaryIcon { get; set; }
        [Parameter] public string SuccessClass { get; set; }
        [Parameter] public string SuccessIcon { get; set; }
        [Parameter] public string DangerClass { get; set; }
        [Parameter] public string DangerIcon { get; set; }
        [Parameter] public string WarningClass { get; set; }
        [Parameter] public string WarningIcon { get; set; }
        [Parameter] public string InfoClass { get; set; }
        [Parameter] public string InfoIcon { get; set; }
        [Parameter] public string LightClass { get; set; }
        [Parameter] public string LightIcon { get; set; }
        [Parameter] public string DarkClass { get; set; }
        [Parameter] public string DarkIcon { get; set; }

        [Parameter] public ToastPosition Position { get; set; } = ToastPosition.TopRight;
        [Parameter] public int Timeout { get; set; } = 5;
        [Parameter] public int MaxToastCount { get; set; } = int.MaxValue;
        [Parameter] public bool RemoveToastsOnNavigation { get; set; }
        [Parameter] public bool ShowProgressBar { get; set; }
        [Parameter] public RenderFragment CloseButtonContent { get; set; }
        [Parameter] public bool ShowCloseButton { get; set; } = true;

        private string PositionClass { get; set; } = string.Empty;

        internal List<ToastInstance> ToastList { get; set; } = new List<ToastInstance>();
        internal Queue<ToastInstance> ToastWaitingQueue { get; set; } = new Queue<ToastInstance>();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnShowComponent += ShowToast;
            ToastService.OnClearAll += ClearAll;
            ToastService.OnClearToasts += ClearToasts;
            ToastService.OnClearCustomToasts += ClearCustomToasts;


            if (RemoveToastsOnNavigation)
            {
                NavigationManager.LocationChanged += ClearToasts;
            }

            PositionClass = $"position-{Position.ToString().ToLower()}";

            if ((!string.IsNullOrEmpty(PrimaryIcon)
                 || !string.IsNullOrEmpty(SecondaryIcon)
                 || !string.IsNullOrEmpty(SuccessIcon)
                 || !string.IsNullOrEmpty(DangerIcon)
                 || !string.IsNullOrEmpty(WarningIcon)
                 || !string.IsNullOrEmpty(InfoIcon)
                 || !string.IsNullOrEmpty(LightIcon)
                 || !string.IsNullOrEmpty(DarkIcon)
                ) && IconType == null)
            {
                throw new ArgumentException("If an icon is specified then IconType is a required parameter.");
            }
        }



        public void RemoveToast(Guid toastId)
        {
            InvokeAsync(() =>
            {
                var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);
                ToastList.Remove(toastInstance);
                StateHasChanged();

                if (ToastWaitingQueue.Any())
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ClearToasts(object sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();

                if (ToastWaitingQueue.Any())
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private ToastSettings BuildToastSettings(ToastColor color, RenderFragment message, string heading, Action? onclick)
        {
            switch (color)
            {
                case ToastColor.Primary:
                    return new ToastSettings(ToastColor.Primary, string.IsNullOrWhiteSpace(heading) ? "Primary" : heading, message, IconType,
                        "blazored-toast-primary", PrimaryClass, PrimaryIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Secondary:
                    return new ToastSettings(ToastColor.Secondary, string.IsNullOrWhiteSpace(heading) ? "Secondary" : heading, message, IconType,
                        "blazored-toast-secondary", SecondaryClass, SecondaryIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Success:
                    return new ToastSettings(ToastColor.Success, string.IsNullOrWhiteSpace(heading) ? "Success" : heading, message, IconType,
                        "blazored-toast-success", SuccessClass, SuccessIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Danger:
                    return new ToastSettings(ToastColor.Danger, string.IsNullOrWhiteSpace(heading) ? "Danger" : heading, message, IconType,
                        "blazored-toast-danger", DangerClass, DangerIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Warning:
                    return new ToastSettings(ToastColor.Warning, string.IsNullOrWhiteSpace(heading) ? "Warning" : heading, message, IconType,
                        "blazored-toast-warning", WarningClass, WarningIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Info:
                    return new ToastSettings(ToastColor.Info, string.IsNullOrWhiteSpace(heading) ? "Info" : heading, message, IconType,
                        "blazored-toast-info", InfoClass, InfoIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Light:
                    return new ToastSettings(ToastColor.Light, string.IsNullOrWhiteSpace(heading) ? "Light" : heading, message, IconType,
                        "blazored-toast-light", LightClass, LightIcon, ShowProgressBar, MaxToastCount, onclick);

                case ToastColor.Dark:
                    return new ToastSettings(ToastColor.Dark, string.IsNullOrWhiteSpace(heading) ? "Dark" : heading, message, IconType,
                        "blazored-toast-dark", DarkClass, DarkIcon, ShowProgressBar, MaxToastCount, onclick);
            }

            throw new InvalidOperationException();
        }

        private void ShowToast(ToastColor color, RenderFragment message, string heading, Action? onClick)
        {
            InvokeAsync(() =>
            {
                var settings = BuildToastSettings(color, message, heading, onClick);
                var toast = new ToastInstance(settings);

                if (ToastList.Count < MaxToastCount)
                {
                    ToastList.Add(toast);

                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toast);
                }
            });

        }
        private void ShowEnqueuedToast()
        {
            InvokeAsync(() =>
            {
                var toast = ToastWaitingQueue.Dequeue();

                ToastList.Add(toast);

                StateHasChanged();
            });

        }

        private void ShowToast(Type contentComponent, ToastParameters parameters, ToastInstanceSettings settings)
        {
            InvokeAsync(() =>
            {
                var childContent = new RenderFragment(builder =>
                {
                    var i = 0;
                    builder.OpenComponent(i++, contentComponent);
                    if (parameters is object)
                    {
                        foreach (var parameter in parameters._parameters)
                        {
                            builder.AddAttribute(i++, parameter.Key, parameter.Value);
                        }
                    }
                    builder.CloseComponent();
                });

                if (settings == null)
                {
                    settings = new ToastInstanceSettings(Timeout, ShowProgressBar);
                }
                else
                {
                    settings = new ToastInstanceSettings(Timeout != settings.Timeout ? settings.Timeout : Timeout,
                        ShowProgressBar != settings.ShowProgressBar ? settings.ShowProgressBar : ShowProgressBar);
                }

                var toastInstance = new ToastInstance(childContent, settings);

                ToastList.Add(toastInstance);

                StateHasChanged();
            });
        }

        private void ClearAll()
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }

        private void ClearToasts(ToastColor ToastColor)
        {
            InvokeAsync(() =>
            {
                ToastList.RemoveAll(x => x.BlazoredToast == null && x.ToastSettings.ToastColor == ToastColor);
                StateHasChanged();
            });
        }

        private void ClearCustomToasts()
        {
            InvokeAsync(() =>
            {
                ToastList.RemoveAll(x => x.BlazoredToast is object);
                StateHasChanged();
            });
        }
    }
}
