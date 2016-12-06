using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
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

            // Render the view xml to a string
            var html = ActionResultToString(View(model));

            return View(model);
        }

        #endregion


        #region [ Methods : Private ]

        /// <summary>
        /// Converts action result into a string.
        /// </summary>
        /// <param name="result">The action result to be rendered.</param>
        private string ActionResultToString(ActionResult result)
        {
            // Create memory writer
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                // Create fake http context and response for view rendering
                var response = new HttpResponse(writer);
                var context = new HttpContext(System.Web.HttpContext.Current.Request, response);

                // Create fake controller context
                var controllerContext = new ControllerContext(
                    new HttpContextWrapper(context),
                    this.ControllerContext.RouteData,
                    this.ControllerContext.Controller);
                var oldContext = System.Web.HttpContext.Current;

                System.Web.HttpContext.Current = context;

                // Render the view
                result.ExecuteResult(controllerContext);

                // Restore data
                System.Web.HttpContext.Current = oldContext;

                // Flush memory and return output
                writer.Flush();
            }

            return sb.ToString();
        }

        #endregion
    }
}