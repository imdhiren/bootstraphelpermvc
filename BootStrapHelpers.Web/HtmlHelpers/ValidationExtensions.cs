using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class ValidationExtensions
    {
        public static MvcHtmlString ValidationAlert(this HtmlHelper htmlHelper)
        {
            return ValidationAlert(htmlHelper, false, null, null);
        }

        public static MvcHtmlString ValidationAlert(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            return ValidationAlert(htmlHelper, excludePropertyErrors, null, null);
        }

        public static MvcHtmlString ValidationAlert(this HtmlHelper htmlHelper, string header, string message)
        {
            return ValidationAlert(htmlHelper, false, header, message);
        }

        public static MvcHtmlString ValidationAlert(this HtmlHelper htmlHelper, bool excludePropertyErrors, string header, string message)
        {
            // if no errors, skip
            if (htmlHelper.ViewData.ModelState.IsValid)
                return null;

            TagBuilder alert = new TagBuilder("div");
            alert.AddCssClass("alert alert-block alert-error");

            StringBuilder divInnerHtml = new StringBuilder();

            // if we have a header value, wrap it in <strong>
            if (!string.IsNullOrWhiteSpace(header))
            {
                TagBuilder strong = new TagBuilder("strong");
                strong.SetInnerText(header);

                divInnerHtml.AppendLine(strong.ToString());
            }

            // if no value for message, search the model state for errors
            if (string.IsNullOrWhiteSpace(message))
            {
                TagBuilder list = new TagBuilder("ul");
                list.AddCssClass("unstyled");
                StringBuilder listInnerHtml = new StringBuilder();

                // if we are exluding property errors, only retrieve the error for the empty string property
                var states = excludePropertyErrors ? new ModelState[] { htmlHelper.ViewData.ModelState[string.Empty] } : htmlHelper.ViewData.ModelState.Values;

                foreach (var state in states)
                {
                    foreach (var error in state.Errors)
                    {
                        var li = new TagBuilder("li");
                        li.SetInnerText(error.ErrorMessage);
                        listInnerHtml.AppendLine(li.ToString());
                    }
                }

                list.InnerHtml = listInnerHtml.ToString();
                divInnerHtml.AppendLine(list.ToString());
            }
            else
                divInnerHtml.AppendLine(htmlHelper.Encode(message));

            alert.InnerHtml = divInnerHtml.ToString();

            return new MvcHtmlString(alert.ToString());
        }
    }
}