using ProjectDAL;
using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBL
{
    public class BL
    {
        DAL dalObj;
        public int UserLogin(DTO custObj)
        {
            dalObj = new DAL();
            return dalObj.UserLogin(custObj);
        }

        public List<ProductDTO> GetAllProduct()
        {
            dalObj = new DAL();
            return dalObj.FetchAllProducts();
        }

        public int UpdateProd(ProductDTO deptObj)
        {
            dalObj = new DAL();
            return dalObj.UpdateProduct(deptObj);
        }
        public int InsertProd(ProductDTO deptObj)
        {
            dalObj = new DAL();
            return dalObj.InsertNewProduct(deptObj);
        }

        public int DeleteProd(int id )
        {
            dalObj = new DAL();
            return dalObj.DeleteProduct(id);
        }

    }
}
