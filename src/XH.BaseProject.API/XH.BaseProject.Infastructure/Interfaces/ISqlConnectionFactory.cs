using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace XH.BaseProject.Infastructure.Interfaces
{
   public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
