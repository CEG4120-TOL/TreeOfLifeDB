using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace TreeOfLifeDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Backup()
        {
            createBackup();
            ViewBag.Message = "Create a backup of your database.";
            return View();
        }

        public void createBackup()
        {
            try
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
                string fileName = "TOLDB.mdf";
                string sourcePath = Request.PhysicalApplicationPath + "/App_Data";
                string targetPath = @"C:\Users\Public\TOLDB_Backup";

                // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, date + "_Backup_" + fileName);

                // To copy a folder's contents to a new location: 
                // Create a new target folder, if necessary. 
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (System.IO.IOException e)
            {
                System.Console.WriteLine("Error making backup:" + e);
            }
        }
    }
}