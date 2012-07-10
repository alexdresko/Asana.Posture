namespace Asana.Posture.Core.Data
{
	using System.Collections.Generic;

	public class Application
    {
        public Application()
        {
            this.Memberships = new List<Membership>();
            this.Roles = new List<Role>();
            this.Users = new List<User>();
        }

        public string ApplicationName { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
