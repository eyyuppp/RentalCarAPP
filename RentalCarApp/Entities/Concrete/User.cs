using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User :IEntity
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }  

        //enum sınıfı oluşturduktan sonra propunu oluşturabiliirsin aksi halde hata alırsın dikkat et!
        public MyEnum? UserCinsiyet { get; set; }

    }

    public enum MyEnum
    {
        MALE = 0,
        FEMALE = 1
    }
}
