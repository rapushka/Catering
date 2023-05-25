using System.Windows;
using Catering.DbWorking;

namespace CateringCore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class AuthenticationWindow
	{
		public AuthenticationWindow()
		{
			InitializeComponent();
			DbWorker.Open();
		}
	}
}