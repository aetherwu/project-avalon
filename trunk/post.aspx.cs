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
				postNew(form);
				break;
			case "say":
				sayNew(form);
				break;
			case "delete":
				break;
			}

		}

		protected void postNew(NameValueCollection form)
		{
			string referHost = Request.UserHostAddress;
			string Content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string APIKey = HttpContext.Current.Request["key"];

			if (APIKey=="")
			{
				Content = HttpUtility.UrlDecode(Content);
				PostInfo newPost = new PostInfo(0,Content,Convert.ToDateTime("1999-1-1"));
				Post pst = new Post();
				pst.Insert(newPost);
				re.Text="1";
			}else{
				if (Session["OpenID_UserObject"]=="ok") {
					PostInfo newPost = new PostInfo(0,Content,Convert.ToDateTime("1999-1-1"));
					Post pst = new Post();
					pst.Insert(newPost);

					re.Text="2";
				}else{
					re.Text="-1";
				}
			}
	
		}

		protected void sayNew(NameValueCollection form)
		{
			DateTime LogTime = Convert.ToDateTime(form.Get("day"));
			string IP = Request.ServerVariables["REMOTE_ADDR"].ToString();

			string Guest = System.Text.RegularExpressions.Regex.Replace(form.Get("guest") ,"<[^>]+>","");
			string Content = System.Text.RegularExpressions.Regex.Replace(form.Get("message") ,"<[^>]+>","");
			string Homepage = System.Text.RegularExpressions.Regex.Replace(form.Get("home") ,"<[^>]+>","");

			CommentInfo newComment = new CommentInfo(0,LogTime,Guest,Content,Homepage,Convert.ToDateTime("1900-1-1"),IP);
			Comment cmt = new Comment();
			cmt.Insert(newComment);
		}

	}

}