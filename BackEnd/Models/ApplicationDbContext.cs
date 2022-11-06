using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _NET_Office_Management_BackEnd.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<AssetHistory> AssetHistories { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Requisition> Requisitions { get; set; } = null!;
        public virtual DbSet<Leave> Leaves { get; set; } = null!;

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseMySql("server=localhost;user=root;database=inventory_dotnet_test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.SupervisorId, "user_supervisor_id_479813ed_fk_user_id");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .HasMaxLength(6)
                    .HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin)
                    .HasMaxLength(6)
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username");

                entity.Property(e => e.CanApproveInventory).HasColumnName("can_approve_inventory");

                entity.Property(e => e.CanApproveLeave).HasColumnName("can_approve_leave");

                entity.Property(e => e.CanDistributeInventory).HasColumnName("can_distribute_inventory");

                entity.Property(e => e.CanManageAsset).HasColumnName("can_manage_asset");

                entity.Property(e => e.SupervisorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("supervisor_id");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.UserSupervisors)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("user_supervisor_id_479813ed_fk_user_id");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("asset");

                entity.HasIndex(e => e.NextUserId, "asset_next_user_id_0451c2dc_fk_user_id");

                entity.HasIndex(e => e.UserId, "asset_user_id_54771fbb_fk_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(6)
                    .HasColumnName("creation_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Model)
                    .HasMaxLength(255)
                    .HasColumnName("model");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NextUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("next_user_id");

                entity.Property(e => e.PurchaseDate)
                    .HasMaxLength(6)
                    .HasColumnName("purchase_date");

                entity.Property(e => e.Serial)
                    .HasMaxLength(255)
                    .HasColumnName("serial");

                entity.Property(e => e.Status)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("type");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.Warranty)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("warranty");

                entity.HasOne(d => d.NextUser)
                    .WithMany(p => p.AssetNextUsers)
                    .HasForeignKey(d => d.NextUserId)
                    .HasConstraintName("asset_next_user_id_0451c2dc_fk_user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AssetUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asset_user_id_54771fbb_fk_user_id");
            });

            modelBuilder.Entity<AssetHistory>(entity =>
            {
                entity.ToTable("assethistory");

                entity.HasIndex(e => e.AssetId, "assethistory_asset_id_3b133b1f_fk");

                entity.HasIndex(e => e.FromUserId, "assethistory_fromUser_id_59c10a11_fk_user_id");

                entity.HasIndex(e => e.ToUserId, "assethistory_toUser_id_c48abf98_fk_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AssetId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("asset_id");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(6)
                    .HasColumnName("creation_date");

                entity.Property(e => e.FromUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("from_user_id");

                entity.Property(e => e.ToUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("to_user_id");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetHistories)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assethistory_asset_id_3b133b1f_fk");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.AssetHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assethistory_fromUser_id_59c10a11_fk_user_id");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.AssetHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("assethistory_toUser_id_c48abf98_fk_user_id");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Count)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("count");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.LastModifiedDate)
                    .HasMaxLength(6)
                    .HasColumnName("last_modified_date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.ToTable("requisition");

                entity.HasIndex(e => e.InventoryId, "requisition_inventory_id_115ab4a2_fk_inventory");

                entity.HasIndex(e => e.ApproverId, "requisition_approver_id_46fa8cdf_fk_user_id");

                entity.HasIndex(e => e.DistributorId, "requisition_distributor_id_4f5e5642_fk_user_id");

                entity.HasIndex(e => e.UserId, "requisition_user_id_c6cdb914_fk_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("amount");

                entity.Property(e => e.ApproveDate)
                    .HasMaxLength(6)
                    .HasColumnName("approve_date");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.ApproverId)
                    .HasColumnType("int(11)")
                    .HasColumnName("approver_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Distributed).HasColumnName("distributed");

                entity.Property(e => e.DistributionDate)
                    .HasMaxLength(6)
                    .HasColumnName("distribution_date");

                entity.Property(e => e.DistributorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("distributor_id");

                entity.Property(e => e.InventoryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("inventory_id");

                entity.Property(e => e.RequestDate)
                    .HasMaxLength(6)
                    .HasColumnName("request_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.RequisitionApprovers)
                    .HasForeignKey(d => d.ApproverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requisition_approver_id_46fa8cdf_fk_user_id");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.RequisitionDistributors)
                    .HasForeignKey(d => d.DistributorId)
                    .HasConstraintName("requisition_distributor_id_4f5e5642_fk_user_id");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requisition_inventory_id_115ab4a2_fk_inventory");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequisitionUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("requisition_user_id_c6cdb914_fk_user_id");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.ToTable("leave");

                entity.HasIndex(e => e.ApproverId, "leave_approver_id_7c2c50d7_fk_user_id");

                entity.HasIndex(e => e.UserId, "leave_user_id_b4b01ea9_fk_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.ApproveDate)
                    .HasMaxLength(6)
                    .HasColumnName("approve_date");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.ApproverId)
                    .HasColumnType("int(11)")
                    .HasColumnName("approver_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CreationDate)
                    .HasMaxLength(6)
                    .HasColumnName("creation_date");

                entity.Property(e => e.DayCount)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("day_count");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(6)
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(6)
                    .HasColumnName("start_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Approver)
                    .WithMany(p => p.LeaveApprovers)
                    .HasForeignKey(d => d.ApproverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leave_approver_id_7c2c50d7_fk_user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaveUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leave_user_id_b4b01ea9_fk_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
