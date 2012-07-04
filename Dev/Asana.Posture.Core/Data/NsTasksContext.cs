namespace NsTasks.Core.Data
{
	using System.Data.Entity;
	using System.Diagnostics.CodeAnalysis;

	using NsTasks.Core.Data.Mapping;

	public class NsTasksContext : DbContext
	{
		#region Constructors and Destructors

		static NsTasksContext()
		{
			Database.SetInitializer<NsTasksContext>(null);
		}

		public NsTasksContext()
			: base("Name=NsTasksContext")
		{
		}

		#endregion

		#region Public Properties

		// ReSharper disable InconsistentNaming
		public DbSet<Application> Applications { get; set; }

		public DbSet<Membership> Memberships { get; set; }

		public DbSet<Profile> Profiles { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<User> Users { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Applications> aspnet_Applications { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Membership> aspnet_Membership { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Paths> aspnet_Paths { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Profile> aspnet_Profile { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Roles> aspnet_Roles { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_Users> aspnet_Users { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_Applications> vw_aspnet_Applications { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_MembershipUsers> vw_aspnet_MembershipUsers { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_Profiles> vw_aspnet_Profiles { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_Roles> vw_aspnet_Roles { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_Users> vw_aspnet_Users { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_UsersInRoles> vw_aspnet_UsersInRoles { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_WebPartState_Paths> vw_aspnet_WebPartState_Paths { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_WebPartState_Shared> vw_aspnet_WebPartState_Shared { get; set; }

		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter",
			Justification = "Reviewed. Suppression is OK here.")]
		public DbSet<vw_aspnet_WebPartState_User> vw_aspnet_WebPartState_User { get; set; }

		// ReSharper restore InconsistentNaming
		#endregion

		#region Methods

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new ApplicationMap());
			modelBuilder.Configurations.Add(new aspnet_ApplicationsMap());
			modelBuilder.Configurations.Add(new aspnet_MembershipMap());
			modelBuilder.Configurations.Add(new aspnet_PathsMap());
			modelBuilder.Configurations.Add(new aspnet_PersonalizationAllUsersMap());
			modelBuilder.Configurations.Add(new aspnet_PersonalizationPerUserMap());
			modelBuilder.Configurations.Add(new aspnet_ProfileMap());
			modelBuilder.Configurations.Add(new aspnet_RolesMap());
			modelBuilder.Configurations.Add(new aspnet_SchemaVersionsMap());
			modelBuilder.Configurations.Add(new aspnet_UsersMap());
			modelBuilder.Configurations.Add(new aspnet_WebEvent_EventsMap());
			modelBuilder.Configurations.Add(new MembershipMap());
			modelBuilder.Configurations.Add(new ProfileMap());
			modelBuilder.Configurations.Add(new RoleMap());
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new vw_aspnet_ApplicationsMap());
			modelBuilder.Configurations.Add(new vw_aspnet_MembershipUsersMap());
			modelBuilder.Configurations.Add(new vw_aspnet_ProfilesMap());
			modelBuilder.Configurations.Add(new vw_aspnet_RolesMap());
			modelBuilder.Configurations.Add(new vw_aspnet_UsersMap());
			modelBuilder.Configurations.Add(new vw_aspnet_UsersInRolesMap());
			modelBuilder.Configurations.Add(new vw_aspnet_WebPartState_PathsMap());
			modelBuilder.Configurations.Add(new vw_aspnet_WebPartState_SharedMap());
			modelBuilder.Configurations.Add(new vw_aspnet_WebPartState_UserMap());
		}

		#endregion
	}
}