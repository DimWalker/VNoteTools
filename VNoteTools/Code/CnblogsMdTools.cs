using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    internal class CnblogsMdTools
    {
        public static string programPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dotnet-cnblogs.v1.4.2.win-x86\dotnet-cnblog.exe");

        public static void NewCmd(string mdPath)
        {


            // 定义要运行的命令行程序和参数

            string arguments = $@" proc -f ""{mdPath}""";

            // 创建一个 ProcessStartInfo 对象来配置进程启动信息
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = programPath,
                Arguments = arguments,
                UseShellExecute = true,
                CreateNoWindow = true,
                WorkingDirectory = System.IO.Path.GetDirectoryName(programPath)
            };

            // 创建一个进程对象并启动它
            Process process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
        }

        public static void Download()
        {
            if (File.Exists(CnblogsMdTools.programPath))
                return;

            string zipName = "dotnet-cnblogs.v1.4.2.win-x86.zip";
            if (!File.Exists(zipName))
            {
                string url = "https://github.com/stulzq/dotnet-cnblogs-tool/releases/download/v1.4.2/" + zipName;

                Console.WriteLine("Downloading: " + url);
                var client = new RestClient(url);
                RestRequest request = new RestRequest();
                byte[] fileBytes = client.DownloadData(request);

                if (fileBytes != null && fileBytes.Length <= 0)
                {
                    Console.WriteLine("文件下载失败");
                    return;
                }

                File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, zipName), fileBytes);
                Console.WriteLine("文件下载完成");
            }
            if (File.Exists(zipName))
            {
                ZipFile.ExtractToDirectory(zipName, "dotnet-cnblogs.v1.4.2.win-x86");
                Console.WriteLine("ZIP文件解压完成");
            }
        }
    }
}
