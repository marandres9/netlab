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

namespace TP07MVC.Logic
{
    public class ShippersLogic: BaseLogic, ICRUDLogic<Shippers, int>
    {
        private readonly string _tableName = "Shippers";

        public ShippersLogic()
        { }
        public ShippersLogic(NorthwindContext context) : base(context)
        { }

        public void Add(Shippers newEntity)
        {
            try
            {
                _context.Shippers.Add(newEntity);
                _context.SaveChanges();
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
                _context.Shippers.Remove(Get(id));
                _context.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                throw new TriedDeletingReferencedForeignKeyException($"Can't delete object with ID {id} of table {_tableName} because it is referenced by another table with a foreign key", e);
            }
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public Shippers Get(int id)
        {
            Shippers shipper = _context.Shippers.Find(id);
            if(shipper == null)
            {
                throw new IDNotFoundException($"Object with ID {id} not found in table {_tableName}");
            }
            return shipper;
        }

        public bool Exists(int id)
        {
            return _context.Shippers.Any(t => t.ShipperID == id);
        }

        public void Update(Shippers newEntity)
        {
            Shippers entityToUpdate = Get(newEntity.ShipperID);
            if(!string.IsNullOrEmpty(newEntity.CompanyName))
            {
                entityToUpdate.CompanyName = newEntity.CompanyName;
            }
            if(!string.IsNullOrEmpty(newEntity.Phone))
            {
                entityToUpdate.Phone = newEntity.Phone;
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
