namespace NsTasks.Core.Data
{
	using System;
	using System.Collections.Generic;

	public class AsanaProject
	{
		public AsanaProject()
		{
			this.Tasks = new List<AsanaTask>();
			this.followers = new List<AsanaFollower>();
		}

		public Int64 workspaceid { get; set; }
		public string name { get; set; }
		public long id { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? modified_at { get; set; }
		public string notes { get; set; }
		public bool archived { get; set; }
		public AsanaWorkspace workspace { get; set; }
		public List<AsanaFollower> followers { get; set; }

		public List<AsanaTask> Tasks { get; set; }
	}
}