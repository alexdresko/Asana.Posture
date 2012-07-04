namespace NsTasks.Core.Data
{
	using System.Collections.Generic;

	public class WorkspaceStats
	{
		public WorkspaceStats()
		{
		}

		public IEnumerable<WorkplaceStat> Stats { get; set; }
	}
}