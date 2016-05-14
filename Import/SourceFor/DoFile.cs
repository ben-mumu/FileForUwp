using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Import.SourceFor
{

    //这个类用于处理存储和读取文件的需求部分
    public class DoFile
    {
        #region
        public static async Task<string> readForTitle(IStorageFolder localState, string fileName)
        {
            string text;
            try
            {
                // 根据传入的文件名来处理对应的文件
                IStorageFile storageFile = await localState.GetFileAsync(fileName);
                // 通过stream流来处理所选择打开的文件
                IRandomAccessStream accessStream = await storageFile.OpenReadAsync();
                // 通过Stream流来读取所打开的文件，注意这里的使用语法
                using (StreamReader streamReader = new StreamReader(accessStream.AsStreamForRead((int)accessStream.Size)))
                {
                    streamReader.ReadLine();
                    text = streamReader.ReadLine();
                }
            }
            catch(Exception e)
            {
                text = "Error !" + e.Message;
            }

            return text;
        }
        #endregion


        #region 异步读取文件操作，在这里使用了stream流来处理相关的数据 参数是string类型 这个参数表示传入的文件名，这个方法是static

        public static async Task<string> readFileAsync(string fileName)
        {
            string text;
            try
            {
                // 获取本地根目录所表示的文件夹
                IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
                
                // 根据传入的文件名来处理对应的文件
                IStorageFile storageFile = await applicationFolder.GetFileAsync(fileName);
                // 通过stream流来处理所选择打开的文件
                IRandomAccessStream accessStream = await storageFile.OpenReadAsync();
                // 通过Stream流来读取所打开的文件，注意这里的使用语法
                using (StreamReader streamReader = new StreamReader(accessStream.AsStreamForRead((int)accessStream.Size)))
                {
                    // 读取到末尾
                    text = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                text = "Error !" + e.Message;
            }

            return text;
        }
        #endregion

        #region 异步写文件操作 在这里也是使用Stream流处理,参数是两个string类型 分别处理的是需要打开的文件名和需要写入的数据这个方法是Static
        public static async Task writeFile(string fileName, string dataContent)
        {
            // 获取本地根目录所表示的文件夹
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            // 打开或创建对应的写入文件
            StorageFile file = await applicationFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            // 写入相关数据（dataContent）到对应的文件(file)中
            await FileIO.WriteTextAsync(file, dataContent);
        }
        #endregion

        #region 删除文件部分 参数类型string 表示要处理的文件 这个方法是static
        public static async Task deleteFile(string fileName)
        {
            // 获取本地根目录所表示的文件夹
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            // 根据传入的文件名来处理对应的文件
            IStorageFile storageFile = await applicationFolder.GetFileAsync(fileName);
            // 删除当前文件
            await storageFile.DeleteAsync();
        }
        #endregion


    }
}
