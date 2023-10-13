using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    internal class MdFormatter
    {
        public static void Format(string mdPath, string savePath)
        {
            //string mdPath = args[0];
            string[] lines = File.ReadAllLines(mdPath);
            StringBuilder content = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }
            //想做符号统计，类似编译器那样，
            //比如代码``` ```内的不加空格这样
            //还有段落插入空行这样的功能，
            //但是没想好怎么实现
            //Stack<string> stack = new Stack<string>();

            bool codeblock = false;
            for (int i = 0; i < lines.Length; i++)
            {
                //代码块标签
                if (lines[i].StartsWith("```"))
                {
                    codeblock = !codeblock;
                    lines[i] = lines[i] + System.Environment.NewLine;
                }
                //代码块
                else if (codeblock) lines[i] = lines[i] + System.Environment.NewLine;
                //空行
                else if (lines[i] == String.Empty || codeblock) lines[i] = System.Environment.NewLine;
                //一般文本换行（标签#为标题，实际不同加俩空格换行，一般文本才需要 ）
                else lines[i] = lines[i] + "  " + System.Environment.NewLine;
                content.Append(lines[i]);
            }
            //Console.WriteLine(content);
            File.WriteAllText(savePath, content.ToString());
        }
    }
}
