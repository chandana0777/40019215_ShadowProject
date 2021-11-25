using ProjectBL;
using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");

            
            BL blObj = new BL();
           
          
            Console.WriteLine("Enter the First name:");
            string Username = Console.ReadLine();
            
            Console.WriteLine("Enter the mobile number");
            string Password = Console.ReadLine();


            DTO newBrObj = new DTO()
            {
               
                
                UserName = Username,
                Password = Password
               
            };

            int Val = blObj.UserLogin(newBrObj);
            if (Val == 1)
            {
                Console.WriteLine(" user Exist");

            }

        
            else
            {
                Console.WriteLine(Val);


            }





            BL blobj = new BL();
            var Product = blobj.GetAllProduct();
            foreach (var prod in Product)
            {
                Console.WriteLine(prod.Id + "|" +prod.ProductName + "|" + prod.Price );
            }



            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Update Department");
            Console.WriteLine("Enter department ID name and price");
            string Id = Console.ReadLine();
            string Name = Console.ReadLine();
            string Price = Console.ReadLine();
            ProductDTO DptObj = new ProductDTO()
            {
                Id = Convert.ToInt32(Id),
                ProductName = Name,
                Price = Price
            };
            int retValue = blObj.UpdateProd(DptObj);
            if (retValue == 1)
            {
                Console.WriteLine("Department updated successfully");
            }
            
            
            else
            {
                Console.WriteLine("No Department exits with ID " + Id);
            }




            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Insert New Department");
            Console.WriteLine("Enter department name and department group name");
            string pName = Console.ReadLine();
            string price = Console.ReadLine();
            ProductDTO DeptObj = new ProductDTO()
            {
                ProductName = pName,
                Price = price
            };
            int retVal = blObj.InsertProd(DeptObj);
            if (retVal == 1)
            {
                Console.WriteLine("Department has been added successfully");
            }
         
            else
            {
                Console.WriteLine("Something went wrong");
            }
            Console.WriteLine("----------------------------------------------------");
        }
    }
    
}
