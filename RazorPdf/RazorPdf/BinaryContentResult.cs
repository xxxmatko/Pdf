using System.IO;
using System.Web;
using System.Web.Mvc;

namespace RazorPdf
{
    /// <summary>
    /// An ActionResult used to send binary data to the browser.
    /// </summary>
    public class BinaryContentResult : ActionResult
    {
        #region [ Fields ]

        private readonly byte[] _contentBytes;
        private readonly string _contentType;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="contentBytes">Bytes representing the content.</param>
        /// <param name="contentType">Type of the content.</param>
        public BinaryContentResult(byte[] contentBytes, string contentType)
        {
            this._contentBytes = contentBytes;
            this._contentType = contentType;
        }

        #endregion


        #region [ Methods : Overrides ]

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = this._contentType;

            using (var stream = new MemoryStream(this._contentBytes))
            {
                stream.WriteTo(response.OutputStream);
            }
        }

        #endregion
    }
}