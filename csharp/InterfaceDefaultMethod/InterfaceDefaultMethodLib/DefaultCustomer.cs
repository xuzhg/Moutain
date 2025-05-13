namespace InterfaceDefaultMethodLib
{
    public class DefaultCustomer(string name, DateOnly birthday) : ICustomer
    {
        public string Name { get; } = name;

        public DateOnly Birthday { get; } = birthday;

        public override string ToString()
        {
            return $"{Name}: 'DEFAULT'\n\t|-Birthday at: {Birthday}\n";
        }

        //public void Display() => Console.WriteLine("Default");

         public virtual string GetDisplay() => "Default";
    }
}

// 1

// IEdmEntityType
//    EdmEntityType