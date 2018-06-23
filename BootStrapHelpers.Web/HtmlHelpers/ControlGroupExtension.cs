using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class ControlGroupExtension
    {
        public static ControlGroup BeginControlGroup(this HtmlHelper html, string label)
        {
            var controlGroup = new ControlGroup();
            controlGroup.LabelText = label;

            // write beginning html
            controlGroup.StartHtml(html.ViewContext.Writer);

            return controlGroup;
        }

        internal static MvcHtmlString Helper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, MvcHtmlString input, string labelText = null, string validationMessage = null)
        {
            var control = new ControlGroup();

            // determine model name
            control.ModelName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);

            // determine label text
            control.LabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            bool isValid = true;
            string innerHtml = input.ToString();

            // check for errors
            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(control.ModelName, out modelState) && modelState.Errors.Count > 0)
            {
                // mark than an error occurs
                isValid = false;

                // create help message
                TagBuilder help = new TagBuilder("span");
                help.AddCssClass("help-inline");

                // set validation message
                if (!string.IsNullOrEmpty(validationMessage))
                    help.SetInnerText(validationMessage);
                else
                {
                    var error = modelState.Errors.FirstOrDefault(s => !string.IsNullOrEmpty(s.ErrorMessage));
                    if (error != null)
                        help.SetInnerText(error.ErrorMessage);
                }

                // append to controls
                innerHtml += help.ToString();
            }

            // set inner html for the control group
            control.InnerHtml = innerHtml;

            // if an error was found, set control group to error
            if (!isValid)
                control.AddContainerCssClass("error");

            return new MvcHtmlString(control.GetFullHtml());
        }
    }
}