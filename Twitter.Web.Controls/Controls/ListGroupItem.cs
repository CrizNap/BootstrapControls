using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Twitter.Web.Controls
{
    public enum ListGroupItemTypes
    {
        Default = 0,
        Success = 1,
        Info = 2,
        Warning = 3,
        Danger = 4
    }

    [ToolboxData("<{0}:ListGroupItem runat=server></{0}:ListGroupItem>")]
    [ToolboxItem(false)]
    public class ListGroupItem : Control, INamingContainer
    {
        #region CssClass method

        string sCssClass = "";

        /// <summary>
        /// Adds the CSS class.
        /// </summary>
        /// <param name="cssClass">The CSS class.</param>
        private void AddCssClass(string cssClass)
        {
            if (String.IsNullOrEmpty(this.sCssClass))
            {
                this.sCssClass = cssClass;
            }
            else
            {
                this.sCssClass += " " + cssClass;
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the badge.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string Badge
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the navigate URL.
        /// </summary>
        /// <value>
        /// The navigate URL.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DefaultValue("#")]
        [UrlProperty]
        public string NavigateUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListGroupItem" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DefaultValue(true)]
        public bool Enabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ListGroupItem" /> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool Active
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the list group item.
        /// </summary>
        /// <value>
        /// The type of the list group item.
        /// </value>
        [Category("Appearance")]
        [DefaultValue(ListGroupItemTypes.Default)]
        public ListGroupItemTypes ListGroupItemType
        {
            get { return (ListGroupItemTypes)ViewState["ListGroupItemType"]; }
            set { ViewState["ListGroupItemType"] = value; }
        }

        public ListGroupItem()
        {
            this.Badge = "";
            this.Active = false;
            this.Enabled = true;
            this.ListGroupItemType = ListGroupItemTypes.Default;
            this.Text = "";
            this.NavigateUrl = "#";
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="output">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter output)
        {
            if (this.Parent != null && this.Parent.GetType() == typeof(ListGroup))
            {
                //this.AddCssClass(this.CssClass);
                this.AddCssClass("list-group-item");
                this.AddCssClass(GetCssListGroupItemType());


                if (((ListGroup)this.Parent).LinkedItem && !Enabled)
                {
                    this.AddCssClass("disabled");
                }

                if (((ListGroup)this.Parent).LinkedItem && Active)
                {
                    this.AddCssClass("active");
                }

                if (!String.IsNullOrEmpty(this.sCssClass))
                {
                    output.AddAttribute(HtmlTextWriterAttribute.Class, this.sCssClass);
                }

                output.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
                output.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);

                if (((ListGroup)this.Parent).LinkedItem)
                {
                    output.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                    output.RenderBeginTag(HtmlTextWriterTag.A);
                }
                else
                {
                    output.RenderBeginTag(HtmlTextWriterTag.Li);
                }

                if (!String.IsNullOrEmpty(this.Badge))
                {
                    RenderBadge(output);
                }

                output.Write(this.Text);
                output.RenderEndTag();
            }

        }

        private void RenderBadge(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Class, "badge");
            output.RenderBeginTag(HtmlTextWriterTag.Span);
            output.Write(Badge);
            output.RenderEndTag();
        }

        /// <summary>
        /// Gets the type of the CSS list group item.
        /// </summary>
        /// <returns></returns>
        private string GetCssListGroupItemType()
        {
            string str = "";

            switch (this.ListGroupItemType)
            {
                case ListGroupItemTypes.Success:
                    str = "list-group-item-success";
                    break;

                case ListGroupItemTypes.Info:
                    str = "list-group-item-info";
                    break;

                case ListGroupItemTypes.Warning:
                    str = "list-group-item-warning";
                    break;

                case ListGroupItemTypes.Danger:
                    str = "list-group-item-danger";
                    break;

                default:
                    break;
            }

            return str;
        }
    }
}
