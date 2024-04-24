using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public interface IQuizDbContext
    {
        DbSet<QuizItemEntity> QuizItems { get; set; }
        DbSet<QuizEntity> Quizzes { get; set; }
        DbSet<QuizItemUserAnswerEntity> UserAnswers { get; set; }
        DbSet<UserEntity> Users { get; set; }
    }
}