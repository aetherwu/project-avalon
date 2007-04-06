using System;
using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SomeControls
{
	[
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal),
    DefaultProperty("Text"),
    ToolboxData("<{0}:clr runat=\"server\"> </{0}:clr>")
    ]
    public class clr : Control
    {
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(""),
        Description("clear text."),
        Localizable(true)
        ]
        public virtual string Text
        {
            get
            {
                string s = (string)ViewState["Text"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(Text);
        }

    }
}