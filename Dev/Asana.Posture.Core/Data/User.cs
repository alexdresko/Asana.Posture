namespace NsTasks.Core.Data
{
	using System.Collections.Generic;

	public class User
    {
        public User()
        {
            this.Roles = new List<Role>();
        }

        public System.Guid ApplicationId { get; set; }
        public System.Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAnonymous { get; set; }
        public System.DateTime LastActivityDate { get; set; }
        public virtual Application Application { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
