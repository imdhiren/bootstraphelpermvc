using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class TextAreaControl
    {
        public static MvcHtmlString TextAreaControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return TextAreaControlFor(html, expression, TextControl.DefaultInputAttributes);
        }

        public static MvcHtmlString TextAreaControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object inputHtmlAttributes)
        {
            return
                TextAreaControlHelper(
                    html,
                    expression,
                    TextAreaExtensions.TextAreaFor(html, expression, inputHtmlAttributes));
        }

        public static MvcHtmlString TextAreaControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, int rows, int columns, object inputHtmlAttributes)
        {
            return
                TextAreaControlHelper(
                    html,
                    expression,
                    TextAreaExtensions.TextAreaFor(html, expression, rows, columns, inputHtmlAttributes));
        }

        public static MvcHtmlString TextAreaControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> inputHtmlAttributes)
        {
            return
                TextAreaControlHelper(
                    html,
                    expression,
                    TextAreaExtensions.TextAreaFor(html, expression, inputHtmlAttributes));
        }

        public static MvcHtmlString TextAreaControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, int rows, int columns, IDictionary<string, object> inputHtmlAttributes)
        {
            return
                TextAreaControlHelper(
                    html,
                    expression,
                    TextAreaExtensions.TextAreaFor(html, expression, rows, columns, inputHtmlAttributes));
        }

        private static MvcHtmlString TextAreaControlHelper<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, MvcHtmlString inputHtml)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return
                ControlGroupExtension.Helper(
                    html,
                    metaData,
                    htmlFieldName,
                    inputHtml);
        }
    }
}