
using MVC.Models;
using ProjectBL;
using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddProduct(Product pobj)
        {
            try
            {
               BL blObj = new BL();
                ProductDTO newpdtObj = new ProductDTO();

                newpdtObj.Id = pobj.ID;
                newpdtObj.ProductName = pobj.ProductName;
                newpdtObj.Price = pobj.Price;
                int result = blObj.InsertProd(newpdtObj);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product added successfully!!";
                    return RedirectToAction("ViewProduct");


                }

                else
                {
                    return View("CreateProduct");
                }

            }
            catch (Exception )
            {
                return View("Error");
            }

        }


        [HttpGet]
        public ActionResult Edit()
        {
           
            





            return View();





        }


        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            try
            {
                BL blObj = new BL();
                ProductDTO newDto = new ProductDTO();

                newDto.Id = p.ID;
                newDto.ProductName = p.ProductName;
                newDto.Price = p.Price;
                



                int result = blObj.UpdateProd(newDto);
                if (result == 1)
                {
                    TempData["AlertMessage"] = "Product updated successfully.";
                    return RedirectToAction("ViewProduct");
                }
                else
                {
                    return View("Edit");
                }

            }
            catch (Exception)
            {

                return ViewBag("ERROR");
            }





        }

        [HttpGet]
        public ActionResult ViewProduct()

        {
            List<Product> lst = new List<Product>();
            BL blObj = new BL();
            var result = blObj.GetAllProduct();
            foreach (var item in result)
            {
                lst.Add(new Product()
                {
                    
                    ID =item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price



                });
            }

            return View(lst);
        }
        


        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User newdept)
        {
            try
            {
                BL blObj = new BL();
                DTO newDto = new DTO();

                newDto.UserName = newdept.UserName;
                newDto.Password = newdept.Password;

                int result = blObj.UserLogin(newDto);
                if (result == 1)
                {
                    
                    return RedirectToAction("ViewProduct");
                }
                else
                {
                    TempData["AlertMessage"] = "Incorrect Password.";
                    return View("Login");
                }

            }
            catch (Exception)
            {

                return ViewBag("ERROR");
            }





        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            BL blObj = new BL();
            int result = blObj.DeleteProd(Id);
            if (result == 1)
            {
                TempData["testmsg"] = "<script>alert('Requested Successfully ');</script>";
                return RedirectToAction("ViewProduct");
            }
            else
            {
                return View("Login");
            }


            

        }



        [HttpGet]
        public ActionResult update(int id)
        {
           
            
            int r = id;
            BL blObj = new BL();
            ProductDTO newDto = new ProductDTO();
            newDto.Id = id;
            return View(r);



        }


       



    }
}
