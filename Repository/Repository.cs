﻿using Microsoft.EntityFrameworkCore;
using Migrations;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal AppDbContext context;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

        }
        public bool Create(T entity)
        {
            bool status = dbSet.Add(entity) != null;
            context.SaveChanges();
            return status;
        }

        public bool Delete(T entity)
        {
            var t = FindById(entity.Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }
            var status = dbSet.Remove(t) != null;
            return status;
        }

       

        public T FindById(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public bool Update(T entity)
        {
            if (FindById(entity.Id) != null)
            {
                var status = dbSet.Update(entity) != null;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return status;
            }
            return false;
        }
    }
}
