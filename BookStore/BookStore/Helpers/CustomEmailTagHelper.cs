using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string Email { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", Email);
            output.Attributes.Add("id", "my-email-id");
            output.Content.SetContent("my-email");
        }
    }
}
