using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillOrgBE.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace SkillOrgBE.API.Context
{
    public class SkillDBContext:DbContext
    {

        public DbSet<SkillLevelOne> SkillLevelOne { get; set; }
        public DbSet<SkillLevelTwo> SkillLevelTwo { get; set; }
        public DbSet<SkillLevelThree> SkillLevelThree{ get; set; }
        public DbSet<SkillAdoption> SkillAdoption{ get; set; }


        public SkillDBContext(DbContextOptions<SkillDBContext> options):base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var skillLevelOneData = GetSkillLevelOneData();
            modelBuilder.Entity<SkillLevelOne>()
                .HasData(skillLevelOneData);
            base.OnModelCreating(modelBuilder);

            var skillLevelTwoData = GetSkillLevelTwoData();
            modelBuilder.Entity<SkillLevelTwo>()
               .HasData(skillLevelTwoData);
            base.OnModelCreating(modelBuilder);


            var skillLevelThreeData = GetSkillLevelThreeData();
            modelBuilder.Entity<SkillLevelThree>()
                .HasData(skillLevelThreeData);

            modelBuilder.Entity<SkillLevelThree>()
                .Property(s => s.SkillAdoptionId).HasDefaultValue(1);


            base.OnModelCreating(modelBuilder);

            var skillAdoptionData = GetSkillAdoptionData();
            modelBuilder.Entity<SkillAdoption>()
                .HasData(skillAdoptionData);
            base.OnModelCreating(modelBuilder);

        }

        private List<SkillAdoption> GetSkillAdoptionData()
        {
            List<SkillAdoption> skillAdoptionList = new List<SkillAdoption>()
            {
                new SkillAdoption { SkillAdoptionId=1, SkillAdoptionLevel=1, SkillAdoptionName="Adopt", SkillAdoptionDescription="Actively use this tech" },
                new SkillAdoption { SkillAdoptionId=2, SkillAdoptionLevel=2, SkillAdoptionName="Trail", SkillAdoptionDescription="Use in a Siloed Project or Team" },
                new SkillAdoption { SkillAdoptionId=3, SkillAdoptionLevel=3, SkillAdoptionName="Spike", SkillAdoptionDescription="Do a POC on the tech to check viability or use" },
                new SkillAdoption { SkillAdoptionId=4, SkillAdoptionLevel=4, SkillAdoptionName="Heap",  SkillAdoptionDescription="POC didn't work or considering using later" },
          
            };

            return skillAdoptionList;
        }

        private List<SkillLevelOne> GetSkillLevelOneData()
        {
            List<SkillLevelOne> skillLevelOneList = new List<SkillLevelOne>()
            {
                new SkillLevelOne { SkillLevelOneId=1, SkillLevelOneName="Data - Stores and Managment", Description="Cause Data is important" },
                new SkillLevelOne { SkillLevelOneId=2, SkillLevelOneName="Infra & Devops", Description="Build, Deploy & Manage" },
                new SkillLevelOne { SkillLevelOneId=3, SkillLevelOneName="Tools, Lanaguages and Frameworks", Description="Man created fire then kept on going" },
                new SkillLevelOne { SkillLevelOneId=4, SkillLevelOneName="Methodolgies / Ways of working", Description="How we work" },
            };

            return skillLevelOneList;
        }

 


        private List<SkillLevelTwo> GetSkillLevelTwoData()
        {
            List<SkillLevelTwo> skillLevelTwoList = new List<SkillLevelTwo>()
            {
                new SkillLevelTwo {SkillLevelTwoId=1, SkillLevelTwoName= "Relational", Description= "Relational data stores", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=2, SkillLevelTwoName= "Document", Description= "Document based stores", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=3, SkillLevelTwoName= "Graph", Description= "Graph Databases", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=4, SkillLevelTwoName= "InMemory(Cache)", Description= "Used for rapid reads to frontend or apps", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=5, SkillLevelTwoName= "Storage", Description= "mass file system storages", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=6, SkillLevelTwoName= "Deployment Tools & Methods", Description= "Devops deployment", SkillLevelOneId=2},
                new SkillLevelTwo {SkillLevelTwoId=7, SkillLevelTwoName= "IaC", Description= "Infrastructure as Code", SkillLevelOneId=2},
                new SkillLevelTwo {SkillLevelTwoId=8, SkillLevelTwoName= "Version Control", Description= "used to versions controll code", SkillLevelOneId=2},
                new SkillLevelTwo {SkillLevelTwoId=10, SkillLevelTwoName= "Analysis Tools", Description= "Tools used for analyics and models", SkillLevelOneId=3},
                new SkillLevelTwo {SkillLevelTwoId=11, SkillLevelTwoName= "Analysis Methods", Description= "methods for building models and analysing", SkillLevelOneId=3},
                new SkillLevelTwo {SkillLevelTwoId=12, SkillLevelTwoName= "BI", Description= "BI tooling to vizualise data", SkillLevelOneId=3},
                new SkillLevelTwo {SkillLevelTwoId=13, SkillLevelTwoName= "ETL Tooling", Description= "Extract Transform Load", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=14, SkillLevelTwoName= "Messaging busses", Description= "Real Time and Message Brokering", SkillLevelOneId=1},
                new SkillLevelTwo {SkillLevelTwoId=15, SkillLevelTwoName= "Browser Based Front End", Description= "Frontend Dev in Browser", SkillLevelOneId=3},
                new SkillLevelTwo {SkillLevelTwoId=16, SkillLevelTwoName= "Language", Description= "Company X will tend to support these languages as 1st tier", SkillLevelOneId=3},
                new SkillLevelTwo {SkillLevelTwoId=17, SkillLevelTwoName= "Testing", Description= "Types of testing", SkillLevelOneId=4},
            };
            return skillLevelTwoList;
        }

        private List<SkillLevelThree> GetSkillLevelThreeData()
        {
            List<SkillLevelThree> skillList = new List<SkillLevelThree>()
            {
                new SkillLevelThree {SkillLevelThreeId=1, SkillLevelThreeName= "Postgres" , Description= "PlaceHolder" ,SkillLevelTwoId=1, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=2, SkillLevelThreeName= "Azure SQL (Sql server)" , Description= "PlaceHolder" ,SkillLevelTwoId=1, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=3, SkillLevelThreeName= "Aurora (MySQL Postgres)" , Description= "PlaceHolder" ,SkillLevelTwoId=1, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=4, SkillLevelThreeName= "Cosmos" , Description= "PlaceHolder" ,SkillLevelTwoId=2, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=5, SkillLevelThreeName= "MongoDB" , Description= "PlaceHolder" ,SkillLevelTwoId=2, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=6, SkillLevelThreeName= "Neo4J" , Description= "PlaceHolder" ,SkillLevelTwoId=3, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=7, SkillLevelThreeName= "Neptune" , Description= "PlaceHolder" ,SkillLevelTwoId=3, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=8, SkillLevelThreeName= "Dynamo" , Description= "PlaceHolder" ,SkillLevelTwoId=4, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=9, SkillLevelThreeName= "Reddis" , Description= "PlaceHolder" ,SkillLevelTwoId=4, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=10, SkillLevelThreeName= "S3" , Description= "PlaceHolder" ,SkillLevelTwoId=5, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=11, SkillLevelThreeName= "Azure storage accounts" , Description= "PlaceHolder" ,SkillLevelTwoId=5, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=12, SkillLevelThreeName= "CodePipeline" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=13, SkillLevelThreeName= "Steps" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=14, SkillLevelThreeName= "CodeCommit" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=15, SkillLevelThreeName= "Cloud Formation" , Description= "PlaceHolder" ,SkillLevelTwoId=7, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=16, SkillLevelThreeName= "Cloud Watch" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=17, SkillLevelThreeName= "Azure Devops" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=18, SkillLevelThreeName= "ARM templating" , Description= "PlaceHolder" ,SkillLevelTwoId=7, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=19, SkillLevelThreeName= "Azure Montoring" , Description= "PlaceHolder" ,SkillLevelTwoId=6, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=21, SkillLevelThreeName= "Terraform" , Description= "PlaceHolder" ,SkillLevelTwoId=7, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=20, SkillLevelThreeName= "Git" , Description= "PlaceHolder" ,SkillLevelTwoId=8, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=22, SkillLevelThreeName= "Databricks" , Description= "PlaceHolder" ,SkillLevelTwoId=10, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=23, SkillLevelThreeName= "REPLs such as jupyterlabs" , Description= "PlaceHolder" ,SkillLevelTwoId=10, ImgPath="images/temp1.png"},
                new SkillLevelThree {SkillLevelThreeId=24, SkillLevelThreeName= "SageMaker" , Description= "PlaceHolder" ,SkillLevelTwoId=10, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=25, SkillLevelThreeName= "AzureML" , Description= "PlaceHolder" ,SkillLevelTwoId=10, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=26, SkillLevelThreeName= "Basic Stats" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=27, SkillLevelThreeName= "Linear Algebra" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=28, SkillLevelThreeName= "Basyean Stats" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=29, SkillLevelThreeName= "Unstructured clustering" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=30, SkillLevelThreeName= "Neural Nets" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=31, SkillLevelThreeName= "SVM" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=32, SkillLevelThreeName= "Graph Theroy" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png" , SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=33, SkillLevelThreeName= "Recommendation Engines" , Description= "PlaceHolder" ,SkillLevelTwoId=11, ImgPath="images/temp1.png" , SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=34, SkillLevelThreeName= "PowerBI" , Description= "PlaceHolder" ,SkillLevelTwoId=12, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=35, SkillLevelThreeName= "Tableau" , Description= "PlaceHolder" ,SkillLevelTwoId=12, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=36, SkillLevelThreeName= "Spark" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=37, SkillLevelThreeName= "Glue" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=38, SkillLevelThreeName= "DataFactory" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=39, SkillLevelThreeName= "EMR" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=40, SkillLevelThreeName= "Keniesis or Kafka" , Description= "PlaceHolder" ,SkillLevelTwoId=14, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=41, SkillLevelThreeName= "Azure EventHub" , Description= "PlaceHolder" ,SkillLevelTwoId=14, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=42, SkillLevelThreeName= "Azure IOT" , Description= "PlaceHolder" ,SkillLevelTwoId=14, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=43, SkillLevelThreeName= "Steps" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=44, SkillLevelThreeName= "Lambda" , Description= "PlaceHolder" ,SkillLevelTwoId=13, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=45, SkillLevelThreeName= "React" , Description= "PlaceHolder" ,SkillLevelTwoId=15, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=46, SkillLevelThreeName= "D3" , Description= "PlaceHolder" ,SkillLevelTwoId=15, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=47, SkillLevelThreeName= "Python" , Description= "PlaceHolder" ,SkillLevelTwoId=15, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=48, SkillLevelThreeName= "Scala" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=49, SkillLevelThreeName= "C#" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=50, SkillLevelThreeName= "SQL" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=51, SkillLevelThreeName= "Bash" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=52, SkillLevelThreeName= "Powershell" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=53, SkillLevelThreeName= "Javascript" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=1},
                new SkillLevelThree {SkillLevelThreeId=54, SkillLevelThreeName= "GO" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=55, SkillLevelThreeName= "Kotlin" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=56, SkillLevelThreeName= "Java" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=57, SkillLevelThreeName= "C++" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=58, SkillLevelThreeName= "C" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=4},
                new SkillLevelThree {SkillLevelThreeId=59, SkillLevelThreeName= "Haskell" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=60, SkillLevelThreeName= "VBA" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=61, SkillLevelThreeName= "Pascal/Delphi" , Description= "PlaceHolder" ,SkillLevelTwoId=16, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=62, SkillLevelThreeName= "Unit testing" , Description= "PlaceHolder" ,SkillLevelTwoId=17, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=63, SkillLevelThreeName= "Intergration Testing" , Description= "PlaceHolder" ,SkillLevelTwoId=17, ImgPath="images/temp1.png", SkillAdoptionId=3},
                new SkillLevelThree {SkillLevelThreeId=64, SkillLevelThreeName= "ETL Testing" , Description= "PlaceHolder" ,SkillLevelTwoId=17, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=65, SkillLevelThreeName= "Functional Testing" , Description= "PlaceHolder" ,SkillLevelTwoId=17, ImgPath="images/temp1.png", SkillAdoptionId=2},
                new SkillLevelThree {SkillLevelThreeId=66, SkillLevelThreeName= "BDD" , Description= "PlaceHolder" ,SkillLevelTwoId=17, ImgPath="images/temp1.png", SkillAdoptionId=2}
            };

            return skillList;
        
        }

    }
}
