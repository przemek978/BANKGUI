using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK.Models
{
    [Table(name: "Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Pesel { get; set; }
        [Required]
        public string Password { get; set; }
        public int typeID { get; set; }

        public User()
        {

        }
        public User(int id,string Username, string Name, string Surname,string pesel, string Password,int typeID=1)
        {
            this.Id = id;
            this.Username = Username;
            this.Name = Name;
            this.SurName = Surname;
            this.Pesel = pesel;
            this.Password = Password;
            this.typeID = typeID; 
        }
        public override string ToString()
        {
            string type="User";
            if(typeID == 1)
            {
                type = "administrator";
            }
            return Id + " " + Name + " " + SurName + " Typ uprawnień: "+ type;
        }
        //public string Name { get { return Username; } }
    }
}
