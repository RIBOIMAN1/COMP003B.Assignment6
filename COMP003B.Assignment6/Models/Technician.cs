using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class Technician
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string OSType { get; set; }

		public virtual ICollection<OSExperience>? OSExperiences { get; set; }
	}
}
