namespace NsTasks.Core.Data
{
	public class Profile
    {
        public System.Guid UserId { get; set; }
        public string PropertyNames { get; set; }
        public string PropertyValueStrings { get; set; }
        public byte[] PropertyValueBinary { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public virtual User User { get; set; }
    }
}
