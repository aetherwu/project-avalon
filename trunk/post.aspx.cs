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
			string Content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string APIKey = HttpContext.Current.Request["key"];

			if (APIKey=="")
			{
				//密码验证通过，从IM发来的请求
				//解码
				Content = HttpUtility.UrlDecode(Content);
				Content = Content +"　<span class='gtalk'>by v2ex.ing from gtalk</span>";
				PostInfo newPost = new PostInfo(0,Content,Convert.ToDateTime("1999-1-1"));
				Post pst = new Post();
				pst.Insert(newPost);
				re.Text="writed from im";
			}
		}

		protected void post(NameValueCollection form)
		{
			string Content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string PostTime = HttpContext.Current.Request["time"];

			if (Session["OpenID_UserObject"]=="ok") {
				//new
				System.Web.HttpContext.Current.Trace.Write("getpostTime",PostTime );
				PostInfo newPost = new PostInfo(0,Content,Convert.ToDateTime(PostTime));
				Post pst = new Post();
				pst.Insert(newPost);
				re.Text="0";
			}else{
				re.Text="login failure now";
			}
		}


		protected void update(NameValueCollection form)
		{
			string Content = FormatCode.getBasicHTML(HttpContext.Current.Request["clip"]);
			string PostTime = HttpContext.Current.Request["time"];

			if (Session["OpenID_UserObject"]=="ok") {
				//update
				//PostTime exsample: 2007-7-4 12:06:20
				System.Web.HttpContext.Current.Trace.Write("getexistTime",PostTime );
				PostInfo existdPost = new PostInfo(0,Content,Convert.ToDateTime(PostTime));
				Post pst = new Post();
				pst.Update(existdPost);
				re.Text="1";
			}else{
				re.Text="login failure now";
			}
		}

		protected void delete(NameValueCollection form)
		{
			string PostTime = HttpContext.Current.Request["time"];

			if (Session["OpenID_UserObject"]=="ok") {
				//delete
				//PostTime exsample: 2007-7-4 12:06:20
				PostInfo existdPost = new PostInfo(0,"",Convert.ToDateTime(PostTime));
				Post pst = new Post();
				pst.Delete(existdPost);
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
			string Content = System.Text.RegularExpressions.Regex.Replace(form.Get("message") ,"<[^>]+>","");
			string Homepage = System.Text.RegularExpressions.Regex.Replace(form.Get("home") ,"<[^>]+>","");

			CommentInfo newComment = new CommentInfo(0,LogTime,Guest,Content,Homepage,Convert.ToDateTime("1900-1-1"),IP);
			Comment cmt = new Comment();
			cmt.Insert(newComment);
		}

	}

}