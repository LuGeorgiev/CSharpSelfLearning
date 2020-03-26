using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.Inftastructure.CustomTagHelpers
{
    public class FormTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory factory;

        public FormTagHelper(IUrlHelperFactory factory)
        {
            this.factory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext  ViewContextData { get; set; }

        public string  Controller { get; set; }

        public string  Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = factory.GetUrlHelper(ViewContextData);

            //output.Attributes.SetAttribute("action", urlHelper.Action(
            //    Action ??
            //        ViewContextData.RouteData.Values["action"].ToString(),
            //    Controller ??
            //        ViewContextData.RouteData.Values["controller"].ToString()));
        }
    }
}
