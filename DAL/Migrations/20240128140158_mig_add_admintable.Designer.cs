﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240128140158_mig_add_admintable")]
    partial class mig_add_admintable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.About", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Details1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Entities.Concrete.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Entities.Concrete.Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WriterID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WriterID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Entities.Concrete.BlogRating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<int>("BlogRatingCount")
                        .HasColumnType("int");

                    b.Property<int>("BlogTotalScore")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BlogRatings");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<int>("BlogScore")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BlogID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.Concrete.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Entities.Concrete.Message", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Entities.Concrete.Message2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverID")
                        .HasColumnType("int");

                    b.Property<int?>("SenderID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Message2s");
                });

            modelBuilder.Entity("Entities.Concrete.NewsLetter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MailStatus")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("NewsLetters");
                });

            modelBuilder.Entity("Entities.Concrete.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Entities.Concrete.Writer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Entities.Concrete.Blog", b =>
                {
                    b.HasOne("Entities.Concrete.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Writer", "Writer")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterID");

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Entities.Concrete.Comment", b =>
                {
                    b.HasOne("Entities.Concrete.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Entities.Concrete.Message2", b =>
                {
                    b.HasOne("Entities.Concrete.Writer", "ReceiverUser")
                        .WithMany("WriterReceiver")
                        .HasForeignKey("ReceiverID");

                    b.HasOne("Entities.Concrete.Writer", "SenderUser")
                        .WithMany("WriterSender")
                        .HasForeignKey("SenderID");

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("Entities.Concrete.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Entities.Concrete.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("Entities.Concrete.Writer", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("WriterReceiver");

                    b.Navigation("WriterSender");
                });
#pragma warning restore 612, 618
        }
    }
}
