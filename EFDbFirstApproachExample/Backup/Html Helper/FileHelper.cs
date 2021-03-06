using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EFDbFirstApproachExample.Html_Helper
{
    public static class FileHelper
    {
        public static MvcHtmlString File(this HtmlHelper htmlHelper,string CssClass)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("id", "Image");
            tag.MergeAttribute("name", "Photo");
            tag.MergeAttribute("Class", CssClass);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));

        }
    }
}