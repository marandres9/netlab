using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP07MVC.Entity;
using TP07MVC.Data;
using System.Data.Entity.Infrastructure;
using TP07MVC.Common.Exceptions;
using System.Data.Entity.Validation;
using TP07MVC.Entity.DTO;

namespace TP07MVC.Logic
{
    public class ShippersLogic: BaseLogic, IShippersLogic
    {
        private readonly string _tableName = "Shippers";

        public ShippersLogic(NorthwindContext context) : base(context)
        { }

        public ShipperDto Add(ShipperDto newEntity)
        {
            try
            {
                var newShipper = _context.Shippers.Add(new Shippers(newEntity));
                _context.SaveChanges();
                return new ShipperDto(newShipper);
            }
            catch(DbEntityValidationException e)
            {
                // si los campos de la entidad no son validos para la base de datos, se concatenan todos los 
                // mensajes de error en la variable 'msg' y luego se lo lanza en una nuevea  excepcion que 
                // le indica al usuario los campos que no pasaron la verificacion
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
                _context.Shippers.Remove(GetEntity(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        public ShipperDto Get(int id)
        {
            return new ShipperDto(GetEntity(id));
        }

        // !!!NOT USED
        public IEnumerable<ShipperDto> GetAll()
        {
            return _context.Shippers.Select(s => new ShipperDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            });
        }

        public List<ShipperDto> GetList()
        {
            return _context.Shippers.Select(s => new ShipperDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();
        }

        public List<ShipperDto> GetList(Func<Shippers, bool> filter)
        {
            return _context.Shippers.Where(filter).Select(s => new ShipperDto
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone
            }).ToList();
        }

        public List<ShipperDto> GetList(string filterString)
        {
            return GetList(s => s.CompanyName.ToLower().Contains(filterString.ToLower()));
        }

        private Shippers GetEntity(int id)
        {
            Shippers shipper = _context.Shippers.Find(id);
            if(shipper == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return shipper;
        }

        public ShipperDto GetDetails(int id)
        {
            var shipper = GetEntity(id);
            return new ShipperDto(shipper);
        }

        public bool Exists(int id)
        {
            return _context.Shippers.Any(t => t.ShipperID == id);
        }

        public ShipperDto Update(ShipperDto newEntity)
        {
            Shippers entityToUpdate = GetEntity(newEntity.ShipperID);
            entityToUpdate.CompanyName = newEntity.CompanyName;
            entityToUpdate.Phone = newEntity.Phone;
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
