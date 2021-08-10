using System;

namespace Assignment1
{
    public class InputProcessor
    {
        private readonly IValidationChoice _validationChoice;
        private readonly IValidationDate _validationDate;
        private readonly ILogger _logger;
        private readonly ILogger _fileLogger;

        public InputProcessor(IValidationChoice validationChoice, IValidationDate validationDate, ILogger logger, ILogger fileLogger)
        {
            _validationChoice = validationChoice;
            _validationDate = validationDate;
            _logger = logger;
            _fileLogger = fileLogger;
        }

        public void Process()
        {
            string idob, ch, continueChoice;
            int choice;
            do
            {
                Console.WriteLine("-----------------------------------------------------------------------------------\n");
                do
                {
                    Console.WriteLine("Enter date of birth (Format: YYYY-MM-DD):");
                    idob = Console.ReadLine().Trim();


                    if (_validationDate.IsValidDate(idob))
                        break;
                    else
                    {
                        _logger.LogError("Invalid DOB!");
                        _fileLogger.LogError("Invalid DOB!");
                    }

                } while (true);

                do
                {
                    MainController controller = null;
                    bool flag = false;
                    do
                    {
                        Console.WriteLine("Enter choice:");
                        Console.WriteLine("1 for sun sign");
                        Console.WriteLine("2 for horoscope");
                        Console.WriteLine("3 for end application");
                        ch = Console.ReadLine().Trim();

                        if (_validationChoice.IsValidChoice(ch))
                        {
                            choice = int.Parse(ch);
                            flag = false;
                        }
                        else
                        {
                            _logger.LogError("Invalid choice!");
                            _fileLogger.LogError("Invalid choice!");
                            flag = true;
                            continue;
                        }

                        switch (choice)
                        {
                            case 1:
                                controller = new MainController(new SunSign(_logger) { DOB = idob });
                                break;
                            case 2:
                                controller = new MainController(new Horoscope(_logger, _fileLogger) { DOB = idob });
                                break;
                            case 3:
                                _logger.LogInfo("Ending application...");
                                Environment.Exit(0);
                                break;
                            //case 4:
                            //    controller = new MainController(new AgeCalculator(_logger) { DOB = idob });
                            //    break;
                            default:
                                _logger.LogError("Invalid choice!");
                                _fileLogger.LogError("Invalid choice!");
                                flag = true;
                                break;
                        }
                        if (!flag)
                            controller.DisplayResult();
                    } while (flag);

                    Console.WriteLine("Enter 1 to continue with same date");
                    Console.WriteLine("Enter 2 to continue with new date");
                    Console.WriteLine("Enter any other key to exit");
                    continueChoice = Console.ReadLine().Trim();

                } while (continueChoice == "1");
                
            } while (continueChoice == "2");
            _logger.LogInfo("Ending application...");
        }
    }
}
