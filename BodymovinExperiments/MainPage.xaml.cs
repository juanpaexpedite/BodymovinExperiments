using BodymovinExperiments.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BodymovinExperiments
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeLottie();
        }

    private async void InitializeLottie()
    {
        var html = await BMManager.GetTemplate();

        var jsonuri = "ms-appx:///Data/lottie_logo_1.json";
        var data = await BMManager.ReadData(jsonuri);

        html = html.Replace("animationdata", data);

        WebView web = new WebView { DefaultBackgroundColor = Colors.Transparent };

        LayoutRoot.Children.Add(web);

        await Task.Delay(1000);

        web.NavigateToString(html);
    }

    }
}
