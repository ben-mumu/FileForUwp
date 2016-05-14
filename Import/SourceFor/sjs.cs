using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.SourceFor
{
    // 随机数类处理
    class sjs  
    {
        // 随机数的字符数组
        private static char[] constant =
        {
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j',
            'k','l','m','n','o','p','q','r','s','t',
            'u','v','w','x','y','z'
        };

        // 使用随机数生成文件名的方法  参数类型int对应的表示需要的字节长度
        public static string GetRandomNum(int Length)
        {
            // 创建容器？
            StringBuilder newRandom = new StringBuilder(36);
            // 随机数生成器
            Random rd = new Random();

            // 通过随机数来获取值取随机数字符数组中的值加入到容器中
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(36)]);
            }
            // 返回容器创建后变换成字符的变量
            return newRandom.ToString();
        }
    }
}
