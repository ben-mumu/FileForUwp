using Import.SourceFor;
using Import.XamlPage;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Import
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Show> myShow = new List<Show>();


        public MainPage( )
        {
            this.InitializeComponent();


            Loaded += MainPage_Loaded;

        }

        private async void MainPage_Loaded( object sender, RoutedEventArgs e )
        {
            string text;
            // 获取应用的数据根目录
            IStorageFolder localState = ApplicationData.Current.LocalFolder;
            // 设置一个只读列表
            IReadOnlyList<StorageFile> fileList = await localState.GetFilesAsync();

            // 开启遍历文件从应用的数据根目录中
            foreach (StorageFile nextFile in fileList)
            {
                text = await DoFile.readForTitle(localState, nextFile.Name); 
                
                Show item = new Show { Title = text, Time = nextFile.DateCreated.ToString("hh:mm  MM-dd  ") + nextFile.DateCreated.DayOfWeek.ToString(), fileNameFor = nextFile.Name };
                // 建立一个Show对象存放相关数据
                //Show item = new Show { Title = nextFile.Name,
                //   Time = nextFile.DateCreated.ToString("hh:mm  MM-dd  ") +  nextFile.DateCreated.DayOfWeek.ToString()};
                // 添加到相关的banding对象中
                myShow.Add(item);
            }
            // banding对象的链接
            MainView.ItemsSource = myShow;

            #region 旧错代码记录
            //StorageFolder thisFolder = Win//KnownFolders.AppCaptures.

            /*
            IStorageFolder localState = ApplicationData.Current.LocalFolder;
            //StorageFolder localState = Windows.ApplicationModel.Package.Current.InstalledLocation;
            DirectoryInfo Try = new DirectoryInfo(localState.ToString());
            foreach (FileInfo nextFile in Try.GetFiles())
            {
                Show item = new Show {Title = nextFile.ToString(), Time = "11:11"};
                myShow.Add(item);
            }
            MainView.ItemsSource = myShow;*/
            #endregion
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {

            this.Frame.Navigate(typeof(writePage));
        }

        private void SearchButton_Click( object sender, RoutedEventArgs e )
        {
            this.Frame.Navigate(typeof(SourchPage));
        }

        private void MainView_ItemClick( object sender, ItemClickEventArgs e )
        {
            // 这个方法处理了ListView中的Item项的点击事件，
            // 注意的是在使用这个属性时需要将IsItemClickEnable属性设置为True
            // 定义一个变量来处理接收点击的Item项目
            var Try = e.ClickedItem as Show;
            // 设置文件名为点击的Item项的Title属性
            App.FileName = Try.fileNameFor.ToString();
            // 跳转页面到ShowPage页面
            this.Frame.Navigate(typeof(ShowPage));
        }

    }
}
