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
			// ��Ӧ�ó�������ʱ���еĴ���
			timer = new Timer(1000);
			timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimedEvent);

			//AutoReset ����Ϊ true ʱ��ÿ��ָ��ʱ��ѭ��һ�Σ�
			//���Ϊ false����ִֻ��һ�Ρ�
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
			// �ڻỰ����ʱ���еĴ��롣
			// ע��: ֻ���� Web.config �ļ��е� sessionstate ģʽ����Ϊ
			// InProc ʱ���Ż����� Session_End �¼�������Ựģʽ����Ϊ StateServer
			// �� SQLServer���򲻻��������¼���
		}
	}

}