using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class PasswordControl
    {
        public static MvcHtmlString PasswordControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return PasswordControlFor(html, expression, TextControl.DefaultInputAttributes);
        }

        public static MvcHtmlString PasswordControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> inputHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                InputExtensions.PasswordFor(html, expression, inputHtmlAttributes));
        }
    }
}