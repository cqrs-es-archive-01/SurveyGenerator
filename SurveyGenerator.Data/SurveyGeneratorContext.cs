
using SurveyGenerator.Core.Domaine;
using SurveyGenerator.Core.Domaine.Features;
using SurveyGenerator.Core.Domaine.Surveys.Questions;
using SurveyGenerator.Core.Domaine.Surveys.Responses;
using SurveyGenerator.Core.Domaine.Users;
using SurveyGenerator.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace SurveyGenerator.Data
{
    public class SurveyGeneratorContext : DbContext
    {

        public SurveyGeneratorContext() : base("name=SurveyGeneratorString")
        { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(SurveyEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<PermissionFeature> PermissionFeatures { get; set; }
                
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
                
        public virtual DbSet<ResponseItem> ResponseItems { get; set; }
        public virtual DbSet<ResponseOption> ResponseOptions { get; set; }
    }
}
