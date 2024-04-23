﻿// <auto-generated />
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20240423151616_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.QuizEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Matematyka"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Arytmetyka"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.QuizItemAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizItemAnswerEntity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "1"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "2"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "3"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "4"
                        },
                        new
                        {
                            Id = 5,
                            Answer = "5"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "6"
                        },
                        new
                        {
                            Id = 7,
                            Answer = "7"
                        },
                        new
                        {
                            Id = 8,
                            Answer = "8"
                        },
                        new
                        {
                            Id = 9,
                            Answer = "9"
                        },
                        new
                        {
                            Id = 10,
                            Answer = "0"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.QuizItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswer = "5",
                            Question = "2 + 3"
                        },
                        new
                        {
                            Id = 2,
                            CorrectAnswer = "6",
                            Question = "2 * 3"
                        },
                        new
                        {
                            Id = 3,
                            CorrectAnswer = "5",
                            Question = "8 - 3"
                        },
                        new
                        {
                            Id = 4,
                            CorrectAnswer = "4",
                            Question = "8 : 2"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.QuizItemUserAnswerEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("QuizItemId")
                        .HasColumnType("int");

                    b.Property<string>("UserAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "QuizId", "QuizItemId");

                    b.HasIndex("QuizItemId");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizEntityQuizItemEntity", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("QuizzesId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuizEntityQuizItemEntity");

                    b.HasData(
                        new
                        {
                            ItemsId = 1,
                            QuizzesId = 1
                        },
                        new
                        {
                            ItemsId = 2,
                            QuizzesId = 1
                        },
                        new
                        {
                            ItemsId = 3,
                            QuizzesId = 1
                        });
                });

            modelBuilder.Entity("QuizItemAnswerEntityQuizItemEntity", b =>
                {
                    b.Property<int>("IncorrectAnswersId")
                        .HasColumnType("int");

                    b.Property<int>("QuizItemsId")
                        .HasColumnType("int");

                    b.HasKey("IncorrectAnswersId", "QuizItemsId");

                    b.HasIndex("QuizItemsId");

                    b.ToTable("QuizItemAnswerEntityQuizItemEntity");

                    b.HasData(
                        new
                        {
                            IncorrectAnswersId = 1,
                            QuizItemsId = 1
                        },
                        new
                        {
                            IncorrectAnswersId = 2,
                            QuizItemsId = 1
                        },
                        new
                        {
                            IncorrectAnswersId = 3,
                            QuizItemsId = 1
                        },
                        new
                        {
                            IncorrectAnswersId = 3,
                            QuizItemsId = 2
                        },
                        new
                        {
                            IncorrectAnswersId = 4,
                            QuizItemsId = 2
                        },
                        new
                        {
                            IncorrectAnswersId = 7,
                            QuizItemsId = 2
                        },
                        new
                        {
                            IncorrectAnswersId = 1,
                            QuizItemsId = 3
                        },
                        new
                        {
                            IncorrectAnswersId = 3,
                            QuizItemsId = 3
                        },
                        new
                        {
                            IncorrectAnswersId = 9,
                            QuizItemsId = 3
                        },
                        new
                        {
                            IncorrectAnswersId = 2,
                            QuizItemsId = 4
                        },
                        new
                        {
                            IncorrectAnswersId = 6,
                            QuizItemsId = 4
                        },
                        new
                        {
                            IncorrectAnswersId = 8,
                            QuizItemsId = 4
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.QuizItemUserAnswerEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.QuizItemEntity", "QuizItem")
                        .WithMany()
                        .HasForeignKey("QuizItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizItem");
                });

            modelBuilder.Entity("QuizEntityQuizItemEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.QuizItemEntity", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.QuizEntity", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizItemAnswerEntityQuizItemEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.QuizItemAnswerEntity", null)
                        .WithMany()
                        .HasForeignKey("IncorrectAnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.QuizItemEntity", null)
                        .WithMany()
                        .HasForeignKey("QuizItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
