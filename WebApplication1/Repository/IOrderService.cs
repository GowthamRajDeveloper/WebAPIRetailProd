using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRetailProduct.Model;

namespace WebAPIRetailProduct.Repository
{
  public  interface IOrderService
    {
        ResponseData SaveOrderDetails(TblProductOrderEntry indtls);
    }
}
