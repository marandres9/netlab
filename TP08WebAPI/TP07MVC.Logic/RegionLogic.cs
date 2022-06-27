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
    public class RegionLogic: BaseLogic, ICRUDLogic<Region, RegionDto, int>
    {
        private readonly string _tableName = "Region";
        public RegionDto Add(RegionDto newEntity)
        {
            // La tabla Region no tiene ID autoincremental, hay que checkear que el nuevo ID no este ocupado
            if(Exists(newEntity.RegionID))
            {
                throw new IDAlreadyTakenException($"Object with ID {newEntity.RegionID} already exists in table {_tableName}");
            }
            try
            {
                var newRegion = _context.Region.Add(new Region(newEntity));
                _context.SaveChanges();
                return new RegionDto(newRegion);
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
                _context.Region.Remove(GetEntity(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        public RegionDto Get(int id)
        {
            return new RegionDto(GetEntity(id));
        }
        public List<RegionDto> GetList()
        {
            return _context.Region.Select(r => new RegionDto
            {
                RegionID = r.RegionID,
                RegionDescription = r.RegionDescription
            }).ToList();
        }

        public IEnumerable<RegionDto> GetList(Func<Region, bool> filter)
        {
            return _context.Region.Where(filter).Select(r => new RegionDto
            {
                RegionID = r.RegionID,
                RegionDescription = r.RegionDescription,
            });
        }

        public List<RegionDto> GetList(Func<Region, bool> filter)
        {
            return _context.Region.Where(filter).Select(r => new RegionDto
            {
                RegionID = r.RegionID,
                RegionDescription = r.RegionDescription,
            }).ToList();
        }

        public List<RegionDto> GetList(string filterString)
        {
            return GetList(r => r.RegionDescription.ToLower().Contains(filterString.ToLower()));
        }
        private Region GetEntity(int id)
        {
            Region reg = _context.Region.Find(id);
            if(reg == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return reg;
        }

        public bool Exists(int id)
        {
            return _context.Region.Any(r => r.RegionID == id);
        }

        public RegionDetailsDto GetDetails(int id)
        {
            var region = GetEntity(id);
            var territoryDescriptions = _context.Territories.Where(t => t.RegionID == region.RegionID).Select(t => t.TerritoryDescription).ToList();

            return new RegionDetailsDto
            {
                RegionID = region.RegionID,
                RegionDescription = region.RegionDescription,
                Territories = territoryDescriptions
            };
        }

        public RegionDto Update(RegionDto newEntity)
        {
            Region entityToUpdate = GetEntity(newEntity.RegionID);
            entityToUpdate.RegionDescription = newEntity.RegionDescription;
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
