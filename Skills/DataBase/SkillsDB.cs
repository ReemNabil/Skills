using Skills.Models;
using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.DataBase
{
    public class SkillsDB
    {
        public SQLiteConnection connection { get; set; }
        public SkillsDB()
        {
            InitializeAsync();
        }

         void InitializeAsync()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<Skill>(CreateFlags.None);
            connection.CreateTable<MediaItemToUpload>(CreateFlags.None);

        }
    }
}
