using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;

using Model;
using BLL;
using Utility;

namespace Avalon.Web {

	public partial class _post : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, EventArgs e)
		{
			NameValueCollection form;
			form=Request.Form;
			
			string method = HttpContext.Current.Request["m"];

			switch (method)
			{
			case "new":
				im(form);
				break;

			case "post":
				post(form);
				break;
			case "update":
				update(form);
				break;

			case "say":
				sayNew(form);
				break;
			case "delete":
				delete(form);
				break;
			}

		}

		protected void im(NameValueCollection form)
		{
			string content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string APIKey = HttpContext.Current.Request["key"];

			if (APIKey=="")
			{
				content = HttpUtility.UrlDecode(content);
                ClipInfo newClip = new ClipInfo(0, content, Convert.ToDateTime("1999-1-1"),"", "avalon",1);
				Clip clip = new Clip();
				clip.Update(newClip);
				re.Text="writed from im";
			}
		}

		protected void post(NameValueCollection form)
		{
			string content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);

			if (Session["OpenID_UserObject"] != null) {
                ClipInfo newClip = new ClipInfo(0, content, Convert.ToDateTime("1999-1-1"), "", "avalon", 1);
				Clip clip = new Clip();
				clip.Update(newClip);
				re.Text="0";
			}else{
				re.Text="login failure now";
			}
		}

		protected void update(NameValueCollection form)
		{
			string content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string postTime = HttpContext.Current.Request["time"];

            if (Session["OpenID_UserObject"] != null)
            {
				//update
				//postTime exsample: 2007-7-4 12:06:20
				System.Web.HttpContext.Current.Trace.Write("getexistTime",postTime );
                ClipInfo existdClip = new ClipInfo(0, content, Convert.ToDateTime(postTime), "", "avalon", 1);
				Clip clip = new Clip();
				clip.Update(existdClip);
				re.Text="1";
			}else{
				re.Text="login failure now";
			}
		}

		protected void delete(NameValueCollection form)
		{
			string postTime = HttpContext.Current.Request["time"];

            if (Session["OpenID_UserObject"] != null)
            {
				//delete
				//postTime exsample: 2007-7-4 12:06:20
                ClipInfo existdClip = new ClipInfo(0, "", Convert.ToDateTime(postTime), "", "avalon", 1);
				Clip clip = new Clip();
				clip.Delete(existdClip);
				re.Text="1";
			}else{
				re.Text="login failure now";
			}
		}

		protected void sayNew(NameValueCollection form)
		{
			DateTime LogTime = Convert.ToDateTime(form.Get("day"));
			string IP = Request.ServerVariables["REMOTE_ADDR"].ToString();

			string Guest = System.Text.RegularExpressions.Regex.Replace(form.Get("guest") ,"<[^>]+>","");
			string content = System.Text.RegularExpressions.Regex.Replace(form.Get("message") ,"<[^>]+>","");
			string Homepage = System.Text.RegularExpressions.Regex.Replace(form.Get("home") ,"<[^>]+>","");

			CommentInfo newComment = new CommentInfo(0,LogTime,Guest,content,Homepage,Convert.ToDateTime("1900-1-1"),IP);
			Comment cmt = new Comment();
			cmt.Insert(newComment);
		}

	}

}