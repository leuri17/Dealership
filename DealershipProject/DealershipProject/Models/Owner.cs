using Npgsql.Internal.TypeHandlers;

namespace DealershipProject.Models
{
    public class Owner
    {
        private UuidHandler Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string DriverLicense { get; set; }
    }
}
