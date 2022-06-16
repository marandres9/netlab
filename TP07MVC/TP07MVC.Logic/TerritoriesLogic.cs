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
    public class TerritoriesLogic: BaseLogic, ICRUDLogic<Territories, string>
    {
        private readonly string _tableName = "Territories";
        public void Add(Territories newEntity)
        {
            // La tabla Territories no tiene ID autoincremental, hay que checkear que el nuevo ID no este ocupado
            if(_context.Territories.Any(t => t.TerritoryID.Equals(newEntity.TerritoryID)))
            {
                throw new IDAlreadyTakenException($"Object with ID {newEntity.TerritoryID} already exists in table {_tableName}");
            }
            try
            {
                _context.Territories.Add(newEntity);
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

        public void Delete(string id)
        {
            try
            {
                _context.Territories.Remove(GetById(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it referenced by another table with a foreign key", e);
            }
        }

        public Territories GetById(string id)
        {
            var territory = _context.Territories.Find(id);
            if(territory == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return territory;
        }

        public List<Territories> GetAll()
        {
            return _context.Territories.ToList();
        }

        public void Update(Territories newEntity)
        {
            Territories entityToUpdate = GetById(newEntity.TerritoryID);
            entityToUpdate.TerritoryDescription = newEntity.TerritoryDescription;
            entityToUpdate.RegionID = newEntity.RegionID;

            _context.SaveChanges();
        }

        // Debo sobrecargar este metodo ya que deberia poder actualizar el campo RegionID opcionalmente,
        // dependiendo de si se recibe un int o un null. A diferencia de las otras entidades,
        // cuyos campos son todos de tipo string y cuentan con el metodo IsNullOrEMpty(), el campo RegionID
        // solo puede tomar valores numericos. En este caso si el usuario decide no cambiar el campo,
        // este metodo recibe un null y dicho campo no se actualiza en la base de datos
        public void Update(string territoryID, string territoryDesciption, int? regionID)
        {
            Territories entityToUpdate = GetById(territoryID);
            bool isnull = string.IsNullOrEmpty(territoryDesciption);
            if(!isnull)
            {
                entityToUpdate.TerritoryDescription = territoryDesciption;
            }
            if(regionID != null)
            {
                entityToUpdate.RegionID = (int) regionID;
            }
            _context.SaveChanges();
        }
    }
}
