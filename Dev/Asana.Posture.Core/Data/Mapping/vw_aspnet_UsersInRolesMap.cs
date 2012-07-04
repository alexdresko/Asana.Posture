namespace NsTasks.Core.Data.Mapping
{
	using System.Data.Entity.ModelConfiguration;

	public class vw_aspnet_UsersInRolesMap : EntityTypeConfiguration<vw_aspnet_UsersInRoles>
    {
        public vw_aspnet_UsersInRolesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.RoleId });

            // Properties
            // Table & Column Mappings
            this.ToTable("vw_aspnet_UsersInRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
        }
    }
}
