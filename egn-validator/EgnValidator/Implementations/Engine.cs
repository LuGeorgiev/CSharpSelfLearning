using EgnValidator.Services;
using EgnValidator.Services.Infrastructure;
using System;
using static EgnValidator.Constants.Global;

namespace EgnValidator.Implementations
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IValidateEgn validator;

        public Engine(IWriter writer, IReader reader, IValidateEgn validator)
        {
            this.writer = writer;
            this.reader = reader;
            this.validator = validator;
        }

        public void Run()
        {
            this.writer.WriteLine("Please, enter your unique Bulgarian Id (EGN)");
            while (true)
            {
                try
                {
                    var egn = this.reader.ReadLine();
                    var resultMsg = this.validator.IsValid(egn);

                    if (resultMsg == VALID_ID)
                    {
                        break;
                    }
                    this.writer.WriteLine($"{resultMsg} and try again!");                

                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"Error 500 :) Please, try again!");

                    //TODO implement logger IF needed
                    //LOG ex.msg
                }
            }

            this.writer.Write("Thank you, your id was valid");
        }
    }
}
