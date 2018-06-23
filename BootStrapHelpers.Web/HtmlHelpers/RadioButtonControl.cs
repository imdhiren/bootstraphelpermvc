using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class RadioButtonControl
    {
        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value)
        {
            return RadioButtonControlFor(html, expression, value, value.ToString());
        }

        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value, string label)
        {
            return RadioButtonControlFor(html, expression, value, label, null);
        }

        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value, object inputHtmlAttributes)
        {
            return RadioButtonControlFor(html, expression, value, value.ToString(), inputHtmlAttributes);
        }

        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value, string label, object inputHtmlAttributes)
        {
            return RadioButtonControlHelper(html, label, InputExtensions.RadioButtonFor(html, expression, value, inputHtmlAttributes));
        }

        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value, IDictionary<string, object> inputHtmlAttributes)
        {
            return RadioButtonControlFor(html, expression, value, value.ToString(), inputHtmlAttributes);
        }

        public static MvcHtmlString RadioButtonControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object value, string label, IDictionary<string, object> inputHtmlAttributes)
        {
            return RadioButtonControlHelper(html, label, InputExtensions.RadioButtonFor(html, expression, value, inputHtmlAttributes));
        }

        private static MvcHtmlString RadioButtonControlHelper(HtmlHelper html, string labelText, MvcHtmlString input)
        {
            // create label container
            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("radio");

            // compose control
            label.InnerHtml = input.ToString() + labelText;

            return new MvcHtmlString(label.ToString());
        }
    }
}