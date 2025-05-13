using InterfaceDefaultMethodLib;
using System.Threading.Channels;

namespace InterfaceDefaultMethodTest
{
    public class MyCustomer(string name, DateOnly birthday, string email) : ICustomer
    {
        public string Name { get; } = name;

        public DateOnly Birthday { get; } = birthday;

        public string Email { get; } = email;

        public override string ToString()
        {
            return $"{Name}: 'MY'\n\t|-Birthday at: {Birthday}\n\t|-Email: {Email}\n";
        }

    }
}
