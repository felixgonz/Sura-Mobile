using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AFPCapital.Movil.Models
{
    public class ListActionModel
    {
        public ListActionType Action { get; set; }
        public ImageSource Image { get; set; }
        public string Display { get; set; }
        public int Count { get; set; }
    }

    public enum ListActionType
    {
        None,
        BlockedContact,
        Message,
        Logout,
        Info,
        EmergencyPhone,
        Subsidiary
    }
}
