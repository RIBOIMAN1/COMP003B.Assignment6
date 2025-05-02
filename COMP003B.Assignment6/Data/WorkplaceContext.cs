using COMP003B.Assignment6.Models;
using Microsoft.EntityFrameworkCore;
public class WorkplaceContext : DbContext
{
	public WorkplaceContext(DbContextOptions<WorkplaceContext> options) : base(options)
	{
	}

	public DbSet<Technician> Technicians { get; set; }
	public DbSet<OSDivision> OSDivisions { get; set; }
	public DbSet<OSExperience> OSExperiences { get; set; }
}