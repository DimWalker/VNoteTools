// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

#region 格式化
using PowerArgs;
using System.Diagnostics;
using VNoteTools.Code;

void FormatMd(CmdArgs cmdArgs)
{
    string mdPath = cmdArgs.InputMdPath;
    if (string.IsNullOrEmpty(mdPath))
    {
        Console.WriteLine("Please input InputMdPath:");
        mdPath = Console.ReadLine();
        if (!File.Exists(mdPath))
        {
            Console.WriteLine("InputMdPath file not exists.");
            return;
        }
    }

    FileInfo fileInfo = new FileInfo(mdPath);
    string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length) + "_Formatted.md";
    fileName = Path.Combine(fileInfo.DirectoryName, fileName);
    //if (args.Length > 1) fileName = args[1];
    MdFormatter.Format(mdPath, fileName);
    Console.WriteLine("New Md File Saved: " + fileName);
    FileHelper.OpenInExplorer(fileName);
}
void NugetMd(CmdArgs cmdArgs)
{
    string mdPath = cmdArgs.InputMdPath;
    string github_image_prefix_url = cmdArgs.github_image_prefix_url;
    if (string.IsNullOrEmpty(mdPath))
    {
        Console.WriteLine("Please input InputMdPath:");
        mdPath = Console.ReadLine();
        if (!File.Exists(mdPath))
        {
            Console.WriteLine("InputMdPath not exists.");
            return;
        }
    }
    if (string.IsNullOrEmpty(github_image_prefix_url))
    {
        Console.WriteLine("Please input github_image_prefix_url:\r\nEtc: https://raw.githubusercontent.com/{acc}/{repo}/{branch}/vx_images/");
        github_image_prefix_url = Console.ReadLine();
        if (string.IsNullOrEmpty(github_image_prefix_url))
        {
            Console.WriteLine("github_image_prefix_url can't be empty.");
            return;
        }
    }
    if (!github_image_prefix_url.EndsWith("/"))
        github_image_prefix_url += "/";

    FileInfo fileInfo = new FileInfo(mdPath);
    string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length) + "_Nuget.md";
    fileName = Path.Combine(fileInfo.DirectoryName, fileName);
    //if (args.Length > 1) fileName = args[1];
    NugetMdTools.Format(mdPath, fileName, github_image_prefix_url);
    Console.WriteLine("New Md File Saved: " + fileName);
    FileHelper.OpenInExplorer(fileName);
}

void CnBlogsMd(CmdArgs cmdArgs)
{
    CnblogsMdTools.Download();
    string mdPath = cmdArgs.InputMdPath;
    if (string.IsNullOrEmpty(mdPath))
    {
        Console.WriteLine("Please input InputMdPath:");
        mdPath = Console.ReadLine();
        if (!File.Exists(mdPath))
        {
            Console.WriteLine("InputMdPath not exists.");
            return;
        }
    }
    CnblogsMdTools.NewCmd(mdPath);
}
#endregion

#region 地平线
void HorizonFormate()
{
    string mdPath = @"D:/WorkArea/Private_Project/PaddleOCR-Arm/License_Plate_Recognition/ForHorizon_1.md";
    string imgsUrl = "![1601519224011.png](/api/v1/static/imgData/1667612476323.png)![21492117247978.png](/api/v1/static/imgData/1667612480669.png)![35681819232958.png](/api/v1/static/imgData/1667612485528.png)![39420417232494.png](/api/v1/static/imgData/1667612489105.png)![42371817250374.png](/api/v1/static/imgData/1667612519293.png)![85360719221507.png](/api/v1/static/imgData/1667612526470.png)![86543017249161.png](/api/v1/static/imgData/1667612529629.png)![90133512239483.png](/api/v1/static/imgData/1667612534483.png)![139005517230977.png](/api/v1/static/imgData/1667612537710.png)![154443312221057.png](/api/v1/static/imgData/1667612540060.png)![162392919226452.png](/api/v1/static/imgData/1667612549103.png)![162402419225843.png](/api/v1/static/imgData/1667612552779.png)![172443617244297.png](/api/v1/static/imgData/1667612555418.png)![250140217236740.png](/api/v1/static/imgData/1667612557728.png)![260372717226721.png](/api/v1/static/imgData/1667612562242.png)![279172317245480.png](/api/v1/static/imgData/1667612569099.png)![427314312247516.png](/api/v1/static/imgData/1667612577348.png)![445835016240185.png](/api/v1/static/imgData/1667612582043.png)![558355417237843.png](/api/v1/static/imgData/1667612585934.png)![589973712227350.png](/api/v1/static/imgData/1667612587962.png)";
    string savePath = @"D:/WorkArea/Private_Project/PaddleOCR-Arm/License_Plate_Recognition/ForHorizon_2.md";
    HorizonMdTools.MatchImages(mdPath, imgsUrl, savePath);
}

#endregion




var parsed = Args.Parse<CmdArgs>(args);
if (string.IsNullOrEmpty(parsed.Method))
{
    Console.WriteLine("Please Input Method, Suppor Keyword: FormatMd, NugetMd, CnBlogsMd.");
    parsed.Method = Console.ReadLine();
}

#region 测试

/*
 * -InputMdPath "F:\Project_Private\Wlkr.Core.SDK\Wlkr.Core.Logger\README.md" -github_image_prefix_url "https://raw.githubusercontent.com/DimWalker/Wlkr.Core.Logger/master/vx_images/"
 */

switch (parsed.Method)
{
    case "FormatMd":
        FormatMd(parsed);
        break;
    case "NugetMd":
        NugetMd(parsed);
        break;
    case "CnBlogsMd":
        CnBlogsMd(parsed);
        break;

    default:
        Console.WriteLine("Not Support Method.");
        break;
}
//HorizonFormate();

#endregion