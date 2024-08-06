using Microsoft.AspNetCore.Mvc;
using Reeltimechat.Models;
using System.Diagnostics;


namespace Reeltimechat.Controllers
{
    public class HomeController : Controller
    {
        
        dataController database=new dataController();
            public IActionResult Index()
            {
          
                return View();
           
            
            }
        public IActionResult kayýtol()
        {
            return View();
        }
        public IActionResult kullanýcýekle(kisiler kayýt)
        {
            database.useradd(kayýt.kad, kayýt.Pass);


            return View("Index");
        }

        public static string kullanýcýadý;
        [HttpPost]
        public IActionResult giris(kisiler veri)
        {
            string Giris = database.usercontrol(veri.kad,veri.Pass);
            if(Giris== "Baþarýlý")
            {
                kullanýcýadý = veri.kad;
                birles modelverisis = new birles();
                dataController database = new dataController();

                var data = database.veri();
                modelverisis.lista = data;
                return View("../mesajlar/mesajlar",modelverisis);

            }

            return View("Index");





        }

        public IActionResult mesajat(string kad,string mesaj)
        {
            return View();
        }



    }
}
