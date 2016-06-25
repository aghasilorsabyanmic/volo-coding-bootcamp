using EventsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start();
            }
            catch
            {
                
            }
        }

        private static void Start()
        {
            var hp = new Printer();

            hp.PrintStarted += Hp_PrintStarted;
            hp.PrintFinished += Hp_PrintFinished;
            hp.Printing += Hp_Printing;
            hp.PrintFailed += Hp_PrintFailed;

            try
            {
                hp.AddPapers(4);
                hp.Print(2);
                hp.Print(3);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine($"Opps! Wront argument {exception.ParamName}.{Environment.NewLine}Message: {exception.Message}");
                throw new Exception("",exception);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void Hp_PrintFailed(object sender, PrintFailedEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name}: Print failed. Remaining {e.RemainingPages} pages");
        }

        private static void Hp_Printing(object sender, PrintingEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name}: Printing page N{e.CurrentPage}");
        }

        private static void Hp_PrintFinished(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name}: Print Finished");
        }

        private static void Hp_PrintStarted(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name}: Print Started");
        }
    }
}
