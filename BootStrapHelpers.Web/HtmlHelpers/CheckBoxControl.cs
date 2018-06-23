using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class CheckBoxControl
    {
        public static MvcHtmlString CheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            return CheckBoxControlFor(html, expression, null);
        }

        public static MvcHtmlString CheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, object innerHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return CheckBoxControlHelper(html, expression, metaData, InputExtensions.CheckBoxFor(html, expression, innerHtmlAttributes));
        }

        public static MvcHtmlString CheckBoxControlFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, Dictionary<string, object> innerHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return CheckBoxControlHelper(html, expression, metaData, InputExtensions.CheckBoxFor(html, expression, innerHtmlAttributes));
        }

        private static MvcHtmlString CheckBoxControlHelper<TModel>(HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, ModelMetadata metadata, MvcHtmlString input)
        {
            var metaData = ModelMetadata.FromLambdaExpression<TModel, bool>(expression, html.ViewData);

            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            // create label container
            TagBuilder label = new TagBuilder("label");
            label.AddCssClass("checkbox");

            // compose control
            label.InnerHtml = input.ToString();

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                new MvcHtmlString(label.ToString()));
        }
    }
}