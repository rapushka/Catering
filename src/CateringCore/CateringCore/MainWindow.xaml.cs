using System.Windows;
using Catering.DbWorking;

namespace CateringCore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DbWorker.Open();
		}
	}
}