using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    internal class FileHelper
    {
        public static void OpenInExplorer(string fileName)
        {
            if (File.Exists(fileName))
            {
                Process.Start("explorer", "/select,\"" + fileName + "\"");
            }
        }
    }
}
