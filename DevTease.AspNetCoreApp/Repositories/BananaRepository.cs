using DevTease.AspNetCoreApp.Interfaces.Repository;
using DevTease.AspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTease.AspNetCoreApp.Repositories
{
    public class BananaRepository : IBananaRepository
    {
        public Banana GetBanana()
        {
            return new Banana
            {
                Color = 5,
                Curvature = 10,
                Length = 8
            };
        }
    }
}
