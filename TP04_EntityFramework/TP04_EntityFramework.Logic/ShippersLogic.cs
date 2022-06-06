using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04_EntityFramework.Entity;

namespace TP04_EntityFramework.Logic
{
    public class ShippersLogic: BaseLogic, ICRUDLogic<Shippers>
    {
        public void Add(Shippers newEntity)
        {
            _context.Shippers.Add(newEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Shippers.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Shippers> GetAll()
        {
            return _context.Shippers.ToList();
        }

        public Shippers GetById(int id)
        {
            return _context.Shippers.Find(id);
        }

        public void Update(Shippers newEntity)
        {
            Shippers shipperToUpdate = GetById(newEntity.ShipperID);
            shipperToUpdate.CompanyName = newEntity.CompanyName;
            shipperToUpdate.Phone = newEntity.Phone;
        }
    }
}
