using Skills.Models;
using System.Collections.Generic;

namespace Skills.Services
{
    public interface ISkillService
    {
        List<Skill> GetAllSkills();
        void AddSkill(Skill Skill);
        void UpdateSkill(Skill Skill);
    }
}
