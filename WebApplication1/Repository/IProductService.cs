using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRetailProduct.Model;

namespace WebAPIRetailProduct.Repository
{
    public interface IProductService
    {
        ResponseData SaveProductDetails(TblProductDetails indtls);
        ResponseData UpdateProductDetails(TblProductDetails indtls);
        ResponseData DeleteProductDetails(String ProductID);

    }
}
