using Microsoft.AspNetCore.Mvc;
using Reeltimechat.Models;

namespace Reeltimechat.Controllers
{
    public class mesajlarController : Controller
    {


        public IActionResult mesajlar()
        {
           
          
            return View();
        }

        [HttpPost]
        public IActionResult mesajat(birles veri)
        {
            
            dataController database = new dataController();
           var deger = database.mesaj(HomeController.kullanıcıadı, veri.message.kad,veri.message.mesaj);

                       var data = database.veri();
            veri.lista = data;
            return View("mesajlar", veri);
        }

        

    }
}
