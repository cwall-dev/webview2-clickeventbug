using Microsoft.Web.WebView2.Core;
using System.Globalization;

namespace WebView2ClickEventIssueMAUI
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      webView.Source = "https://rossmann-ds.soviaretail.de/indexd.html";
    }

    protected async override void OnHandlerChanged()
    {
      base.OnHandlerChanged();
#if WINDOWS
      var envOptions = new CoreWebView2EnvironmentOptions
      {
        Language = CultureInfo.CurrentUICulture.Name
      };
      var env = await CoreWebView2Environment.CreateWithOptionsAsync(null, "/test", envOptions);
      await (webView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).EnsureCoreWebView2Async(env);
      var settings = (webView.Handler.PlatformView as Microsoft.UI.Xaml.Controls.WebView2).CoreWebView2.Settings;
      settings.AreDevToolsEnabled = true;
      settings.AreHostObjectsAllowed = true;
      settings.AreDefaultScriptDialogsEnabled = true;
      settings.IsScriptEnabled = true;
      settings.IsWebMessageEnabled = true;
      settings.IsZoomControlEnabled = false;
      settings.IsPinchZoomEnabled = false;
      settings.IsGeneralAutofillEnabled = false;
      settings.AreDefaultContextMenusEnabled = true;

#endif
    }

  }
}
