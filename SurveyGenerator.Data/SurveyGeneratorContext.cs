using SurveyGenerator.Core.Domaine.Routes;
using SurveyGenerator.Core.Domaine.Surveys.Questions;
using SurveyGenerator.Core.Domaine.Surveys.Responses;
using SurveyGenerator.Core.Domaine.Users;
using SurveyGenerator.Data.Conventions;
using SurveyGenerator.Data.Mapping;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace SurveyGenerator.Data
{
    public class SurveyGeneratorContext : DbContext
    {

        public SurveyGeneratorContext() : base("name=SurveyGeneratorConnectionString")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new StringLabelProperties());
            ConventionRules.Apply(modelBuilder);


            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(SurveyEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            modelBuilder.Entity<User>()
                   .MapToStoredProcedures();

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionRoute> PermissionFeatures { get; set; }
                
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
                
        public virtual DbSet<ResponseItem> ResponseItems { get; set; }
        public virtual DbSet<ResponseOption> ResponseOptions { get; set; }
    }
}
