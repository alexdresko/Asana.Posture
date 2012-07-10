namespace Asana.Posture.Core.Data
{
	using System.Collections.Generic;

	public class AsanaNavigation
	{
		public string Name { get; set; }

		public List<AsanaProject> Projects { get; set; }

		public long Id { get; set; }
	}
}