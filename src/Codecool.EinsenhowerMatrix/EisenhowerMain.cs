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
                        case 1:
                            todoMatrix.ToString();
                            break;
                        case 2:
                            QuarterMenu(todoMatrix);
                            break;
                    }
                }
            }
            while (_cmd);
        }

        private static void QuarterMenu(TodoMatrix todoMatrix)
        {
            Console.WriteLine("[ 1 ] Urgent and Important");
            Console.WriteLine("[ 2 ] Not urgent and Important");
            Console.WriteLine("[ 3 ] Urgent and Not important");
            Console.WriteLine("[ 4 ] Not urgent and Not important");

            int optionQuarter;
            bool inputIsValidQuarter = int.TryParse(Console.ReadLine(), out optionQuarter);

            if (inputIsValidQuarter)
            {
                switch (optionQuarter)
                {
                    case 1:
                        Console.WriteLine(todoMatrix.GetSpecificQuarter(TodoMatrix.QuarterTypes.UrgentAndImportant));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine(todoMatrix.GetSpecificQuarter(TodoMatrix.QuarterTypes.NotUrgentAndImportant));
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine(todoMatrix.GetSpecificQuarter(TodoMatrix.QuarterTypes.UrgentAndNotimportant));
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine(todoMatrix.GetSpecificQuarter(TodoMatrix.QuarterTypes.NotUrgentAndNotimportant));
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
