using Skills.DataBase;
using Skills.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skills.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public static List<TEntity> entities;
    
        public void Insert(TEntity entity)
        {
            var connection = App.dataBase.connection;
            connection.Insert(entity);
        }

        public List<TEntity> Queryable()
        {
            if (entities == null)
            {
                var connection = App.dataBase.connection;
                entities = connection.Table<Skill>().ToList() as List<TEntity>;
            }
            return entities;
        }

        public void Update(TEntity entity)
        {
            var db = App.dataBase.connection;
            db.Update(entity);
        }

        public void InsertAll(List<TEntity> entities)
        {
            var db = App.dataBase.connection;
            db.InsertAll(entities);
        }
    }
}
