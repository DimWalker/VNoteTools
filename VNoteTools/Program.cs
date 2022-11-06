// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

#region 格式化
using System.Diagnostics;
using VNoteTools.Code;

void FormatMd()
{
    if (args.Length == 0)
    {
        Console.WriteLine("Please input the md path.");
        return;
    }
    string mdPath = args[0];
    string fileName = "test.md";
    if (args.Length > 1) fileName = args[1];
    MdFormatter.Format(mdPath, fileName);
    FileHelper.OpenInExplorer(fileName);
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


#region 测试
FormatMd();
//HorizonFormate();

#endregion