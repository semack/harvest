using System.Collections.Generic;

namespace Harvest.Models
{
	public class UserProjectAssignmentsContainer : ListContainerBase
	{
		public List<UserProjectAssignment> ProjectAssignments { get; set; }
	}
}