using System.Web.Mvc;

namespace AnaglyphGenerator.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            var builder = new TagBuilder("img");

            builder.GenerateId(id);
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alternateText);

            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}