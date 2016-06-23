using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsLib
{
    public class PrintingEventArgs : EventArgs
    {
        public int CurrentPage { get; set; }
    }

    public class PrintFailedEventArgs : EventArgs
    {
        public int RemainingPages { get; set; }
    }

    public class Printer
    {
        public event EventHandler PrintStarted;
        public event EventHandler PrintFinished;
        public event EventHandler<PrintingEventArgs> Printing;
        public event EventHandler<PrintFailedEventArgs> PrintFailed;

        private void OnPrintStarted()
        {
            Thread.Sleep(1000);
            PrintStarted?.Invoke(this, EventArgs.Empty);
        }

        private void OnPrintFinished()
        {
            Thread.Sleep(1000);
            PrintFinished?.Invoke(this, EventArgs.Empty);
        }

        private void OnPrinting(int current)
        {
            var args = new PrintingEventArgs { CurrentPage = current };
            Printing?.Invoke(this, args);
            Thread.Sleep(1500);
        }

        private void OnPrintFailed(int remaining)
        {
            Thread.Sleep(3000);
            var args = new PrintFailedEventArgs { RemainingPages = remaining };
            PrintFailed?.Invoke(this, args);
        }

        public int PapersQuantity { get; private set; }

        public void AddPapers(int papersCount)
        {
            if (papersCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(papersCount),
                    $"The argument {nameof(papersCount)} should be not negative.");
            }

            PapersQuantity += papersCount;
        }

        public void Print(int pagesCount)
        {
            if (pagesCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pagesCount),
                    $"The argument {nameof(pagesCount)} should be greather than 0.");
            }

            OnPrintStarted();

            for (int i = 1; i <= pagesCount; i++)
            {
                if (PapersQuantity != 0)
                {
                    OnPrinting(i);
                    PapersQuantity--;
                }
                else
                {
                    OnPrintFailed(pagesCount - i + 1);
                    break;
                }
            }

            OnPrintFinished();
        }
    }
}
