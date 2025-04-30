using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class OSDivision
	{
		public int CourseId { get; set; }

		[Required]
		public string Title { get; set; }

		public virtual ICollection<OSDivision>? OSDivisions { get; set; }
	}
}
