using System;
using System.Web;
using System.Web.SessionState;
using System.Timers;

using Live;

namespace Avalon.Web {

	public partial class _global : System.Web.HttpApplication
	{

		public static int i = 1;
		public Runer runer;
		public Timer timer;
		void Application_Start(object sender, EventArgs e)
		{
			// 在应用程序启动时运行的代码
			timer = new Timer(1000);
			timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimedEvent);

			//AutoReset 属性为 true 时，每隔指定时间循环一次；
			//如果为 false，则只执行一次。
			timer.AutoReset = true;
			timer.Enabled = true;
			runer = new Runer();
		}

		protected void OnTimedEvent(object sender, ElapsedEventArgs e) {
			i++;
			//runer.loadRSS();
		}

		void Application_End(object sender, EventArgs e) {}
		void Application_Error(object sender, EventArgs e) {}

		void Session_Start(object sender, EventArgs e) {}
		void Session_End(object sender, EventArgs e)
		{
			// 在会话结束时运行的代码。
			// 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
			// InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
			// 或 SQLServer，则不会引发该事件。
		}
	}

}