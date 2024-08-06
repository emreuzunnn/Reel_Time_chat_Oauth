using Microsoft.AspNetCore.SignalR;
using Reeltimechat.Controllers;
using Reeltimechat.Models;

namespace Reeltimechat.Hubs
{
    public class ChatHub : Hub
    {

        public async Task message_send(string kullanıcıAdı, string kadDeğeri, string mesajveri)
        {
            mesajlarController veri=new mesajlarController();
            birles clas=new birles();
            Mesaj mesajverisi=new Mesaj(); mesajverisi.mesaj = mesajveri;
            mesajverisi.kad=kadDeğeri; 
            clas.message = mesajverisi;
            
            veri.mesajat(clas);

          
            
            await Clients.All.SendAsync("yenimesaj", kullanıcıAdı, kadDeğeri, mesajveri);
            Console.WriteLine("istek");
        }
    }
}
