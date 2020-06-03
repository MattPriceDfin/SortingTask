using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = new int[40];
            var rand = new Random();
            
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = rand.Next(101);
            }

            Console.WriteLine("Original Data:" + "\n");
            foreach (int item in testData)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n" + "\n" + "Which Sort?");
            Console.WriteLine("(S)election, (B)ubble, (M)erge: ");
            var userinput = Console.ReadKey();

            switch (userinput.Key)
            {
                case ConsoleKey.S:

                    Console.WriteLine("\n" + "\n" + "Sorted Data:" + "\n");
                    foreach (int item in selectionSort(testData))
                        Console.Write(item + " ");

                    Console.WriteLine();
                    break;

                case ConsoleKey.B:

                    Console.WriteLine("\n" + "\n" + "Sorted Data:" + "\n");
                    foreach (int item in bubbleSort(testData))
                        Console.Write(item + " ");

                    Console.WriteLine();
                    break;

                case ConsoleKey.M:

                    Console.WriteLine("\n" + "\n" + "Sorted Data:" + "\n");
                    foreach (int item in mergePrestep(testData,0,testData.Length - 1))
                        Console.Write(item + " ");

                    Console.WriteLine();
                    break;

                default:
                    break;
            }

        }
        public static int[] selectionSort(int[] selectArray)
        {
            int maxIndex = selectArray.Length;

            for (int i = 0; i < maxIndex - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < maxIndex; j++)
                    if (selectArray[j] < selectArray[minIndex])
                        minIndex = j;

                int temp = selectArray[minIndex];
                selectArray[minIndex] = selectArray[i];
                selectArray[i] = temp;
            }
            return selectArray;
        }

        public static int[] bubbleSort(int[] bubbleArray)
        {
            int holder;
            for (int p = 0; p <= bubbleArray.Length - 2; p++)
            {
                for (int i = 0; i <= bubbleArray.Length - 2; i++)
                {
                    if (bubbleArray[i] > bubbleArray[i + 1])
                    {
                        holder = bubbleArray[i + 1];
                        bubbleArray[i + 1] = bubbleArray[i];
                        bubbleArray[i] = holder;
                    }
                }
            }
            return bubbleArray;
        }

        public static void mergeSort(int[] mergeArray, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(mergeArray, left, leftArray, 0, middle - left + 1);
            Array.Copy(mergeArray, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    mergeArray[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    mergeArray[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    mergeArray[k] = leftArray[i];
                    i++;
                }
                else
                {
                    mergeArray[k] = rightArray[j];
                    j++;
                }
            }
        }

        public static int[] mergePrestep(int[] mergeArray, int left, int right)
        {

            if (left < right)
            {
                int middle = (left + right) / 2;

                mergePrestep(mergeArray, left, middle);
                mergePrestep(mergeArray, middle + 1, right);

                mergeSort(mergeArray, left, middle, right);
            }
            return mergeArray;
        }
    }
}