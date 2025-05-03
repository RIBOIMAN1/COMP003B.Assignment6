using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class Technician
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string OSType { get; set; }

		public virtual ICollection<OSExperience>? OSExperiences { get; set; }
		public int TechnicianAge { get; set; }
	}
}
