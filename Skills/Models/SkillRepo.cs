using Skills.DataBase;
using System.Collections.Generic;

namespace Skills.Models
{
    public static class SkillRepo
    {
        //gereric repo
        public static List<Skill> skills;
        static SkillRepo()
        {
            if (skills == null)
            {
                var db = new SkillsDB().connection;
                skills = db.Table<Skill>().ToList();
                RunSeedData();
            }
        }

        public static void RunSeedData() 
        {
            var db = new SkillsDB().connection;
            skills = db.Table<Skill>().ToList();
            if (skills.Count == 0)
            {
                var skillsList = new List<Skill>() 
                {
                 new Skill(){ Id=1 , Proficiencylevel=50 , SkillDescription= "description0",Skillname = "Communication"},
                 new Skill(){ Id=2 , Proficiencylevel=70 , SkillDescription= "description1",Skillname = "Teamwork"},   
                 new Skill(){ Id=3 , Proficiencylevel=89 , SkillDescription= "description2",Skillname = "Problem-solving"},
                 new Skill(){ Id=4 , Proficiencylevel=90 , SkillDescription= "description3",Skillname = "Responsibility"},
                };
                db.InsertAll(skillsList);

            }
        }
        public static void AddSkill(Skill skill)
        {
            // App class shouldn't refernce here 
            var db = App.dataBase.connection;
            db.Insert(skill);
        }

        public static void UpdateSkill(Skill skill)
        {
            var db = App.dataBase.connection;
            db.Update(skill);
        }

    }
}
