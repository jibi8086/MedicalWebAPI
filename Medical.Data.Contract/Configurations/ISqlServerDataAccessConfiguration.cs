using System;
using System.Collections.Generic;
using System.Text;

namespace IVOAI.Data.Contract.Configurations
{
    public interface ISqlServerDataAccessConfiguration
    {
        IConnectionStringConfiguration ConnectionStrings { get; }
    }
}
