using O2S.Components.PDFRender4NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPngFromPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取pdf中图片的页数
            string path = @"C:\Users\Administrator\Desktop\S18\"; // 文件夹路径

            string[] pdfs = Directory.GetFiles(path, "*.pdf"); //获取文件夹下的所有pdf文件

            string outPath = "C:\\Image\\"; // 图片生成路径

            foreach (string page in pdfs)
            {
                PDFFile pdfFile = PDFFile.Open(page);
                string pdfsName = Path.GetFileNameWithoutExtension(page); //获取pdf文件名（无后缀）

                PDFTranImgHelp.ConvertPDF2Image(page, outPath, pdfsName, 1, pdfFile.PageCount, ImageFormat.Jpeg, Definition.Five);
            }
            PDFTranImgHelp.ConvertJepgToJpg(outPath);


        }
    }
    public enum Definition
    {
        One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
    }

    public class PDFTranImgHelp
    {
        /// <summary>
        /// 将PDF文档转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageOutputPath">图片输出路径</param>
        /// <param name="imageName">生成图片的名字</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        public static void ConvertPDF2Image(string pdfInputPath, string imageOutputPath,
            string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
        {
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);
            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }
            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }
            // start to convert each page
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                pageImage.Save(imageOutputPath + imageName + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                pageImage.Dispose();
            }
            pdfFile.Dispose();
        }

        /// <summary>
        /// 将Jpeg图片转化为Jpg格式 add by cfl 2018年4月28日
        /// </summary>
        /// <param name="dirPath"></param>
        public static void ConvertJepgToJpg(string dirPath)
        {
            string[] imgDirs = Directory.GetFiles(dirPath);

            foreach (var imgDir in imgDirs)
            {

                FileInfo file = new FileInfo(imgDir);
                file.MoveTo(Path.ChangeExtension(imgDir, ".jpg")); // 把jepg 转换成jpg图片
            }

        }
    }
}
