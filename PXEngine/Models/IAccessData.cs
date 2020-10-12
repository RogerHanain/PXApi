using DXProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXProject.Models
{
    public interface IAccessData
    {
        IPXDbContext ConnectToDB();
    }
}
