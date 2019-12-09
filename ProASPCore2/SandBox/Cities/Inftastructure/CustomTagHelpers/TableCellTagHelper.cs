using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Inftastructure.CustomTagHelpers
{
    [HtmlTargetElement("td", Attributes ="wrap")]
    public class TableCellTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b><i>");

            output.PostContent.SetHtmlContent("</i></b>");
        }
    }
}
