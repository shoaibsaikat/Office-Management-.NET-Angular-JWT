﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _NET_Office_Management_BackEnd.Models;

#nullable disable

namespace _NET_Office_Management_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220321062203_User null fields added")]
    partial class Usernullfieldsadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreationDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<int?>("NextUserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("next_user_id");

                    b.Property<DateTime>("PurchaseDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("purchase_date");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("serial");

                    b.Property<ushort>("Status")
                        .HasColumnType("smallint(5) unsigned")
                        .HasColumnName("status");

                    b.Property<ushort>("Type")
                        .HasColumnType("smallint(5) unsigned")
                        .HasColumnName("type");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.Property<ulong>("Warranty")
                        .HasColumnType("bigint(20) unsigned")
                        .HasColumnName("warranty");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NextUserId" }, "asset_next_user_id_0451c2dc_fk_user_id");

                    b.HasIndex(new[] { "UserId" }, "asset_user_id_54771fbb_fk_user_id");

                    b.ToTable("asset", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.AssetHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)")
                        .HasColumnName("id");

                    b.Property<long>("AssetId")
                        .HasColumnType("bigint(20)")
                        .HasColumnName("asset_id");

                    b.Property<DateTime>("CreationDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation_date");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("from_user_id");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("to_user_id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AssetId" }, "assethistory_asset_id_3b133b1f_fk");

                    b.HasIndex(new[] { "FromUserId" }, "assethistory_fromUser_id_59c10a11_fk_user_id");

                    b.HasIndex(new[] { "ToUserId" }, "assethistory_toUser_id_c48abf98_fk_user_id");

                    b.ToTable("assethistory", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<uint>("Count")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("unit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "name")
                        .IsUnique();

                    b.ToTable("inventory", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Leave", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint(20)")
                        .HasColumnName("id");

                    b.Property<DateTime?>("ApproveDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("approve_date");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("approved");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int(11)")
                        .HasColumnName("approver_id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreationDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation_date");

                    b.Property<uint>("DayCount")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("day_count");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("StartDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApproverId" }, "leave_approver_id_7c2c50d7_fk_user_id");

                    b.HasIndex(new[] { "UserId" }, "leave_user_id_b4b01ea9_fk_user_id");

                    b.ToTable("leave", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Requisition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<uint>("Amount")
                        .HasColumnType("int(10) unsigned")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("ApproveDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("approve_date");

                    b.Property<bool?>("Approved")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("approved");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int(11)")
                        .HasColumnName("approver_id");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext")
                        .HasColumnName("comment");

                    b.Property<bool?>("Distributed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("distributed");

                    b.Property<DateTime?>("DistributionDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("distribution_date");

                    b.Property<int?>("DistributorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("distributor_id");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("inventory_id");

                    b.Property<DateTime>("RequestDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("request_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApproverId" }, "requisition_approver_id_46fa8cdf_fk_user_id");

                    b.HasIndex(new[] { "DistributorId" }, "requisition_distributor_id_4f5e5642_fk_user_id");

                    b.HasIndex(new[] { "InventoryId" }, "requisition_inventory_id_115ab4a2_fk_inventory");

                    b.HasIndex(new[] { "UserId" }, "requisition_user_id_c6cdb914_fk_user_id");

                    b.ToTable("requisition", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("CanApproveInventory")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_approve_inventory");

                    b.Property<bool>("CanApproveLeave")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_approve_leave");

                    b.Property<bool>("CanDistributeInventory")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_distribute_inventory");

                    b.Property<bool>("CanManageAsset")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("can_manage_asset");

                    b.Property<DateTime>("DateJoined")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_joined");

                    b.Property<string>("Email")
                        .HasMaxLength(254)
                        .HasColumnType("varchar(254)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsSuperuser")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_superuser");

                    b.Property<DateTime?>("LastLogin")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_login");

                    b.Property<string>("LastName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("password");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("supervisor_id");

                    b.Property<string>("Username")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SupervisorId" }, "user_supervisor_id_479813ed_fk_user_id");

                    b.HasIndex(new[] { "Username" }, "username")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Asset", b =>
                {
                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "NextUser")
                        .WithMany("AssetNextUsers")
                        .HasForeignKey("NextUserId")
                        .HasConstraintName("asset_next_user_id_0451c2dc_fk_user_id");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "User")
                        .WithMany("AssetUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("asset_user_id_54771fbb_fk_user_id");

                    b.Navigation("NextUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.AssetHistory", b =>
                {
                    b.HasOne("_NET_Office_Management_BackEnd.Models.Asset", "Asset")
                        .WithMany("AssetHistories")
                        .HasForeignKey("AssetId")
                        .IsRequired()
                        .HasConstraintName("assethistory_asset_id_3b133b1f_fk");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "FromUser")
                        .WithMany("AssetHistoryFromUsers")
                        .HasForeignKey("FromUserId")
                        .IsRequired()
                        .HasConstraintName("assethistory_fromUser_id_59c10a11_fk_user_id");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "ToUser")
                        .WithMany("AssetHistoryToUsers")
                        .HasForeignKey("ToUserId")
                        .IsRequired()
                        .HasConstraintName("assethistory_toUser_id_c48abf98_fk_user_id");

                    b.Navigation("Asset");

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Leave", b =>
                {
                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "Approver")
                        .WithMany("LeaveApprovers")
                        .HasForeignKey("ApproverId")
                        .IsRequired()
                        .HasConstraintName("leave_approver_id_7c2c50d7_fk_user_id");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "User")
                        .WithMany("LeaveUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("leave_user_id_b4b01ea9_fk_user_id");

                    b.Navigation("Approver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Requisition", b =>
                {
                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "Approver")
                        .WithMany("RequisitionApprovers")
                        .HasForeignKey("ApproverId")
                        .IsRequired()
                        .HasConstraintName("requisition_approver_id_46fa8cdf_fk_user_id");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "Distributor")
                        .WithMany("RequisitionDistributors")
                        .HasForeignKey("DistributorId")
                        .HasConstraintName("requisition_distributor_id_4f5e5642_fk_user_id");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.Inventory", "Inventory")
                        .WithMany("Requisitions")
                        .HasForeignKey("InventoryId")
                        .IsRequired()
                        .HasConstraintName("requisition_inventory_id_115ab4a2_fk_inventory");

                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "User")
                        .WithMany("RequisitionUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("requisition_user_id_c6cdb914_fk_user_id");

                    b.Navigation("Approver");

                    b.Navigation("Distributor");

                    b.Navigation("Inventory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.User", b =>
                {
                    b.HasOne("_NET_Office_Management_BackEnd.Models.User", "Supervisor")
                        .WithMany("UserSupervisors")
                        .HasForeignKey("SupervisorId")
                        .HasConstraintName("user_supervisor_id_479813ed_fk_user_id");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Asset", b =>
                {
                    b.Navigation("AssetHistories");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.Inventory", b =>
                {
                    b.Navigation("Requisitions");
                });

            modelBuilder.Entity("_NET_Office_Management_BackEnd.Models.User", b =>
                {
                    b.Navigation("AssetHistoryFromUsers");

                    b.Navigation("AssetHistoryToUsers");

                    b.Navigation("AssetNextUsers");

                    b.Navigation("AssetUsers");

                    b.Navigation("LeaveApprovers");

                    b.Navigation("LeaveUsers");

                    b.Navigation("RequisitionApprovers");

                    b.Navigation("RequisitionDistributors");

                    b.Navigation("RequisitionUsers");

                    b.Navigation("UserSupervisors");
                });
#pragma warning restore 612, 618
        }
    }
}
