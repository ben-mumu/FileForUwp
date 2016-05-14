using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Import.XamlPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SourchPage : Page
    {
        public SourchPage( )
        {
            this.InitializeComponent();
        }

        private void SPBack_Click( object sender, RoutedEventArgs e )
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
