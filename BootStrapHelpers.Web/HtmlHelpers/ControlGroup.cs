using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapHelpers.Web.HtmlHelpers
{
    /// <summary>
    /// Creates the basic control group template used by Bootstrap
    /// </summary>
    public class ControlGroup : IDisposable
    {
        private TextWriter writer;
        private bool disposed = false;

        protected TagBuilder container;
        protected TagBuilder label;
        protected TagBuilder controls;

        public string LabelText { get; set; }
        public string ModelName { get; set; }
        public string InnerHtml { get; set; }

        internal ControlGroup()
        {
            // create group container
            container = new TagBuilder("div");
            container.AddCssClass("control-group");

            // create label
            label = new TagBuilder("label");
            label.AddCssClass("control-label");

            // create controls container
            controls = new TagBuilder("div");
            controls.AddCssClass("controls");
        }

        internal void AddContainerCssClass(string className)
        {
            container.AddCssClass(className);
        }

        internal void StartHtml(TextWriter textWriter)
        {
            PrepHtml();

            writer = textWriter;

            writer.Write(container.ToString(TagRenderMode.StartTag) + label.ToString() + controls.ToString(TagRenderMode.StartTag));
        }

        internal string GetFullHtml()
        {
            PrepHtml();

            // compose
            container.InnerHtml = label.ToString() + controls.ToString();

            return container.ToString();
        }

        void PrepHtml()
        {
            // set label
            label.SetInnerText(LabelText);

            // set model name
            if (!string.IsNullOrEmpty(ModelName))
                label.Attributes.Add("for", ModelName);

            // set inner control html
            controls.InnerHtml = InnerHtml;
        }

        public void Dispose()
        {
            // if not disposed, and we have an assigned writer, write closing divs
            if (!disposed && writer != null)
            {
                disposed = true;
                writer.Write("</div></div>");
            }
        }
    }
}