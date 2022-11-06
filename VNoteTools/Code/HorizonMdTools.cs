using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    /// <summary>
    /// 地平线开发者论坛
    /// </summary>
    internal class HorizonMdTools
    {
        /// <summary>
        /// 先Vnote编写Markdown
        /// 再将图片逐一上传到地平线的Md编辑器（只上传，不要写任何文字内容）
        /// 得到如下imgsUrl的图片地址
        /// 然后和Vnote的匹配
        /// </summary>
        public static void MatchImages(string mdPath, string imgsUrl, string savePath)
        {           
            string[] imgs = imgsUrl.Split('!');
            string[] lines = File.ReadAllLines(mdPath);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string img in imgs)
            {
                if (string.IsNullOrEmpty(img))
                    continue;

                string vnote = img.Substring(1, img.IndexOf(']') - 1);
                int st = img.IndexOf('(') + 1;
                int len = img.IndexOf(')') - st;
                string horizon = img.Substring(st, len);
                dict.Add(vnote, horizon);
            }

            for (int i = 0; i < lines.Length; i++)
            {
                //Vnote内的图片路径一般为![](vx_images/{vnote}.png)  
                //但是ForHorizon_1.md已被我改为 ![](/api/v1/static/imgData/{vnote}.png) 
                string prePath = "vx_images/";//"/api/v1/static/imgData/";
                if (lines[i].StartsWith("!["))
                {
                    foreach (string key in dict.Keys)
                    {
                        Console.WriteLine(key + " -> " + dict[key]);
                        if (lines[i].Contains(prePath + key))
                        {
                            lines[i] = lines[i].Replace(prePath + key, dict[key]);
                        }
                    }
                }
            }
            File.WriteAllLines(savePath, lines);
        }
    }
}
