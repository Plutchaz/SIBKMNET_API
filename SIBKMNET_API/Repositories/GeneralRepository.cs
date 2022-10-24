using SIBKMNET_API.Context;
using SIBKMNET_API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Repositories
{
    public class GeneralRepository<Entity> : IGeneralRepository<Entity>
        where Entity : class
    {
        MyContext myContext;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Set<Entity>().Find(id);//cara get data gunakan generic
            myContext.Set<Entity>().Remove(data);
            var result =  myContext.SaveChanges();
            return result;
        }

        public List<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }

        public Entity Get(int id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }

        public int Post(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
