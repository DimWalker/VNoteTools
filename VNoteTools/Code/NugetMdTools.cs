using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    internal class NugetMdTools
    {
        /// <summary>
        /// 将 "vx_images/" 替换为 "https://raw.githubusercontent.com/{acc}/{repo}/{branch}/vx_images/"
        /// </summary>
        /// <param name="mdPath"></param>
        /// <param name="savePath"></param>
        /// <param name="github_image_prefix_url">example: https://raw.githubusercontent.com/DimWalker/Wlkr.Core.Logger/master/vx_images/</param>
        public static void Format(string mdPath, string savePath, string github_image_prefix_url)
        {
            if (string.IsNullOrEmpty(github_image_prefix_url))
                throw new ArgumentNullException(nameof(github_image_prefix_url));
            string[] lines = File.ReadAllLines(mdPath);
            StringBuilder content = new StringBuilder();
            Regex regex = new Regex(@"!\[(.*?)\](\(.*\)?)");

            bool codeblock = false;
            for (int i = 0; i < lines.Length; i++)
            {
                var m = regex.Match(lines[i]);
                if (m.Success)
                {
                    var imgPath = m.Groups[2];
                    if (imgPath.Value.StartsWith("(vx_images/"))
                        lines[i] = lines[i].Replace("vx_images/", github_image_prefix_url);
                }
                content.AppendLine(lines[i]);
            }
            File.WriteAllText(savePath, content.ToString());
        }
    }
}
