using Import.SourceFor;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Import.XamlPage
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class writePage : Page
    {
        public writePage( )
        {
            this.InitializeComponent();
            Loaded += WPage_Loaded;
            
        }

        private async void WPage_Loaded( object sender, RoutedEventArgs e )
        {
            // 每个文件开头需要添加的时间内容
            if (App.FileName == null)
                WriteBox.Text = DateTime.Now.ToString("MM-dd   hh:mm") + "\n";
            else
            {
                WriteBox.Text = await DoFile.readFileAsync(App.FileName);
            }
        }

        private async void SaveFile_Click( object sender, RoutedEventArgs e )
        {
            if (App.FileName == null)
            {
                // 这一部分还要修改  需要判断是新写入还是旧写入数据
                // 建立两个string参数保存编写框的写入数据和文件名
                string dataText = WriteBox.Text;
                string fileNameForString = sjs.GetRandomNum(4) + ".txt";
                // 写入操作
                await DoFile.writeFile(fileNameForString, dataText);
                // 保存对应的文件名
                App.FileName = fileNameForString;
                // 跳转到展示页面
                this.Frame.Navigate(typeof(ShowPage));
            }
            else
            {
                string dataText = WriteBox.Text;
                await DoFile.writeFile(App.FileName, dataText);
                this.Frame.Navigate(typeof(ShowPage));
            }
            
        }

        private void WPBack_Click( object sender, RoutedEventArgs e )
        {
            // 回退按键的处理部分
            Frame.Navigate(typeof(MainPage));
        }
    }
}
