using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using aspnet_web_api.Models;

namespace aspnet_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OgrenciController : ControllerBase {

        static List<Ogrenci> ogrenciler = new List<Ogrenci>{
            new Ogrenci {Id=1, AdSoyad="Batuhan"},
            new Ogrenci {Id=2, AdSoyad="Talha Tarık"},
            new Ogrenci {Id=3, AdSoyad="Murat"},
        };

        
        [HttpGet]
        public List<Ogrenci> Get () {

            return ogrenciler;

        }
            
        [HttpGet("{id}")] 
        public Ogrenci Get(int id) {
            return ogrenciler.FirstOrDefault(o => o.Id == id);
        }


       [HttpPost]
       public Ogrenci Post(Ogrenci ogrenci){
        ogrenciler.Add(ogrenci);
        return ogrenci;
       }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ogrenci = ogrenciler.FirstOrDefault(o => o.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            ogrenciler.Remove(ogrenci);
            return Ok(ogrenci);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Ogrenci updatedOgrenci)
        {
            var ogrenci = ogrenciler.FirstOrDefault(o => o.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            ogrenci.AdSoyad = updatedOgrenci.AdSoyad;
            return Ok(ogrenci);
        }

    }

}