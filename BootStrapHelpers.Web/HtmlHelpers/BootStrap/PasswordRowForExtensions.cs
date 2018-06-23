using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BootStrapHelpers.Web.HtmlHelpers.BootStrap
{
    public static class PasswordRowForExtensions
    {
        public static IHtmlString PasswordRowFor<TModel, TProperty>(this HtmlHelper<TModel> html,
                                                                                                                             Expression<Func<TModel, TProperty>> expression)
        {
            return PasswordRowFor(html, expression, null);
        }

        public static IHtmlString PasswordRowFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var content = html.TextBoxRowFor(expression, htmlAttributes).ToHtmlString();
            content = content.Replace("type=\"text\"", "type=\"password\"");

            return MvcHtmlString.Create(content);
        }
    }
}