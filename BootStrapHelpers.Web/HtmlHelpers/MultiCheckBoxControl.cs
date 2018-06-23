using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class MultiCheckBoxControl
    {
        public static MvcHtmlString MultiCheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            return MultiCheckBoxControlFor(html, expression, null);
        }

        public static MvcHtmlString MultiCheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, object innerHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return MultiCheckBoxControlHelper(html, htmlFieldName, metaData, InputExtensions.CheckBoxFor(html, expression, innerHtmlAttributes));
        }

        public static MvcHtmlString MultiCheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, Dictionary<string, object> innerHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return MultiCheckBoxControlHelper(html, htmlFieldName, metaData, InputExtensions.CheckBoxFor(html, expression, innerHtmlAttributes));
        }

        private static MvcHtmlString MultiCheckBoxControlHelper(HtmlHelper html, string htmlFieldName, ModelMetadata metadata, MvcHtmlString input)
        {
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            // create label container
            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("checkbox");

            // compose control
            label.InnerHtml = input.ToString() + labelText;

            return new MvcHtmlString(label.ToString());
        }
    }
}