using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP05_Linq.Data;
using TP05_Linq.Entities;
using TP05_Linq.Entities.DTO;

namespace TP05_Linq.Logic
{
    public class ProductsLogic: BaseLogic
    {
        public List<Products> GetAll()
        {
            return _context.Products.ToList();
        }
        public List<Products> GetWithoutStock()
        {
            return _context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }
        // !!! revisar
        public List<Products> GetAllWithoutStock2()
        {
            return ProductsQueries.GetAllWhere(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> GetInStockWorthMoreThan(int price)
        {
            return _context.Products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > price).ToList();
        }

        public Products GetFirstOrDefaultByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Products> GetSortByName()
        {
            var query = from product in _context.Products
                        orderby product.ProductName
                        select product;
            return query.ToList();
        }

        public List<Products> GetSortByUnitsInStock()
        {
            var query = from product in _context.Products
                        orderby product.UnitsInStock descending
                        select product;
            return query.ToList();
        }

        public List<DTOProducts_Categories> GetWithCategories()
        {
            var query = from product in _context.Products
                        join category in _context.Categories
                        on product.CategoryID equals category.CategoryID
                        select new DTOProducts_Categories { ProductName = product.ProductName, CategoryName = category.CategoryName };
            return query.ToList();
        }
        public List<DTOProducts_Categories> GetWithCategories2()
        {
            return _context.Products.Select(p => new DTOProducts_Categories { ProductName = p.ProductName, CategoryName = p.Categories.CategoryName }).ToList();
        }

        public Products GetFirst(List<Products> list)
        {
            return list.FirstOrDefault();
        }
        public Products GetFirst(IQueryable<Products> queryable)
        {
            return queryable.FirstOrDefault();
        }
    }
}
