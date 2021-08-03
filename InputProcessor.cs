﻿using System;

namespace Assignment1
{
    public class InputProcessor
    {
        private readonly IValidation _validation;
        private readonly ILogger _logger;

        public InputProcessor(IValidation validation, ILogger logger)
        {
            _validation = validation;
            _logger = logger;
        }

        public void Process()
        {
            string idob, ch, continueChoice;
            int choice;
            do
            {
                _logger.LogPrint("\n\n");
                do
                {
                    _logger.LogPrint("Enter date of birth (Format: YYYY-MM-DD):");
                    idob = Console.ReadLine();


                    if (_validation.IsValidDate(idob))
                        break;
                    else
                        _logger.LogError("Invalid DOB!");

                } while (true);

                MainController controller = null;
                bool flag = false;
                do
                {
                    _logger.LogPrint("Enter choice:");
                    _logger.LogPrint("1 for sun sign");
                    _logger.LogPrint("2 for horoscope");
                    _logger.LogPrint("3 for end application");
                    ch = Console.ReadLine();

                    if (_validation.IsValidChoice(ch))
                    {
                        choice = int.Parse(ch);
                        flag = false;
                    }
                    else
                    {
                        _logger.LogError("Invalid choice!");
                        flag = true;
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            controller = new MainController(new SunSign(_logger) { DOB = idob });
                            break;
                        case 2:
                            controller = new MainController(new Horoscope(_logger) { DOB = idob });
                            break;
                        case 3:
                            _logger.LogInfo("Ending application...");
                            Environment.Exit(0);
                            break;
                        default:
                            _logger.LogError("Invalid choice!");
                            flag = true;
                            break;
                    }
                    if(!flag)
                        controller.DisplayResult();
                    
                } while (flag);

                _logger.LogPrint("Enter 1 to continue: ");
                continueChoice = Console.ReadLine();

            } while (continueChoice == "1");
            _logger.LogInfo("Ending application...");
        }
    }
}