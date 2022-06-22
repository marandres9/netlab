using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;
using TP07MVC.Common.Exceptions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace TP07MVC.Logic
{
    public class TerritoriesLogic: BaseLogic, ICRUDLogic<TerritoryDto, string>
    {
        private readonly string _tableName = "Territories";
        public TerritoryDto Add(TerritoryDto newEntity)
        {
            // La tabla Territories no tiene ID autoincremental, hay que checkear que el nuevo ID no este ocupado
            if(Exists(newEntity.TerritoryID))
            {
                throw new IDAlreadyTakenException($"Object with ID {newEntity.TerritoryID} already exists in table {_tableName}");
            }
            try
            {
                var newTerr = _context.Territories.Add(new Territories(newEntity));
                _context.SaveChanges();
                return new TerritoryDto(newTerr);
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
            // RegionID property is a foreign key to the Region table, if left empty or invalid, a DbUpdateException is thrown
            catch(DbUpdateException)
            {
                throw new InvalidForeignKeyException($"Missing or invalid foreign key for field {nameof(newEntity.RegionID)}");
            }
        }

        public void Delete(string id)
        {
            try
            {
                _context.Territories.Remove(GetEntity(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        private Territories GetEntity(string id)
        {
            var territory = _context.Territories.Find(id);
            if(territory == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return territory;
        }

        public TerritoryDto Get(string id)
        {
            return new TerritoryDto(GetEntity(id));
        }

        public bool Exists(string id)
        {
            return _context.Territories.Any(t => t.TerritoryID == id);
        }

        public TerritoryDetailsDto GetDetails(string id)
        {
            var terr = GetEntity(id);
            string regionDesc = _context.Region.First(r => r.RegionID == terr.RegionID).RegionDescription;

            return new TerritoryDetailsDto
            {
                TerritoryID = terr.TerritoryID,
                TerritoryDescription = terr.TerritoryDescription,
                Region = regionDesc
            };
        }

        public List<TerritoryDto> GetAll()
        {
            return _context.Territories.Select(t => new TerritoryDto
            {
                TerritoryID = t.TerritoryID,
                TerritoryDescription = t.TerritoryDescription,
                RegionID = t.RegionID
            }).ToList();
        }

        public TerritoryDto Update(TerritoryDto newEntity)
        {
            Territories entityToUpdate = GetEntity(newEntity.TerritoryID);
            entityToUpdate.TerritoryDescription = newEntity.TerritoryDescription;
            entityToUpdate.RegionID = newEntity.RegionID;
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
            catch(DbUpdateException)
            {
                throw new InvalidForeignKeyException($"Missing or invalid foreign key for field {nameof(newEntity.RegionID)}");
            }
        }

        // Debo sobrecargar este metodo ya que deberia poder actualizar el campo RegionID opcionalmente,
        // dependiendo de si se recibe un int o un null. A diferencia de las otras entidades,
        // cuyos campos son todos de tipo string y cuentan con el metodo IsNullOrEMpty(), el campo RegionID
        // solo puede tomar valores numericos. En este caso si el usuario decide no cambiar el campo,
        // este metodo recibe un null y dicho campo no se actualiza en la base de datos
        public void Update(string territoryID, string territoryDesciption, int? regionID)
        {
            Territories entityToUpdate = GetEntity(territoryID);
            bool isnull = string.IsNullOrEmpty(territoryDesciption);
            if(!isnull)
            {
                entityToUpdate.TerritoryDescription = territoryDesciption;
            }
            if(regionID != null)
            {
                entityToUpdate.RegionID = (int) regionID;
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
