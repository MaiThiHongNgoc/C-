using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2
{
    public interface IProductRepository
    {
        void Create(Product product);
        Product Read(int id);
        void Update(Product product);
        List<Product> GetAll();
        void Delete(int id);
    }
}