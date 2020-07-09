using MiniShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniShop.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
