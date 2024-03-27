namespace Quartica.Web.Service.DdContextConfiguration
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.SaveChanges();
        }
    }
}
