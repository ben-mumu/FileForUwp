using Import.SourceFor;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Import.XamlPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShowPage : Page
    {
        public ShowPage( )
        {
            // 绘制页面函数部分
            this.InitializeComponent();
            // 增加一个启动处理函数
            Loaded += SHPage_Loaded; 
        }

        private async void SHPage_Loaded( object sender, RoutedEventArgs e )
        {
            // 读取文件并展示在相关页面上
            WriteBlock.Text = await DoFile.readFileAsync(App.FileName);
        }

        private void SHPBack_Click( object sender, RoutedEventArgs e )
        {
            // 重置FileName对象
            App.FileName = null;
            // 跳转页面 并处理相关的页面绘制操作（重绘）
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void ClearFile_Click( object sender, RoutedEventArgs e )
        {
            // 获取并处理文件对象
            await DoFile.deleteFile(App.FileName);
            // 提示对话框的展示
            await new MessageDialog("删除成功！").ShowAsync();
            // 重置FileName对象
            App.FileName = null;
            // 跳转页面 并处理相关的页面绘制操作（重绘）
            this.Frame.Navigate(typeof(MainPage));
        }

        private void WriteBlock_Tapped( object sender, TappedRoutedEventArgs e )
        {
            Frame.Navigate(typeof(writePage));
        }
    }
}
