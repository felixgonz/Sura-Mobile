using AFPCapital.Movil.Dependency;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AFPCapital.Movil.Storage
{
    public class StorageManager
    {
        SQLiteConnection db;

        public StorageManager()
        {
            db = DependencyService.Get<IStorageManager>().GetConnection();
            //db.DropTable<AccountStorage>();

            db.CreateTable<AccountStorage>();

            Init();
        }

        public void Init()
        {
            if (!string.IsNullOrWhiteSpace(App.UserProfile?.User))
            {

            }
        }

        #region AccountStorage

        public void SaveCuenta(AccountStorage cuenta)
        {
            var all = (from entry in db.Table<AccountStorage>().AsEnumerable<AccountStorage>()
                       where entry.AccountID == cuenta.AccountID
                       select entry).ToList();
            if (all.Count == 0)
            {
                db.DeleteAll<AccountStorage>();

                Guid key;
                if (string.IsNullOrWhiteSpace(cuenta.AccountID) || !Guid.TryParse(cuenta.AccountID, out key))
                {
                    cuenta.AccountID = Guid.NewGuid().ToString();
                }
                db.Insert(cuenta);
            }
            else
            {
                db.Update(cuenta);
            }
        }

        public IEnumerable<AccountStorage> GetCuentaAll()
        {
            return db.Table<AccountStorage>().AsEnumerable<AccountStorage>().ToList();
        }

        public AccountStorage GetCuenta(string accountID)
        {
            var result = (from entry in db.Table<AccountStorage>().AsEnumerable<AccountStorage>()
                          where entry.AccountID == accountID
                          select entry).FirstOrDefault();

            return result;
        }

        public int DeleteCuentaAll()
        {
            //db.DeleteAll<ProductSolicitudeStorage>();
            //db.DeleteAll<SolicitudStorage>();
            //db.DeleteAll<ProductStorage>();
            return db.DeleteAll<AccountStorage>();
        }

        #endregion
    }
}
