using DevTease.AspNetCoreApp.Interfaces.Repository;
using DevTease.AspNetCoreApp.Models;

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
