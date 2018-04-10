using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPicFromPDF
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\Administrator\Desktop\S18\"; // 文件夹路径

            string[] pdfs = Directory.GetFiles(path, "*.pdf"); //获取文件夹下的所有pdf文件

            foreach (string pdf in pdfs)
            {
                
                int startIndex = pdf.LastIndexOf("\\") + 1;
                int length = pdf.Length - startIndex;
                string pdfsName = pdf.Substring(startIndex, length);


                FileInfo fileInfo = new System.IO.FileInfo(pdf);
                FileStream s = fileInfo.OpenRead();

                Document pdfDocument = new Document(fileInfo.FullName);
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile(fileInfo.FullName);
                int num = 1;
                foreach (PdfPageBase page1 in doc.Pages)  //pdf一个页面存放一个图片，
                {
                    if (page1.ExtractImages() != null)
                    {
                        FileStream request = new FileStream("C://" + pdfsName.Split('.')[0] + num + ".jpg", FileMode.Create); //生成图片的存放位置
                                
                              
                        int buffLength = 2048;
                        byte[] buff = new byte[buffLength];
                        int contentLen;
                        num++;
                        foreach (System.Drawing.Image image in page1.ExtractImages())
                        {
                            MemoryStream outputStream = new MemoryStream();
                            image.Save(outputStream, ImageFormat.Jpeg);
                            outputStream.Seek(0, SeekOrigin.Begin);
                            while ((contentLen = outputStream.Read(buff, 0, buff.Length)) > 0)
                            {
                                request.Write(buff, 0, contentLen);
                            }
                            request.Close();
                        }
                    }
                }
                doc.Close();
                

            }
            
        }
    }
}
