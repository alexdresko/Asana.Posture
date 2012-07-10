namespace Asana.Posture.Core.Data
{
	using System;
	using System.Collections.Generic;

	public class AsanaTask
	{
		public AsanaTask()
		{
			this.followers = new List<AsanaFollower>();
		}

		public long assignee { get; set; }

		public string assignee_status { get; set; }

		public DateTime created_at { get; set; }

		public bool completed { get; set; }
		public DateTime? completed_at { get; set; }
		public DateTime? due_on { get; set; }
		public List<AsanaFollower> followers { get; set; }
		public DateTime modified_at { get; set; }
		public string name { get; set; }
		public string notes { get; set; }
		public List<AsanaProject> projects { get; set; }
		public Int64 workspace { get; set; }
	}
}