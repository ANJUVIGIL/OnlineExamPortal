using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models.Mapping;

namespace DAL.Models
{
    public partial class MainProjectContext : DbContext
    {
        static MainProjectContext()
        {
            Database.SetInitializer<MainProjectContext>(null);
        }

        public MainProjectContext()
            : base("Name=MainProjectContext")
        {
        }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamRegistration> ExamRegistrations { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionXDuration> QuestionXDurations { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestXPaper> TestXPapers { get; set; }
        public DbSet<TestXQuestion> TestXQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ChoiceMap());
            modelBuilder.Configurations.Add(new ExamRegistrationMap());
            modelBuilder.Configurations.Add(new ExhibitMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionCategoryMap());
            modelBuilder.Configurations.Add(new QuestionXDurationMap());
            modelBuilder.Configurations.Add(new RegistrationMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TestMap());
            modelBuilder.Configurations.Add(new TestXPaperMap());
            modelBuilder.Configurations.Add(new TestXQuestionMap());
        }
    }
}
