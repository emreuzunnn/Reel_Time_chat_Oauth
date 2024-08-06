using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Reeltimechat.Models;

namespace Reeltimechat.Controllers
{
    public class dataController : Controller
    {
        SqlConnection bag = new SqlConnection("Server=EMRE;Database=data;Trusted_Connection=True; TrustServerCertificate=True;");
        SqlCommand komut = new SqlCommand();
       public dataController() { komut.Connection = bag; }
        public String useradd(string kad, string pass)
        {
            #region veri ekle
            try
            {
                bag.Open();
                komut.CommandText = "insert into users (kad,pass) values('" + kad + "','" + pass + "')";
                komut.ExecuteNonQuery();
                return "Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            finally { bag.Close(); }
            #endregion
        }

        public bool mesaj(string gonderenkad, string gidenkad,string mesaj) 
        {
            bool trufalse=false;
            bag.Open();
            try
            {
                komut.CommandText = "insert into message(gonderenkad,gidenkad,mesaj)values('" + gonderenkad + "','" + gidenkad + "','" + mesaj + "')";

                komut.ExecuteNonQuery();
                trufalse =true;
            }catch(Exception e) { string hat = e.Message; }
            
            finally
            {
                bag.Close();
            }
            return trufalse;
            
        }

        public List<mesajoku> veri()
        {
            bag.Open();
            List<mesajoku> veri = new List<mesajoku>();
            mesajoku returnvalue = new mesajoku();
            komut.CommandText = "select * from message where gidenkad ='"+HomeController.kullanıcıadı+"'";
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                returnvalue.gonderen = oku["gonderenkad"].ToString();
                returnvalue.iletilen = oku["gidenkad"].ToString();
                returnvalue.mesaj = oku["mesaj"].ToString();
                veri.Add(returnvalue);
            }
            bag.Close();
            return veri;

        }

        public String usercontrol(string kad, string pass)
        {

            bool vari = false;
            
                bag.Open();
                komut.CommandText = "select * from users where kad='"+kad+"'";
              
            SqlDataReader oku =komut.ExecuteReader();
            while (oku.Read()) 
            {
                if (oku["pass"].ToString().Trim()==pass)
                    vari = true;

            }bag.Close();




            if (vari)
            {
                return "Başarılı";
            }
            else
                return "Başarısız";

                
            
           
        }
    }
}
