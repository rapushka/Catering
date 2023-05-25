using Catering.DbWorking;

namespace CateringCore
{
	public partial class AuthenticationWindow
	{
		public AuthenticationWindow()
		{
			InitializeComponent();
			DbWorker.Open();
		}
	}
}