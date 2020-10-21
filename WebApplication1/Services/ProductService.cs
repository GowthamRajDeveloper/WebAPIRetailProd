using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRetailProduct.Repository;
using WebAPIRetailProduct.Model;

namespace WebAPIRetailProduct.Services
{
    public class ProductService : IProductService
    {
        public ResponseData DeleteProductDetails(String ProductID)
        {
            ResponseData rsltout = new ResponseData();
            try
            {

                // var context = new RetailProductsDataContext();
                //var productfilterdata = context.TblProductDetails
                //                    .Where(s => s.ProductId == indtls.ProductId)
                //                    .FirstOrDefault();

                using (var context = new RetailProductsDataContext())
                {
                    var productfilterdata = context.TblProductDetails
                                        .Where(s => s.ProductId == ProductID)
                                        .FirstOrDefault();
                    if (productfilterdata == null)
                    {
                        rsltout.Success = false;
                        rsltout.Message = "Please check with product ID : Not exist";
                    }
                    else
                    {
                        productfilterdata.ProductId = ProductID;
                        context.TblProductDetails.Remove(productfilterdata);
                        // context.TblProductDetails.Update(productfilterdata);
                        context.SaveChanges();
                        //await context.SaveChangesAsync();
                        rsltout.Success = true;
                        rsltout.Message = "Successfully Delete Product";
                    }
                }

            }
            catch (Exception)
            {

                rsltout.Success = false;
                rsltout.Message = "Something Went Wrong!!";
            }
            return rsltout;

        }

        public ResponseData SaveProductDetails(TblProductDetails indtls)
        {
            ResponseData rsltout = new ResponseData();
            try
            {

                using (var context = new RetailProductsDataContext())
                {
                    var std = new TblProductDetails()
                    {

                        ProductId= "PRD"+DateTime.Now.Hour.ToString()+ DateTime.Now.Millisecond.ToString()+ DateTime.Now.Second.ToString()+ DateTime.Now.Day.ToString(),
                        //ProductId = DateTime.Now.Second+  DateTime.Now.Millisecond+ DateTime.Now.Minute,
                        ProductName = indtls.ProductName,
                        ProductDescription = indtls.ProductDescription,
                        Cost = indtls.Cost,
                        Weight = indtls.Weight,
                        ProductQuantityAvilable = indtls.ProductQuantityAvilable
                    };
                    context.TblProductDetails.Add(std);

                    // or
                    // context.Add<Student>(std);

                    context.SaveChanges();
                    rsltout.Success = true;
                    rsltout.Message = "Successfully Add New Product";
                }
               
            }
            catch (Exception)
            {


                rsltout.Success = false;
                rsltout.Message = "Something Went Wrong!!";
            }
            return rsltout;
        }

        public ResponseData UpdateProductDetails(TblProductDetails indtls)
        {
            ResponseData rsltout = new ResponseData();
            try
            {
                
               // var context = new RetailProductsDataContext();
                //var productfilterdata = context.TblProductDetails
                //                    .Where(s => s.ProductId == indtls.ProductId)
                //                    .FirstOrDefault();
               
                using (var context = new RetailProductsDataContext())
                {
                    var productfilterdata = context.TblProductDetails
                                        .Where(s => s.ProductId == indtls.ProductId)
                                        .FirstOrDefault();
                    if (productfilterdata == null)
                    {
                        rsltout.Success = false;
                        rsltout.Message = "Please check with product ID : Not exist";
                    }
                    else
                    {
                        productfilterdata.ProductId = indtls.ProductId;
                        productfilterdata.ProductName = indtls.ProductName;
                        productfilterdata.ProductDescription = indtls.ProductDescription;
                        productfilterdata.ProductQuantityAvilable = indtls.ProductQuantityAvilable;
                        productfilterdata.Cost = indtls.Cost;
                        productfilterdata.Weight = indtls.Weight;
                        // context.TblProductDetails.Update(productfilterdata);
                        context.SaveChanges();
                        //await context.SaveChangesAsync();
                        rsltout.Success = true;
                        rsltout.Message = "Successfully Update Product";
                    }
                }
               
            }
            catch (Exception)
            {
                
                rsltout.Success = false;
                rsltout.Message = "Something Went Wrong!!";
            }
            return rsltout;


        }
    }
}
