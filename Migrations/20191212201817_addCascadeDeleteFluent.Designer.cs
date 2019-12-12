﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recitopia.Models;

namespace Recitopia.Migrations
{
    [DbContext(typeof(RecitopiaDBContext))]
    [Migration("20191212201817_addCascadeDeleteFluent")]
    partial class addCascadeDeleteFluent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Recitopia.Models.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Recitopia.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site_Role_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Recitopia.Models.Components", b =>
                {
                    b.Property<int>("Comp_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comp_Sort")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Component_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.HasKey("Comp_Id")
                        .HasName("PK__Componen__DC0BCC2082D90BE8");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("Recitopia.Models.Customer_Users", b =>
                {
                    b.Property<int>("CU_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Customer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomersCustomer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CU_Id");

                    b.HasIndex("CustomersCustomer_Id");

                    b.ToTable("Customer_Users");
                });

            modelBuilder.Entity("Recitopia.Models.Customers", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Web_URL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Customer_Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient", b =>
                {
                    b.Property<int>("Ingredient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_cup")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_gram")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_gram2")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_lb")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_lb2")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_ounce2")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_oz")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_tbsp")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal?>("Cost_per_tsp")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Ingred_Comp_name")
                        .HasColumnType("text");

                    b.Property<string>("Ingred_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool>("Package")
                        .HasColumnType("bit");

                    b.Property<string>("Packaging")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Per_item")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("Vendor_Id")
                        .HasColumnType("int");

                    b.Property<string>("Vendor_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Weight_Equiv_g")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("Weight_Equiv_measure")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Ingredient_Id");

                    b.HasIndex("Vendor_Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient_Components", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Comp_Id")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Ingred_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Comp_Id");

                    b.HasIndex("Ingred_Id");

                    b.ToTable("Ingredient_Components");
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient_Nutrients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Ingred_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Nut_per_100_grams")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("Nutrition_Item_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ingred_Id");

                    b.HasIndex("Nutrition_Item_Id");

                    b.ToTable("Ingredient_Nutrients");
                });

            modelBuilder.Entity("Recitopia.Models.Meal_Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.HasKey("Category_Id")
                        .HasName("PK__Meal_Cat__6DB38D6EACDEBF3E");

                    b.ToTable("Meal_Category");
                });

            modelBuilder.Entity("Recitopia.Models.Nutrition", b =>
                {
                    b.Property<int>("Nutrition_Item_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("DV")
                        .HasColumnType("int");

                    b.Property<string>("Measurement")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nutrition_Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("OrderOnNutrientPanel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((50))");

                    b.Property<bool>("ShowOnNutrientPanel")
                        .HasColumnType("bit");

                    b.HasKey("Nutrition_Item_Id")
                        .HasName("PK__Nutritio__326DD8CD1CE0BF74");

                    b.ToTable("Nutrition");
                });

            modelBuilder.Entity("Recitopia.Models.Recipe", b =>
                {
                    b.Property<int>("Recipe_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("Gluten_Free")
                        .HasColumnType("bit");

                    b.Property<decimal?>("LaborCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Recipe_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SS_Id")
                        .HasColumnType("int");

                    b.Property<string>("UPC")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Recipe_Id")
                        .HasName("PK__Recipe__0959CED94CA2B8C7");

                    b.HasIndex("Category_Id");

                    b.HasIndex("SS_Id");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("Recitopia.Models.Recipe_Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount_g")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Ingredient_Id")
                        .HasColumnType("int");

                    b.Property<int>("Recipe_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ingredient_Id");

                    b.HasIndex("Recipe_Id");

                    b.ToTable("Recipe_Ingredients");
                });

            modelBuilder.Entity("Recitopia.Models.Serving_Sizes", b =>
                {
                    b.Property<int>("SS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<int>("Serving_Size")
                        .HasColumnType("int");

                    b.HasKey("SS_Id")
                        .HasName("PK__Serving___456F9402CBFF87ED");

                    b.ToTable("Serving_Sizes");
                });

            modelBuilder.Entity("Recitopia.Models.Vendor", b =>
                {
                    b.Property<int>("Vendor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Vendor_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Web_URL")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Vendor_Id")
                        .HasName("PK__Vendor__D9CCC2A879687754");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Recitopia.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Recitopia.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Recitopia.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Recitopia.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recitopia.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Recitopia.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recitopia.Models.Customer_Users", b =>
                {
                    b.HasOne("Recitopia.Models.Customers", null)
                        .WithMany("Customer_Users")
                        .HasForeignKey("CustomersCustomer_Id");
                });

            modelBuilder.Entity("Recitopia.Models.Customers", b =>
                {
                    b.HasOne("Recitopia.Models.AppUser", null)
                        .WithMany("Customers")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient", b =>
                {
                    b.HasOne("Recitopia.Models.Vendor", "Vendor")
                        .WithMany("Ingredient")
                        .HasForeignKey("Vendor_Id")
                        .HasConstraintName("FK_Ingredient_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient_Components", b =>
                {
                    b.HasOne("Recitopia.Models.Components", "Components")
                        .WithMany("Ingredient_Components")
                        .HasForeignKey("Comp_Id")
                        .HasConstraintName("FK_Ingredient_Comp_ToTable_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recitopia.Models.Ingredient", "Ingredients")
                        .WithMany("Ingredient_Components")
                        .HasForeignKey("Ingred_Id")
                        .HasConstraintName("FK_Ingredient_Comp_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recitopia.Models.Ingredient_Nutrients", b =>
                {
                    b.HasOne("Recitopia.Models.Ingredient", "Ingredients")
                        .WithMany("Ingredient_Nutrients")
                        .HasForeignKey("Ingred_Id")
                        .HasConstraintName("FK_Ingredient_Nutrients_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recitopia.Models.Nutrition", "Nutrition")
                        .WithMany("Ingredient_Nutrients")
                        .HasForeignKey("Nutrition_Item_Id")
                        .HasConstraintName("FK_Ingredient_Nutrients_ToTable_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recitopia.Models.Recipe", b =>
                {
                    b.HasOne("Recitopia.Models.Meal_Category", "Meal_Category")
                        .WithMany("Recipe")
                        .HasForeignKey("Category_Id")
                        .HasConstraintName("FK_Recipe_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recitopia.Models.Serving_Sizes", "Serving_Sizes")
                        .WithMany("Recipe")
                        .HasForeignKey("SS_Id")
                        .HasConstraintName("FK_Serving_Size_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Recitopia.Models.Recipe_Ingredients", b =>
                {
                    b.HasOne("Recitopia.Models.Ingredient", "Ingredient")
                        .WithMany("Recipe_Ingredients")
                        .HasForeignKey("Ingredient_Id")
                        .HasConstraintName("FK_Recipe_Ingredients_ToTable_1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Recitopia.Models.Recipe", "Recipe")
                        .WithMany("Recipe_Ingredients")
                        .HasForeignKey("Recipe_Id")
                        .HasConstraintName("FK_Recipe_Ingredients_ToTable")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
