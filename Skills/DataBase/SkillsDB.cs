using Skills.Models;
using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Skills.DataBase
{
    public class SkillsDB
    {

        //static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        //{
        //    return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        //});

        //static SQLiteAsyncConnection Database => lazyInitializer.Value;
        //static bool initialized = false;
        public SQLiteConnection connection { get; set; }
        public SkillsDB()
        {
            // InitializeAsync().SafeFireAndForget(false);
            InitializeAsync();
        }

         void InitializeAsync()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<Skill>(CreateFlags.None);
            //if (!initialized)
            //{
            //    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Skill).Name))
            //    {
            //        await Database.CreateTablesAsync(CreateFlags.None, typeof(Skill)).ConfigureAwait(false);
            //    }
            //    initialized = true;
            //}
        }
    }
}
