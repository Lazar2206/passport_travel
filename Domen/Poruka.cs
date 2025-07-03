using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Poruka
    {
        //ono što se šalje
        public Object Object { get; set; }
        //sta radimo a tim što je poslato
        public Operacija Operacija { get; set; }
    }
    public enum Operacija
    {
        Login, Uspesno,
        Neuspesno, Register,
        Logout,
        ScheduleTrip,
        DeleteTrip,
        ChangeTrip
    }
}
