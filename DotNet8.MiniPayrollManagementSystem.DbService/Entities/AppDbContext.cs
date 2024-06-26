namespace DotNet8.MiniPayrollManagementSystem.DbService.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    public virtual DbSet<TblPayroll> TblPayrolls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("Tbl_Employee");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeCode).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.HireDate).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPayroll>(entity =>
        {
            entity.HasKey(e => e.PId);

            entity.ToTable("Tbl_Payroll");

            entity.Property(e => e.PId).HasMaxLength(50).HasColumnName("PId");
            entity.Property(e => e.BonusAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DeductionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.GrossPay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetPay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PayDate).HasMaxLength(50);
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
