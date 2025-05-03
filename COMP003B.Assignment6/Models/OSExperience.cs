using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class OSExperience
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int TechnicianId { get; set; }
		[Required]
		public int OSDivisionId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string OSType { get; set; }
		public virtual Technician? Technician { get; set; }
		public virtual OSDivision? OSDivision { get; set; }
	}
}