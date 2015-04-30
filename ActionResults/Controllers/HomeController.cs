using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using ActionResults.Models;
using System.IO;
using System.Xml;

namespace ActionResults.Controllers
{
    public class HomeController : Controller
    {
        Character character = new Character();
        
        public ActionResult Index()
        {
            return View(character);
        }

      
        public ActionResult Plain()
        {   
            return Content(character.ToString());
        }

        public ActionResult XML()
        {
            var serializer = new DataContractSerializer(typeof(Character));
            string xmlString;
            using (var sw = new StringWriter())
            {
                using (var writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented; // indent the Xml so it's human readable
                    serializer.WriteObject(writer, character);
                    writer.Flush();
                    xmlString = sw.ToString();
                    return this.Content(xmlString, "text/xml");
                }
            }
            
        }

        public ActionResult JSON()
        {
            return Json(character, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Error()
        {
            return HttpNotFound();
        }

        public ActionResult Download()
        {
            var imgPath = Server.MapPath("~/Images/sims4background.jpg");
            Response.AddHeader("Content-Disposition", "attachment;filename=Sims4Background.png");
            Response.WriteFile(imgPath);
            Response.End();
            return null;
        }

    }
}