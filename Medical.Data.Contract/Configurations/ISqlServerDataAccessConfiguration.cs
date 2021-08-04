using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Data.Contract.Configurations
{
    public interface ISqlServerDataAccessConfiguration
    {
        IConnectionStringConfiguration ConnectionStrings { get; }
    }
}
