using System.Collections.Generic;

namespace Harvest.Models
{
	public class UsersContainer : ListContainerBase
	{
		public List<User> Users { get; set; }
	}
}