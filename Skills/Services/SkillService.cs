using Skills.Models;
using System.Collections.Generic;

namespace Skills.Services
{
    public class SkillService : ISkillService
    {
        public void AddSkill(Skill Skill)
        {
            SkillRepo.AddSkill(Skill);
        }
        public List<Skill> GetAllSkills()
        {
            return SkillRepo.skills?? new List<Skill>();
        }
        public void UpdateSkill(Skill Skill)
        {
            SkillRepo.UpdateSkill(Skill);
        }
    }
}
