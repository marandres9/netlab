using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Common.Exceptions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace TP07MVC.Logic
{
    public class RegionLogic: BaseLogic, ICRUDLogic<Region, int>
    {
        private readonly string _tableName = "Region";
        public void Add(Region newEntity)
        {
            // La tabla Region no tiene ID autoincremental, hay que checkear que el nuevo ID no este ocupado
            if(_context.Region.Any(r => r.RegionID.Equals(newEntity.RegionID)))
            {
                throw new IDAlreadyTakenException($"Object with ID {newEntity.RegionID} already exists in table {_tableName}");
            }
            try
            {
                _context.Region.Add(newEntity);
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

        public void Delete(int id)
        {
            try
            {
                _context.Region.Remove(GetById(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it referenced by another table with a foreign key", e);
            }
        }

        public List<Region> GetAll()
        {
            return _context.Region.ToList();
        }

        public Region GetById(int id)
        {
            Region reg = _context.Region.Find(id);
            if(reg == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return reg;
        }

        public void Update(Region newEntity)
        {
            Region entityToUpdate = GetById(newEntity.RegionID);
            if(!string.IsNullOrEmpty(newEntity.RegionDescription))
            {
                entityToUpdate.RegionDescription = newEntity.RegionDescription;
            }
            _context.SaveChanges();
        }
    }
}
