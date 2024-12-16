﻿// <auto-generated />
using System;
using Financial_Almohtasep.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Financial_Almohtasep.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Financial_Almohtasep.Data.ChequeDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ChequeNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("bankName")
                        .HasColumnType("INTEGER");

                    b.Property<int>("chequeStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("currency")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ChequeDetails");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumper")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.EmployeeTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SalaryChange")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeTransaction");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.Payees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChequeDetailsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChequeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("PayeeTypes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChequeDetailsId");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.EmployeeTransaction", b =>
                {
                    b.HasOne("Financial_Almohtasep.Data.Employee", "Employee")
                        .WithMany("Transaction")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.Payees", b =>
                {
                    b.HasOne("Financial_Almohtasep.Data.ChequeDetails", "ChequeDetails")
                        .WithMany("payees")
                        .HasForeignKey("ChequeDetailsId");

                    b.Navigation("ChequeDetails");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.ChequeDetails", b =>
                {
                    b.Navigation("payees");
                });

            modelBuilder.Entity("Financial_Almohtasep.Data.Employee", b =>
                {
                    b.Navigation("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
