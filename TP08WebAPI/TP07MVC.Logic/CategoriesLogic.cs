using System.Collections.Generic;
using System.Linq;
using TP07MVC.Entity;
using TP07MVC.Common.Exceptions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using TP07MVC.Entity.DTO;
using System;

namespace TP07MVC.Logic
{
    public class CategoriesLogic: BaseLogic, ICRUDLogic<Categories, CategoryDto, int>
    {
        private readonly string _tableName = "Categories";

        public CategoryDto Add(CategoryDto newEntity)
        {
            try
            {
                var newCategory = _context.Categories.Add(new Categories(newEntity));
                _context.SaveChanges();
                return new CategoryDto(newCategory);
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

        public void Delete(int id)
        {
            try
            {
                _context.Categories.Remove(GetEntity(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        public CategoryDto Get(int id)
        {
            return new CategoryDto(GetEntity(id));
        }
        public List<CategoryDto> GetList()
        {
            return _context.Categories.Select(c => new CategoryDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();
        }

        public IEnumerable<CategoryDto> GetList(Func<Categories, bool> filter)
        {
            return _context.Categories.Where(filter).Select(c => new CategoryDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            });
        }

        public List<CategoryDto> GetList(Func<Categories, bool> filter)
        {
            return _context.Categories.Where(filter).Select(c => new CategoryDto
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();
        }

        public List<CategoryDto> GetList(string filterString)
        {
            return GetList(c => c.CategoryName.ToLower().Contains(filterString.ToLower()));
        }

        private Categories GetEntity(int id)
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

        public CategoryDto GetDetails(int id)
        {
            var cat = GetEntity(id);

            return new CategoryDto(cat);
        }

        public CategoryDto Update(CategoryDto newEntity)
        {
            Categories entityToUpdate = GetEntity(newEntity.CategoryID);
            entityToUpdate.CategoryName = newEntity.CategoryName;
            entityToUpdate.Description = newEntity.Description;
            try
            {
                _context.SaveChanges();
                return newEntity;
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
