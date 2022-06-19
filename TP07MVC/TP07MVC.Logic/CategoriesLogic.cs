using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Common.Exceptions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace TP07MVC.Logic
{
    public class CategoriesLogic: BaseLogic, ICRUDLogic<Categories, int>
    {
        private readonly string _tableName  = "Categories";

        public void Add(Categories newEntity)
        {
            try
            {
                _context.Categories.Add(newEntity);
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                string msg = "";
                foreach(var entityValidationErrors in e.EntityValidationErrors)
                {
                    foreach(var validationError in entityValidationErrors.ValidationErrors)
                    {
                        msg += ("Error: " + validationError.ErrorMessage + "\n");
                    }
                    throw new EntityFailedValidationException(msg, e);
                }
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Categories.Remove(GetById(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            Categories cat = _context.Categories.Find(id);
            if(cat == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return cat;
        }

        public bool Exists(int id)
        {
            return _context.Categories.Any(t => t.CategoryID == id);
        }

        public void Update(Categories newEntity)
        {
            Categories entityToUpdate = GetById(newEntity.CategoryID);
            if(!string.IsNullOrEmpty(newEntity.CategoryName))
            {
                entityToUpdate.CategoryName = newEntity.CategoryName;
            }
            if(!string.IsNullOrEmpty(newEntity.Description))
            {
                entityToUpdate.Description = newEntity.Description;
            }

            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException e)
            {
                string msg = "";
                foreach(var entityValidationErrors in e.EntityValidationErrors)
                {
                    foreach(var validationError in entityValidationErrors.ValidationErrors)
                    {
                        msg += ("Error: " + validationError.ErrorMessage + "\n");
                    }
                }
                throw new EntityFailedValidationException(msg, e);
            }
        }
    }
}
