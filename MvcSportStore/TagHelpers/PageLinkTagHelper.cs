using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcSportStore.ViewModels;

namespace MvcSportStore.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("page-link", Attributes ="paging-info")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PagingInfo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(GetPagingInfoLinks());
        }
        private TagBuilder GetPagingInfoLinks()
        {
            //Maken gebruik van het PagingInfo object
            TagBuilder ul = new TagBuilder("ul");
            ul.Attributes["class"] = "pagination";
            bool active = false;
            string? category = PagingInfo.Category;
            for (int page = 1; page <= PagingInfo.TotalPages; page++)
            {
                active=(page== PagingInfo.CurrentPage);
                ul.InnerHtml.AppendHtml(GetPagingInfoLink(page, category, active));
            }
            return ul;
        }
        private TagBuilder GetPagingInfoLink(int page, string? category, bool active)
        {
            
            TagBuilder li = new TagBuilder("li");
            li.Attributes["class"] = "page-item";
            li.InnerHtml.AppendHtml(GetPagingInfoHyperlink(page, category, active));
            return li;
        }
        private TagBuilder GetPagingInfoHyperlink(int page, string? category, bool active)
        {
            string linkActive = "btn border border-primary";
            string link = "btn border border-secondary";
            TagBuilder a = new TagBuilder("a");
            a.Attributes["class"] = (active) ? linkActive : link;
            if (category == null)
            {
                a.Attributes["href"] = $"/Home/Index/{page}";
            }
            else
            {
                a.Attributes["href"] = $"/Home/Index/{page}?category={category}";
            }
            a.Attributes["title"] = $"Click to go to {page}";
            a.InnerHtml.Append($"{page}");
            return a;
        }
    }
}
