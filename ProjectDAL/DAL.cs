using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDAL
{
    public class DAL
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        public int UserLogin(DTO custObj)
        {
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            try
            {
                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_Userlogin";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;


                queryObj.Parameters.AddWithValue("@UserName", custObj.UserName);
                queryObj.Parameters.AddWithValue("@Password", custObj.Password);


                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conObj.Close();
            }
        }




        public List<ProductDTO> FetchAllProducts()
        {
            List<ProductDTO> lstProduct = new List<ProductDTO>();

            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            try
            {
                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"SELECT  Id ,ProductName ,ProductPrice FROM  Product_Details ";
                queryObj.CommandType = System.Data.CommandType.Text;
                queryObj.Connection = conObj;
                conObj.Open();
                SqlDataReader drProduct = queryObj.ExecuteReader();
                while (drProduct.Read())
                {
                    lstProduct.Add(new ProductDTO()
                    {
                         Id = Convert.ToInt32(drProduct["Id"]),
                        ProductName = drProduct["Productname"].ToString(),
                        Price = drProduct["ProductPrice"].ToString(),
                       

                    }
                    );
                }
                return lstProduct;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conObj.Close();
            }
        }

        public int UpdateProduct(ProductDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_UpdateProductDetail";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                queryObj.Parameters.AddWithValue("@Id", deptObj.Id);
                queryObj.Parameters.AddWithValue("@ProductName", deptObj.ProductName);
                queryObj.Parameters.AddWithValue("@Price", deptObj.Price);
                
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertNewProduct(ProductDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_INSERTINTOProductDetails";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
               
                queryObj.Parameters.AddWithValue("@ProductName", deptObj.ProductName);
                queryObj.Parameters.AddWithValue("@ProductPrice", deptObj.Price);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteProduct(int id)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_DeleteProductDetails";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;

                queryObj.Parameters.AddWithValue("@Id", id);
                
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
