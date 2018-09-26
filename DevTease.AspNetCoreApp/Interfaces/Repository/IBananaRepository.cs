using DevTease.AspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTease.AspNetCoreApp.Interfaces.Repository
{
    public interface IBananaRepository
    {
        Banana GetBanana();
    }
}
