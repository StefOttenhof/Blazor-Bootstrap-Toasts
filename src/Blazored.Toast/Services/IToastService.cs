using System;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services
{
    public interface IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        event Action<ToastColor, RenderFragment, string, Action> OnShow;

        /// <summary>
        /// A event that will be invoked to clear all toasts
        /// </summary>
        event Action OnClearAll;

        /// <summary>
        /// A event that will be invoked to clear toast of specified color
        /// </summary>
        event Action<ToastColor> OnClearToasts;

        /// <summary>
        /// A event that will be invoked to clear custom toast components
        /// </summary>
        event Action OnClearCustomToasts;

        /// <summary>
        /// A event that will be invoked when showing a toast with a custom comonent
        /// </summary>
        event Action<Type, ToastParameters, ToastInstanceSettings> OnShowComponent;

        /// <summary>
        /// Shows a toast with primary color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowPrimary(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with primary color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowPrimary(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with secondary color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowSecondary(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with secondary color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowSecondary(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with success color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowSuccess(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with success color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowSuccess(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with danger color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowDanger(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with danger color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowDanger(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with warning color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowWarning(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with warning color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowWarning(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with info color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowInfo(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with info color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowInfo(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with light color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowLight(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with light color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowLight(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with dark color
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowDark(string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast with dark color
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowDark(RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="color">Toast color to display</param>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowToast(ToastColor color, string message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="color">Toast color to display</param>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        void ShowToast(ToastColor color, RenderFragment message, string heading = "", Action? onClick = null);

        /// <summary>
        /// Shows a toast containing the specified <typeparamref name="TComponent"/>.
        /// </summary>
        void ShowToast<TComponent>() where TComponent : IComponent;

        /// <summary>
        /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
        //void ShowToast<TComponent>(ToastParameters parameters) where TComponent : IComponent;

        /// <summary>
        /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">Key/Settings to pass to component being displayed</param>
        //void ShowToast<TComponent>(ToastInstanceSettings settings) where TComponent : IComponent;

        /// <summary>
        /// Shows a toast containing a <typeparamref name="TComponent"/> with the specified <paramref name="settings" and /> and <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed</param>
        /// <param name="settings">Key/Settings to pass to component being displayed</param>
        //void ShowToast<TComponent>(ToastParameters parameters, ToastInstanceSettings settings) where TComponent : IComponent;

        /// <summary>
        /// Removes all toasts
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Removes all toasts with a specified <paramref name="ToastColor"/>.
        /// </summary>
        void ClearToasts(ToastColor ToastColor);

        /// <summary>
        /// Removes all toasts with toast color primary
        /// </summary>
        void ClearPrimaryToasts();

        /// <summary>
        /// Removes all toasts with toast color secondary
        /// </summary>
        void ClearSecondaryToasts();

        /// <summary>
        /// Removes all toasts with toast color success
        /// </summary>
        void ClearSuccessToasts();

        /// <summary>
        /// Removes all toasts with toast color danger
        /// </summary>
        void ClearDangerToasts();

        /// <summary>
        /// Removes all toasts with toast color warning
        /// </summary>
        void ClearWarningToasts();

        /// <summary>
        /// Removes all toasts with toast color info
        /// </summary>
        void ClearInfoToasts();

        /// <summary>
        /// Removes all toasts with toast color light
        /// </summary>
        void ClearLightToasts();

        /// <summary>
        /// Removes all toasts with toast color dark
        /// </summary>
        void ClearDarkToasts();

        /// <summary>
        /// Removes all custom toast components
        /// </summary>
        void ClearCustomToasts();

    }
}
