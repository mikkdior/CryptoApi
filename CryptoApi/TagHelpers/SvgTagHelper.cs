using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sass.TagHelpers
{
    public class SvgTagHelper : TagHelper
    {
        public string icon { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<use xlink:href=\"/images/svg-sprite.svg#{icon}\">");
        }
    }
}
