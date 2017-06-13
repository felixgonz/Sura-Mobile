using AFPCapital.Movil.Storage;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Models
{
    public class LoginModel: BaseViewModel
    {
        public StorageManager DataBase { get; private set; }

        public LoginModel()
        {
            DataBase = new StorageManager();
        }

    }
}
