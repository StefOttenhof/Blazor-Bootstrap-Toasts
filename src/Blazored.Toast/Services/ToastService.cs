using System;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services
{
    public class ToastService : IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<ToastColor, RenderFragment, string, Action> OnShow;

        /// <summary>
        /// A event that will be invoked when clearing all toasts
        /// </summary>
        public event Action OnClearAll;

        /// <summary>
        /// A event that will be invoked when showing a toast with a custom comonent
        /// </summary>
        public event Action<Type, ToastParameters, ToastInstanceSettings> OnShowComponent;

        /// <summary>
        /// A event that will be invoked when clearing toasts
        /// </summary>
        public event Action<ToastColor> OnClearToasts;

        /// <summary>
        /// A event that will be invoked when clearing custom toast components
        /// </summary>
        public event Action OnClearCustomToasts;

        /// <summary>
        /// Shows a toast with primary color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowPrimary(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Primary, message, heading, onClick);

        /// <summary>
        /// Shows a toast with primary color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowPrimary(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Primary, message, heading, onClick);

        /// <summary>
        /// Shows a toast with secondary color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSecondary(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Secondary, message, heading, onClick);

        /// <summary>
        /// Shows a toast with secondary color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSecondary(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Secondary, message, heading, onClick);

        /// <summary>
        /// Shows a toast with success color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Success, message, heading, onClick);

        /// <summary>
        /// Shows a toast with success color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Success, message, heading, onClick);

        /// <summary>
        /// Shows a toast with danger color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowDanger(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Danger, message, heading, onClick);

        /// <summary>
        /// Shows a toast with danger color 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowDanger(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Danger, message, heading, onClick);

        /// <summary>
        /// Shows a toast with warning color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Warning, message, heading, onClick);

        /// <summary>
        /// Shows a toast with warning color 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Warning, message, heading, onClick);

        /// <summary>
        /// Shows a toast with info color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Info, message, heading, onClick);

        /// <summary>
        /// Shows a toast with info color 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Info, message, heading, onClick);

        /// <summary>
        /// Shows a toast with light color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowLight(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Light, message, heading, onClick);

        /// <summary>
        /// Shows a toast with light color 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowLight(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Light, message, heading, onClick);

        /// <summary>
        /// Shows a toast with dark color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowDark(string message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Dark, message, heading, onClick);

        /// <summary>
        /// Shows a toast with dark color 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowDark(RenderFragment message, string heading = "", Action? onClick = null)
            => ShowToast(ToastColor.Dark, message, heading, onClick);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="color">Toast color to display</param>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(ToastColor color, string message, string heading = "", Action? onClick = null)
            => ShowToast(color, builder => builder.AddContent(0, message), heading, onClick);


        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="color">Toast color to display</param>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(ToastColor color, RenderFragment message, string heading = "", Action? onClick = null)
            => OnShow?.Invoke(color, message, heading, onClick);

        /// <summary>
        /// Shows the toast with the component type
        /// </summary>
        public void ShowToast<TComponent>() where TComponent : IComponent
            => ShowToast(typeof(TComponent), new ToastParameters(), null);

        /// <summary>
        /// Shows the toast with the component type />,
        /// passing the specified <paramref name="parameters"/> 
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="settings">Settings to configure the toast component.</param>
        public void ShowToast(Type contentComponent, ToastParameters parameters, ToastInstanceSettings settings)
        {
            if (!typeof(IComponent).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
            }
            OnShowComponent?.Invoke(contentComponent, parameters, settings);
        }

        /// <summary>
        /// Shows the toast with the component type />,
        /// passing the specified <paramref name="parameters"/> 
        /// </summary>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        //public void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent
        //    => ShowToast(typeof(TComponent), parameters, null);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="settings">Toast settings to be used</param>
        //public void ShowToast<TComponent>(ToastInstanceSettings settings) where TComponent : IComponent
        //    => ShowToast(typeof(TComponent), null, settings);

        /// <summary>
        /// Shows a toast using the supplied parameter and settings
        /// </summary>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="settings">Toast settings to be used</param>
        //public void ShowToast<TComponent>(ToastParameters parameters, ToastInstanceSettings settings) where TComponent : IComponent
        //    => ShowToast(typeof(TComponent), parameters, settings);

        /// <summary>
        /// Removes all toasts
        /// </summary>
        public void ClearAll()
            => OnClearAll?.Invoke();

        /// <summary>
        /// Removes all toasts with a specified <paramref name="ToastColor"/>.
        /// </summary>
        public void ClearToasts(ToastColor ToastColor)
            => OnClearToasts?.Invoke(ToastColor);

        /// <summary>
        /// Removes all toasts with toast color primary
        /// </summary>
        public void ClearPrimaryToasts()
            => OnClearToasts?.Invoke(ToastColor.Primary);

        /// <summary>
        /// Removes all toasts with toast color info
        /// </summary>
        public void ClearSecondaryToasts()
            => OnClearToasts?.Invoke(ToastColor.Secondary);

        /// <summary>
        /// Removes all toasts with toast color success
        /// </summary>
        public void ClearSuccessToasts()
            => OnClearToasts?.Invoke(ToastColor.Success);

        /// <summary>
        /// Removes all toasts with toast color danger
        /// </summary>
        public void ClearDangerToasts()
            => OnClearToasts?.Invoke(ToastColor.Danger);

        /// <summary>
        /// Removes all toasts with toast color warning
        /// </summary>
        public void ClearWarningToasts()
            => OnClearToasts?.Invoke(ToastColor.Warning);

        /// <summary>
        /// Removes all toasts with toast color danger
        /// </summary>
        public void ClearInfoToasts()
            => OnClearToasts?.Invoke(ToastColor.Info);

        /// <summary>
        /// Removes all toasts with toast color light
        /// </summary>
        public void ClearLightToasts()
            => OnClearToasts?.Invoke(ToastColor.Light);

        /// <summary>
        /// Removes all toasts with toast color dark
        /// </summary>
        public void ClearDarkToasts()
            => OnClearToasts?.Invoke(ToastColor.Dark);

        /// <summary>
        /// Removes all custom component toasts
        /// </summary>
        public void ClearCustomToasts()
            => OnClearCustomToasts?.Invoke();
    }
}
