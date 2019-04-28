using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WGCore.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        [HttpGet]
        public FileStreamResult GetStream()
        {
            using (Stream fs = System.IO.File.OpenWrite(@"D:\MyCode\MyGit\ADO.NetCore\Core1\WGCore\WGCore\wwwroot\images\1.png"))
            using (Bitmap bmp = new Bitmap(50, 50))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.DrawString("Hello", new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, new PointF(0, 0));
                bmp.Save(fs, System.DrawingCore.Imaging.ImageFormat.Jpeg);
                return File(fs, "image/jpeg");
            }
        }
    }
}
