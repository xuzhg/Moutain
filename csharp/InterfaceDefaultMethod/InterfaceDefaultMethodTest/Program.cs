// See https://aka.ms/new-console-template for more information


using InterfaceDefaultMethodLib;
using InterfaceDefaultMethodTest;

ICustomer peter = new DefaultCustomer("Peter", new DateOnly(2000, 1, 1));
Console.WriteLine(peter);

ICustomer kelly = new VipCustomer("Kelly", new DateOnly(2000, 1, 1), 1.9);
Console.WriteLine(kelly);

ICustomer apple = new MyCustomer("Apple", new DateOnly(2000, 1, 1), "abc@gmail.com");
Console.WriteLine(apple);

IList<ICustomer> list = [peter, kelly, apple];

apple.Name

Console.WriteLine("===");
//foreach (ICustomer custom in list)
//{
//    custom.Display();
//}

foreach (ICustomer customer in list)
{
    Console.WriteLine(customer.GetDisplay());
}

//MyCustomer vipCustomer = kelly as VipCustomer;
//Console.WriteLine(vipCustomer.GetDisplay());

//MyCustomer myCustomer = apple as MyCustomer;
//Console.WriteLine(myCustomer.GetDisplay());