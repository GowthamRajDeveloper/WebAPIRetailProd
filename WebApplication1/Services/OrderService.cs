using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRetailProduct.Model;
using WebAPIRetailProduct.Repository;

namespace WebAPIRetailProduct.Services
{
    public class OrderService : IOrderService
    {
        ResponseData IOrderService.SaveOrderDetails(TblProductOrderEntry indtls)
        {
            ResponseData rsltout = new ResponseData();
            try
            {

                using (var context = new RetailProductsDataContext())
                {
                    var productfilterdata = context.TblProductDetails
                                       .Where(s => s.ProductId == indtls.ProductId)
                                       .FirstOrDefault();
                    if (productfilterdata==null)
                    {
                        rsltout.Success = false;
                        rsltout.Message = "Please check with product ID : Not exist";
                    }

                    else
                    {
                        Nullable<long> avilableQuantity = productfilterdata.ProductQuantityAvilable;

                        Nullable<long> totalavilableQuantity = productfilterdata.ProductQuantityAvilable - indtls.OrderQuantity;

                        if (totalavilableQuantity < 0)
                        {
                            rsltout.Success = false;
                            rsltout.Message = "Order Placed Failed: Due to Stock Unavailable";
                        }
                        else
                        {
                            var std = new TblProductOrderEntry()
                            {

                                OrderId = "ORD" + DateTime.Now.Hour.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString(),
                                //ProductId = DateTime.Now.Second+  DateTime.Now.Millisecond+ DateTime.Now.Minute,
                                OrderQuantity = indtls.OrderQuantity,
                                ProductId = indtls.ProductId,
                                OrderStatus = indtls.OrderStatus

                            };
                            context.TblProductOrderEntry.Add(std);

                            // or
                            // context.Add<Student>(std);

                         //   context.SaveChanges();
                            rsltout.Success = true;
                            rsltout.Message = "Successfully Add New Order";

                            
                            productfilterdata.ProductId = indtls.ProductId;
                            
                            
                            productfilterdata.ProductQuantityAvilable = totalavilableQuantity;
                             // context.TblProductDetails.Update(productfilterdata);
                            context.SaveChanges();
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;

                rsltout.Success = false;
                rsltout.Message = "Something Went Wrong!!";
            }
            return rsltout;
        }
    }
}
