using Skills.Models;
using Skills.Repositories;
using System.Collections.Generic;

namespace Skills.Services
{
    public class SkillService : ISkillService
    {
        IRepository<Skill> _repository = new Repository<Skill>();
        public SkillService() { RunSeedData(); }
        public void AddSkill(Skill skill)
        {
            _repository.Insert(skill);
        }
        public List<Skill> GetAllSkills()
        {
            return _repository.Queryable()?? new List<Skill>();

        }
        public void UpdateSkill(Skill skill)
        {
            _repository.Update(skill);
        }

        public  void RunSeedData()
        {
         
           var  skills = _repository.Queryable();
            if (skills.Count == 0)
            {
                var skillsList = new List<Skill>()
                {
                 new Skill(){ Id=1 , Proficiencylevel=50 , SkillDescription= "description0",Skillname = "Communication"},
                 new Skill(){ Id=2 , Proficiencylevel=70 , SkillDescription= "description1",Skillname = "Teamwork"},
                 new Skill(){ Id=3 , Proficiencylevel=89 , SkillDescription= "description2",Skillname = "Problem-solving"},
                 new Skill(){ Id=4 , Proficiencylevel=90 , SkillDescription= "description3",Skillname = "Responsibility"},
                };
                _repository.InsertAll(skillsList);

            }
        }
    }
}
