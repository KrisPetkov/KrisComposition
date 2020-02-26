using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IRepository
    {
        User GetUserById(int id);
    }
}
