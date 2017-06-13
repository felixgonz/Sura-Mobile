﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFPCapital.Movil.Dependency
{
    public interface IStorageManager
    {
        SQLiteConnection GetConnection();
    }
}
