using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class InputProcessor
    {
        private readonly IValidation _validation;

        public InputProcessor(IValidation validation)
        {
            _validation = validation;
        }

        public void Process()
        {
            string idob, ch, continueChoice;
            int choice;
            do
            {
                do
                {
                    Console.WriteLine("Enter date of birth (Format: YYYY-MM-DD):");
                    idob = Console.ReadLine();


                    if (_validation.IsValidDate(idob))
                        break;
                    else
                        Console.WriteLine("Invalid DOB!");

                } while (true);

                MainController controller = null;
                bool flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("Enter choice:");
                        Console.WriteLine("1 for sun sign");
                        Console.WriteLine("2 for horoscope");
                        Console.WriteLine("3 for end application");
                        ch = Console.ReadLine();

                        if (_validation.IsValidChoice(ch))
                            choice = int.Parse(ch);
                        else
                        {
                            Console.WriteLine("Invalid choice!");
                            flag = true;
                            continue;
                        }

                        switch (choice)
                        {
                            case 1:
                                controller = new MainController(new SunSign() { DOB = idob });
                                break;
                            case 2:
                                controller = new MainController(new Horoscope() { DOB = idob });
                                break;
                            case 3:
                                Console.WriteLine("Ending application...");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                flag = true;
                                break;
                        }
                        controller.DisplayResult();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    
                } while (flag);


                Console.WriteLine("Enter 1 to continue: ");
                continueChoice = Console.ReadLine();

            } while (continueChoice == "1");
            
        }
    }
}
