using System;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
            bl.StartProcess();
        }
        public static void bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }
    }
    public class ProcessBusinessLogic
    {
        // declaring an event using built-in EventHandler
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted(EventArgs.Empty); //No event data
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
