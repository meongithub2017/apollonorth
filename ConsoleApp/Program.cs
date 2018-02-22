using System;
namespace ApolloNorth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----C# Vending Machine Assignment -----");
            Console.WriteLine("");
    
            //Declare and Instantiate VendingMachine Object
            VendingMachine vm = new VendingMachine(25,250);
            Console.WriteLine(vm.ToString());
            
            //Run till Exit        
            while (true)
            {
                try
                {
                    Console.Write("Buy Drink (press Y) / Exit (press 99) : ");
                    var inputValue = Console.ReadLine();

                    if (!inputValue.Equals("Y", StringComparison.InvariantCultureIgnoreCase)
                        && !inputValue.Equals("99", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Invalid Option. Try again");
                    }
                    else if (inputValue.Equals("99"))
                    {
                        Console.WriteLine("Exiting the program.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        while (true)
                        {
                            Console.Write("Please Enter Card Pin (01234/56789) : ");
                            vm.SuppliedPin = Console.ReadLine();

                            var isValid = vm.ValidatePin();
                            if (isValid == "OK")
                            {
                                Console.WriteLine(vm.BuyDrink());
                                Console.WriteLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(isValid);
                                Console.WriteLine();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }                                
            }            
        }
    }    
}
