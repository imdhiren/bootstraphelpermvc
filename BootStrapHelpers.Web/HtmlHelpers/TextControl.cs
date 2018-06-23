using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class TextControl
    {
        internal static readonly Dictionary<string, object> DefaultInputAttributes;

        static TextControl()
        {
            DefaultInputAttributes = new Dictionary<string, object>();
            DefaultInputAttributes.Add("class", "span3");
        }

        public static MvcHtmlString TextControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return TextControlFor(html, expression, DefaultInputAttributes);
        }

        public static MvcHtmlString TextControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object inputHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                InputExtensions.TextBoxFor(html, expression, inputHtmlAttributes));
        }

        public static MvcHtmlString TextControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> inputHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                InputExtensions.TextBoxFor(html, expression, inputHtmlAttributes));
        }
    }
}