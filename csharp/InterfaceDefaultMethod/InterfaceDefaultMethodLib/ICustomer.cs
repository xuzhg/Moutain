namespace InterfaceDefaultMethodLib
{
    public interface ICustomer
    {
        string Name { get; }

        DateOnly Birthday { get; }

        #region Methods
        // void Display();

        string Tile { get => "AntTime";  }

        public string GetDisplay() => "ICustomer";
        #endregion
    }
}
