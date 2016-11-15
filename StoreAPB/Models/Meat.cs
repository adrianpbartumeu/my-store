using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreAPB.Models
{
    public class Meat : Product
    {
        /*public enum Type
        {Cow, Pig, Chicken, Calf, Sheep, Lamb}*/
        //En inglés se emplean distintas palabras para referirse al animal y a la carne que se obtiene del mismo, 
        //p. ej. del cerdo (pig) se obtiene pork; 
        //de la vaca (cow), beef; 
        //del ternero (calf), veal, 
        //y de la oveja o carnero (sheep), mutton. 
        //Lamb constituye la excepción a esta regla, ya que designa tanto al animal (el cordero) como a la carne que de él se obtiene.

        [Required]
        [Display(Name = "Provider")]
        public String provider { get; set; }
    }
}