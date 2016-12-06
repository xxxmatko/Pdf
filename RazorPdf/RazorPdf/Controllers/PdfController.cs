using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

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

            return ViewPdf(model);
        }

        #endregion


        #region [ Methods : Private ]

        /// <summary>
        /// Creates and returns BinaryContentActionResult.
        /// </summary>
        /// <param name="contentBytes">Bytes representing the content.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>Return action result.</returns>
        private ActionResult BinaryContent(byte[] contentBytes, string contentType)
        {
            return new BinaryContentResult(contentBytes, contentType);
        }


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


        /// <summary>
        /// Returns a PDF action result.
        /// </summary>
        /// <param name="model">The model to send to the view.</param>
        /// <param name="fileName">Name of the file to download.</param>
        private ActionResult ViewPdf(object model, string fileName = null)
        {
            // Render the view html to a string
            var html = ActionResultToString(View(model));

            // Create the iTextSharp document
            using (var doc = new Document())
            using (var stream = new MemoryStream())
            using (var writer = PdfWriter.GetInstance(doc, stream))
            {
                writer.CloseStream = false;

                // Set page dimensions
                doc.SetPageSize(PageSize.A4);
                doc.SetMargins(35.4f, 35.4f, 45.4f, 45.4f);
                doc.Open();

                // Convert string to stream
                byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                using (var htmlStream = new MemoryStream(htmlBytes))
                {
                    // Parse html to pdf using DefaultFontProvider
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer
                        , doc
                        , htmlStream
                        , null
                        , Encoding.UTF8
                        , new DefaultFontProvider() as IFontProvider);
                }

                // Close document
                doc.Close();

                // Create the result buffer
                var buffer = new byte[stream.Position];
                stream.Position = 0;
                stream.Read(buffer, 0, buffer.Length);

                // Return pdf file reponse
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    return File(buffer, "application/pdf", fileName);
                }

                return BinaryContent(buffer, "application/pdf");
            }
        }

        #endregion
    }
}