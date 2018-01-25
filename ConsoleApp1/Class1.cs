using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public class Class1
    {
        public void GetData() {
            string fp = @"D:\new.pdf";
            FileInfo fi = new FileInfo(fp);

            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ClearHeaders();
            System.Web.HttpContext.Current.Response.ClearContent();
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=test.pdf");
            System.Web.HttpContext.Current.Response.AddHeader("Content-Length", fi.Length.ToString());
            System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.TransmitFile(fi.FullName);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
