using System;
using System.Web.Hosting;

using iTextSharp.text;

namespace RazorPdf
{
    /// <summary>
    /// Default font provider for iTextSharp.
    /// </summary>
    public sealed class DefaultFontProvider : FontFactoryImp
    {
        #region [ Fields ]

        private readonly string _fontName;

        #endregion


        #region [ Constructors ]

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fontName">Default font name.</param>
        public DefaultFontProvider(string fontName = "Roboto")
        {
            this._fontName = fontName;

            Register(HostingEnvironment.MapPath("~/Fonts/Roboto-Regular.ttf"), "Roboto");
        }

        #endregion


        #region [ Methods : Overrides ]

        /// <summary>
        /// Constructs a Font-object.
        /// </summary>
        /// <param name="fontname">the name of the font</param>
        /// <param name="encoding">the encoding of the font</param>
        /// <param name="embedded">true if the font is to be embedded in the PDF</param>
        /// <param name="size">the size of this font</param>
        /// <param name="style">the style of this font</param>
        /// <param name="color">the BaseColor of this font</param>
        /// <param name="cached">true if the font comes from the cache or is added to the cache if new, false if the font is always created new</param>
        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {
            if (string.IsNullOrWhiteSpace(fontname) || (Math.Abs(size) < 0))
            {
                fontname = this._fontName;
            }

            return base.GetFont(fontname, "cp1250", embedded, size, style, color, cached);
        }

        #endregion
    }
}