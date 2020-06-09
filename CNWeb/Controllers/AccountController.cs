using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.MOD;

namespace CNWeb.Controllers
{
    public class AccountController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();

        protected void setAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;

            if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }


        public int check(CUSTOMER acc)
        {
            var resultEmail = db.CUSTOMERs.Where(p => p.CustomerUsername == acc.CustomerUsername && p.CustomerPassword == acc.CustomerPassword).FirstOrDefault();
            if (resultEmail != null)
            {
                return 1;
            }
            else
            {
                var checkEmail = db.CUSTOMERs.Where(p => p.CustomerUsername == acc.CustomerUsername).FirstOrDefault();
                if (checkEmail != null)
                {
                    return -1; // sai pass
                }
                else
                    return 0;// sai email
            }
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CUSTOMER Cus, CustomerDB CusDB)
        {
            var check = db.CUSTOMERs.Where(p => p.CustomerUsername == Cus.CustomerUsername).FirstOrDefault();
            if (check == null)
            {
                 Cus.CustomerUsername = CusDB.UserName;
                 Cus.CustomerPassword = CusDB.PassWord;
                 if(CusDB.RePassword == CusDB.PassWord)
                {
       
                    Cus.CustomerName = CusDB.FullName;
                    Cus.CustomerEmail = CusDB.Email;
                    Cus.CreatedDate = null;
                    Cus.CustomerPhone = CusDB.Phone;
                    Cus.CustomerAdress = null;
                    db.CUSTOMERs.Add(Cus);
                    db.SaveChanges();
                    return RedirectToAction("Index", "nhap1");
                }
                else
                {
                    setAlert("Xac nhan mat khau sai !", "warning");
                    return View("Index");
                }
                 
            }
            else
            {
                setAlert("Tai khoan da ton tai", "error");
                return View("Index");
            }
                      //return View("Index", CusDB)    
        }


        public ActionResult profile()
        {
            if (Session["Customer"] == null)
            {
                return PartialView("_menuDefault");
            }
            else
            {
                return PartialView("_menuInfor");
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CustomerDB login, CUSTOMER Acc)
        {
            Acc.CustomerPassword= login.PassWord;
            Acc.CustomerUsername = login.UserName;
            int checkAcc = check(Acc);
            if (checkAcc == 1)
            {
                var temp = db.CUSTOMERs.Where(p => p.CustomerUsername == login.UserName).FirstOrDefault();
                login.ID = temp.CustomerID;
                login.FullName = temp.CustomerName;
                login.UserName = temp.CustomerUsername;
                
                Session["Customer"] = login;

                setAlert("dang nhap thanh cong", "success");
                return RedirectToAction("Index", "Shop");
            }
            else if (checkAcc == -1)
            {
                setAlert("sai mat khau", "error");
                return View("Login");
            }
            else
            {
                setAlert("khong ton tai tai khoan", "error");
                return View("Login");
            }
        }


      


        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}