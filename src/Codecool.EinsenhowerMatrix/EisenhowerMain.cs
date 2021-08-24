using System;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Main class for program
    /// </summary>
    public class EisenhowerMain
    {
        private bool _cmd = true;

        /// <summary>
        /// Runs program with basic user UI
        /// </summary>
        public void Run()
        {
            TodoMatrix todoMatrix = new TodoMatrix();
            todoMatrix.AddItem("cím", new DateTime(2021, 08, 25), true);
            todoMatrix.AddItem("cím", new DateTime(2021, 08, 26), true);
            do
            {
                Console.Clear();
                Console.WriteLine("[ 1 ] Display all quarter");
                Console.WriteLine("[ 2 ] Display specific quarter");
                Console.WriteLine("[ 3 ] Create task");
                Console.WriteLine("[ 4 ] Delete task");
                Console.WriteLine("[ 5 ] Archive all tasks");
                Console.WriteLine();
                Console.WriteLine("[ 0 ] Exit program");

                int option;
                bool inputIsValid = int.TryParse(Console.ReadLine(), out option);
                if (inputIsValid)
                {
                    switch (option)
                    {
                        case 0:
                            _cmd = false;
                            break;
                        case 2:
                            // TodoMatrix todoMatrix = new TodoMatrix();
                            Console.WriteLine(todoMatrix.GetSpecificQuarter(TodoMatrix.QuarterTypes.UrgentAndImportant));
                            Console.ReadKey();
                            break;
                    }
                }
            }
            while (_cmd);
        }
    }
}
