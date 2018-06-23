using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    public static class DropDownListControl
    {
        public static MvcHtmlString DropDownListControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            return DropDownListControlFor(html, expression, selectList, null);
        }

        public static MvcHtmlString DropDownListControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> inputHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                SelectExtensions.DropDownListFor(html, expression, selectList, inputHtmlAttributes)
            );
        }

        public static MvcHtmlString DropDownListControlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList, object inputHtmlAttributes)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            return ControlGroupExtension.Helper(
                html,
                metaData,
                htmlFieldName,
                SelectExtensions.DropDownListFor(html, expression, selectList, inputHtmlAttributes)
            );
        }
    }
}