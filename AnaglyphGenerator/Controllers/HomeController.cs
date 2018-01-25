using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AnaglyphGenerator.Models;

namespace AnaglyphGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase leftPhoto = Request.Files["LeftPhoto"];
                HttpPostedFileBase rightPhoto = Request.Files["RightPhoto"];
                if (PhotosIsValid(leftPhoto, rightPhoto))
                {
                    string fileName = leftPhoto.FileName;
                    string fileContentType = leftPhoto.ContentType;
                    byte[] fileBytes = new byte[leftPhoto.ContentLength];
                    leftPhoto.InputStream.Read(fileBytes, 0, Convert.ToInt32(leftPhoto.ContentLength));
                    
                    var pathLeft = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);
                    leftPhoto.SaveAs(pathLeft);

                    fileName = rightPhoto.FileName;
                    fileBytes = new byte[rightPhoto.ContentLength];
                    rightPhoto.InputStream.Read(fileBytes, 0, Convert.ToInt32(rightPhoto.ContentLength));

                    var pathRight = Path.Combine(Server.MapPath("~/Content/uploads"), fileName);
                    rightPhoto.SaveAs(pathRight);

                    string selectedAlgorithm = Request.Form["SelectedAlgorithm"];

                    Bitmap newImage = new AnaglyphAlgorithmInvoker(selectedAlgorithm).Apply(new Bitmap(pathLeft), new Bitmap(pathRight));

                    Random rnd = new Random();
                    string outfilename = "output-" + selectedAlgorithm.Replace(" ", "_").ToLower() + "-" + rnd.Next(0, 2315412) + ".jpeg";
                    string outputFileName = Path.Combine(Server.MapPath("~/Content/outputs"), outfilename);
                    string htmlName = "/Content/outputs/" + outfilename;

                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            newImage.Save(memory, ImageFormat.Jpeg);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Close();
                        }
                    }

                    ViewBag.sa = selectedAlgorithm;
                    ViewBag.outputImage = htmlName;
                }
            }
            return View();
        }

        private static bool PhotosIsValid(HttpPostedFileBase leftPhoto, HttpPostedFileBase rightPhoto)
        {
            return (leftPhoto != null) 
                && (leftPhoto.ContentLength > 0) 
                && !string.IsNullOrEmpty(leftPhoto.FileName) 
                && (rightPhoto != null) 
                && (rightPhoto.ContentLength > 0) 
                && !string.IsNullOrEmpty(rightPhoto.FileName);
        }
    }
}