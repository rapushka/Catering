using System.Collections.Generic;
using System.Linq;
using Catering.DbWorking;
using CateringCore.Model;

namespace CateringCore
{
	public partial class AuthenticationWindow
	{
		public AuthenticationWindow()
		{
			InitializeComponent();
			DbWorker.Open();
		}

		private IEnumerable<User> Users
			=> DbWorker.Context.Managers.AsEnumerable()
			           .Cast<User>()
			           .Concat(DbWorker.Context.Couriers)
			           .Concat(DbWorker.Context.Cooks);
	}
}