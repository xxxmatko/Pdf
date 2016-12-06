using System.Collections.Generic;
using System.Web.Mvc;

using RazorPdf.Models;

namespace RazorPdf.Controllers
{
    /// <summary>
    /// Pdf controller.
    /// </summary>
    public class PdfController : System.Web.Mvc.Controller
    {
        #region [ Actions ]

        /// <summary>
        /// GET: /Home/
        /// </summary>
        public ActionResult Index()
        {
            var model = new List<Employee>()
                        {
                            new Employee()
                            {
                                Id = 1, Name = "Dominic Galloway", 
                                Email = "justo@malesuadaIntegerid.edu"
                            },
                            new Employee()
                            {
                                Id = 2, Name = "Austin Hopper", 
                                Email = "pede.et.risus@vehicula.ca"
                            },
                            new Employee()
                            {
                                Id = 3, Name = "Amery Carroll", 
                                Email = "tincidunt.pede@non.co.uk"
                            },
                            new Employee()
                            {
                                Id = 4, Name = "Owen Holder", 
                                Email = "eu@dapibusgravidaAliquam.co.uk"
                            },
                            new Employee()
                            {
                                Id = 5, Name = "Jarrod Oneil", 
                                Email = "sodales@congueIn.net"
                            },
                            new Employee()
                            {
                                Id = 6, Name = "Tarik Newman", 
                                Email = "metus@necluctusfelis.ca"
                            },
                            new Employee()
                            {
                                Id = 7, Name = "Xenos Odonnell", 
                                Email = "magna.a@sapienmolestieorci.org"
                            },
                            new Employee()
                            {
                                Id = 8, Name = "Carlos David", 
                                Email = "Praesent.interdum.ligula@anteiaculisnec.co.uk"
                            },
                            new Employee()
                            {
                                Id = 9, Name = "Walter Gamble", 
                                Email = "rhoncus.id.mollis@adipiscingfringillaporttitor.org"
                            }
                        };
            
            return View(model);
        }

        #endregion
    }
}