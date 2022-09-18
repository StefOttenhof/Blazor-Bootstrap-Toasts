# Blazor-Bootstrap-Toasts
This is a JavaScript free Bootstrap toast implementation for [Blazor](https://blazor.net) and Razor Components applications. It supports icons that are either specified by class name (such as fontawesome) or by a specified element (Material Design). This project is based on Blazored.Toast.



![Nuget](https://img.shields.io/nuget/v/blazor-bootstrap-toasts.svg)

![Screenshot of component in action](screenshot.png)

## Getting Setup
You can install the package via the NuGet package manager just search for *Blazor-Bootstrap-Toasts*. You can also install via powershell using the following command.

```powershell
Install-Package Blazor-Bootstrap-Toasts
```

Or via the dotnet CLI.

```bash
dotnet add package Blazor-Bootstrap-Toasts
```

### 1. Register Services
You will need to register the Blazored Toast service in your application

#### Blazor Server
Add the following line to your applications `Startup.ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredToast();
}
```

#### Blazor WebAssembly
Add the following line to your applications `Program.Main` method.

```csharp
builder.Services.AddBlazoredToast();
```

### 2. Add Imports
Add the following to your *_Imports.razor*

```csharp
@using Blazored.Toast
@using Blazored.Toast.Services
```

### 3. Register and Configure Toasts Component
Add the `<BlazoredToasts />` tag into your applications *MainLayout.razor*.

Toasts are configured using parameters on the `<BlazoredToasts />` component. There are the following colors with both *Class* and *Icon* parameters to add custom classes and icons.

| Toast Color | Class          | Icon          |
|-------------|----------------|---------------|
| Primary     | PrimaryClass   | PrimaryIcon   |
| Secondary   | SecondaryClass | SecondaryIcon |
| Success     | SuccessClass   | SuccessIcon   |
| Danger      | DangerClass    | DangerIcon    |
| Warning     | WarningClass   | WarningIcon   |
| Info        | InfoClass      | InfoIcon      |
| Light       | LightClass     | LightIcon     |
| Dark        | DarkClass      | DarkIcon      |

The following parameters will apply to all toast colors:
| Parameter       | Options                                                                                                                                                      | Default                |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------|
| IconType        | IconType.FontAwesome, IconType.Material                                                                                                                     | `IconType.FontAwesome`   |
| Position        | ToastPosition.TopLeft, ToastPosition.TopCenter, ToastPosition.TopRight, ToastPosition.BottomLeft, ToastPosition.BottomCenter, ToastPosition.BottomRight | `ToastPosition.TopRight` |
| Timeout         | Int                                                                                                                                                          | `5`                      |
| ShowProgressBar | Bool                                                                                                                                                         | `False `                 |
| ShowCloseButton | Bool                                                                                                                                                         | `True `                  |
| MaxToastCount   | Int                                                                                                                                                          | `int.MaxValue`         |

By default, you don't need to provide any settings everything will just work. But if you want to add icons to toasts or override the default styling then you can use the options above to do that. 

For example, to add an icon from Font Awesome to all success toasts you can do the following.

```html
<BlazoredToasts SuccessIcon="fa fa-thumbs-up"/>
```

Setting the position also requires a reference to `Blazored.Toast.Configuration`, for example:

```html
@using Blazored.Toast.Configuration

<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10"
                IconType="IconType.FontAwesome"
                SuccessClass="success-toast-override"
                SuccessIcon="fa fa-thumbs-up"
                ErrorIcon="fa fa-bug" />
```
The example above is from the [client side samples](https://github.com/Blazored/Toast/tree/master/samples).

```html
<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10"
                IconType="IconType.Material"
                ErrorIcon="error_outline"
                InfoIcon="school"
                SuccessIcon="done_outline"
                WarningIcon="warning" />
```
The example above is from the [server side samples](https://github.com/Blazored/Toast/tree/master/samples) and demonstrates the use of Material Design icons.


If you want to have your own custom close button:
```html
<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10">
    <CloseButtonContent>
        <div>
            <span>&times;</span>
        </div>
    </CloseButtonContent>
</BlazoredToasts>
```

### 4. Add reference to style sheet(s)
Add the following line to the `head` tag of your `_Host.cshtml` (Blazor Server app) or `index.html` (Blazor WebAssembly).
The blazored-toast.css includes the open-iconic-bootstrap.min.css.

We ship both minified and unminified CSS.

###### If css is not loaded properly, copy from ![css/Styles]([https://myoctocat.com/assets/images/base-octocat.svg](https://github.com/StefOttenhof/Blazor-Bootstrap-Toasts/blob/main/src/Blazored.Toast/Styles/blazored-toast.css)), create a new file in your css folder and add the styling. Then reference that css file in _Host.cshtml or index.html. This is a bug and this will be fixed in the future !

For minifed use:

```
<link href="_content/Blazored.Toast/blazored-toast.min.css" rel="stylesheet" />
```

For unminifed use:
```
<link href="_content/Blazored.Toast/blazored-toast.css" rel="stylesheet" />
```

Presumably, if you want to use the Material Icons your project already includes some form of the icons. If not see [Material Design Icons](https://dev.materialdesignicons.com/getting-started/webfont) for the available alternatives.

## Usage
In order to show a toast you have to inject the `IToastService` into the component or service you want to trigger a toast. You can then call one of the following methods depending on what kind of toast you want to display, passing in a message and an optional heading.

- `ShowPrimary`
- `ShowSecondary`
- `ShowSuccess`
- `ShowDanger`
- `ShowWarning`
- `ShowInfo`
- `ShowLight`
- `ShowDark`


```html
@page "/toastdemo"
@inject IToastService toastService

<h1>Toast Demo</h1>

To show a toast just click one of the buttons below.

<button class="btn btn-info" @onclick="@(() => toastService.ShowInfo("I'm an INFO message"))">Info Toast</button>
<button class="btn btn-success" @onclick="@(() => toastService.ShowSuccess("I'm a SUCCESS message with a custom title", "Congratulations!"))">Success Toast</button>
<button class="btn btn-warning" @onclick="@(() => toastService.ShowWarning("I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" @onclick="@(() => toastService.ShowDanger("I'm an ERROR message"))">Error Toast</button>
```

### Show Progress Bar
You can display a progress bar which gives a visual indicator of the time remaining before the toast will disappear. In order to show the progress bar set the `ShowProgressBar` parameter to true.

```html
<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10"
                ShowProgressBar="true" />
```

### Remove Toasts When Navigating
If you wish to clear any visible toasts when the user navigates to a new page you can enable the `RemoveToastsOnNavigation` parameter. Setting this to true will remove any visible toasts whenever the `LocationChanged` event fires.

### Limiting number of toasts shown at once
If you want to limit the number of toasts displayed at any given time, you can set the `MaxToastCount` parameter. For example, if the value is set to *3* only three toast instances will be displayed. Any additional toasts that are triggered will be held in a queue and will be displayed as older toasts time out.

## FAQ
### The toasts are not showing
- Check the `z-index` of your other `DOM Elements`, make sure that the `.blazored-toast-container` has a higher `z-index` than the other components.
### I upgraded my version of Blazored Toasts and I have errors in my razor file where I declare the BlazoredToasts component.
- The parameter IconType is a mandatory parameter. An exception will be thrown if any icon is specified.
- Check the icon parameter names if you have upgraded from a version prior to 2.0.10. Previous to this version the icons supported were specified by class and the parameters were of the form SuccessIconClass. With the addition of Material icon support the parameter form is now simply SuccessIcon.

