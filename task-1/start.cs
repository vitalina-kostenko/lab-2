namespace Start.task_1
{
    internal class Start_task1
    {
        public static void StartTask1(string[] args)
        {
            Console.WriteLine("Виберіть задачу для запуску:");
            Console.WriteLine("1 - Запуск RunMatrixTask");
            Console.WriteLine("2 - Запуск RunMatrixOperations");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n\nЗапуск RunMatrixTask\n");
                    Run_MatrixTask matrixTask = new Run_MatrixTask();
                    matrixTask.RunMatrixTask();
                    break;
            }
        }
    }
}
