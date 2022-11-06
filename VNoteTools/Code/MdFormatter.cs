using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    internal class MdFormatter
    {
        public static void Format(string mdPath,string savePath)
        {
            //string mdPath = args[0];
            string[] lines = File.ReadAllLines(mdPath);
            string content = string.Empty;

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }
            //是想做符号统计，类似编译器那样，比如代码``` ```内的不加空格这样
            //还有插入空行这样的功能，但是没想好怎么实现，略
            //Stack<string> stack = new Stack<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == String.Empty) lines[i] = System.Environment.NewLine;
                else lines[i] = lines[i] + "  " + System.Environment.NewLine;
                //感觉一刀切会有bug
                content += lines[i];
            }
            //Console.WriteLine(content);
            File.WriteAllText(savePath, content);
        }
    }
}
