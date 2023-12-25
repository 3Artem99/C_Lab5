/*
Задание№1
Создайте класс MyMatrix, представляющий матрицу m на n.
Создайте конструктор, принимающий число строк и столбцов, заполняющий матрицу случайными числами в диапазоне, который пользователь вводит при запуске программы.
Создайте метод Fill, перезаполняющий матрицу случайными значениями.
Создайте метод ChangeSize, изменяющий число строк и/или столбцов с копированием значений существующей матрицы. Если новая матрица больше существующий, то метод должен дозаполнить новую матрицу случайными числами.
Создайте метод ShowPartialy, принимающий в качестве параметров начальные и конечные значения строк и столбцов, значения матрицы внутри которых нужно вывести на консоль.
Создайте метод Show, выводящий все значения матрицы на консоль.
Создайте индексатор для матрицы вида this[int index1, int index2] с аксессором и мутатором.

Задание№2
Создайте класс MyList<T>.
Реализуйте в простейшем приближении возможность использования его экземпляра аналогично экземпляру класса List<T>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента, индексатор для получения значения элемента по указанному индексу, свойство только для чтения для получения общего количества элементов и поддержку блока инициализации.
При выполнении нельзя использовать коллекции, только массивы.

Задание№3
Создайте коллекцию MyDictionary<TKey,TValue>.
Реализуйте в простейшем приближении возможность использования ее экземпляра аналогично экземпляру класса Dictionary<TKey,TValue>.
Минимально требуемый интерфейс взаимодействия с экземпляром должен включать метод добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство только для чтения для получения общего количества элементов.
Реализуйте возможность перебора элементов коллекции в цикле foreach. При выполнении нельзя использовать коллекции, только массивы.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Program
    {
        //TASK 1
        class MyMatrix
        {
            private int[,] matrix;
            private int rows;
            private int columns;
            private Random random = new Random();

            class MyMatrix1
            {
                private int[,] matrix;
                private int rows;
                private int columns;
                private Random random = new Random();

                public MyMatrix1(int rows, int columns, int minValue, int maxValue)
                {
                    this.rows = rows;
                    this.columns = columns;
                    matrix = new int[rows, columns];
                    Fill(minValue, maxValue);
                }

                public void Fill(int minValue, int maxValue)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            matrix[i, j] = random.Next(minValue, maxValue + 1); // Заполняем матрицу случайными числами в указанном диапазоне
                        }
                    }
                }

                public void ChangeSize(int newRows, int newColumns, int minValue, int maxValue)
                {
                    int[,] newMatrix = new int[newRows, newColumns];
                    for (int i = 0; i < Math.Min(rows, newRows); i++)
                    {
                        for (int j = 0; j < Math.Min(columns, newColumns); j++)
                        {
                            newMatrix[i, j] = matrix[i, j];
                        }
                    }

                    rows = newRows;
                    columns = newColumns;
                    matrix = newMatrix;

                    Fill(minValue, maxValue); // Дозаполняем новую матрицу случайными числами в диапазоне, который задаст пользователь
                }

                public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
                {
                    for (int i = startRow; i <= endRow; i++)
                    {
                        for (int j = startColumn; j <= endColumn; j++)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                public void Show()
                {
                    ShowPartialy(0, rows - 1, 0, columns - 1);
                }

                public int this[int index1, int index2]
                {
                    get //аксесор
                    {
                        if (index1 < 0 || index1 >= rows || index2 < 0 || index2 >= columns)
                            throw new IndexOutOfRangeException("Индекс находится за пределами границ матрицы.");

                        return matrix[index1, index2];
                    }
                    set //аксесор (мутатор)
                    {
                        if (index1 < 0 || index1 >= rows || index2 < 0 || index2 >= columns)
                            throw new IndexOutOfRangeException("Индекс находится за пределами границ матрицы.");

                        matrix[index1, index2] = value;
                    }
                }
            }
            //TASK 2
            class MyList<T>:IEnumerable<T>
            {
                private T[] items;
                private int count;

                public MyList()
                {
                    items = new T[4]; // Изначально создаем массив с 4 элементами
                    count = 0; // Изначально список пуст
                }

                public void Add(T item)
                {
                    if (count == items.Length)
                    {
                        // Если массив заполнен, увеличиваем его размер вдвое
                        Array.Resize(ref items, items.Length * 2);
                    }

                    items[count] = item;
                    count++;
                }

                public T this[int index]
                {
                    get
                    {
                        if (index < 0 || index >= count)
                        {
                            throw new IndexOutOfRangeException("Индекс находится за пределами допустимого диапазона.");
                        }

                        return items[index];
                    }
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return items.GetEnumerator();
                }

                public int Count
                {
                    get { return count; }
                }
            }

            //TASK 3
            public class MyDictionary<TKey, TValue>
            {
                private TKey[] keys;
                private TValue[] values;
                private int size;

                public MyDictionary()
                {
                    keys = new TKey[0];
                    values = new TValue[0];
                    size = 0;
                }

                public void Add(TKey key, TValue value)
                {
                    Array.Resize(ref keys, size + 1);
                    Array.Resize(ref values, size + 1);
                    keys[size] = key;
                    values[size] = value;
                    ++size;
                }

                public TValue this[TKey key] //индексатор
                {
                    get
                    {
                        int index = Array.IndexOf(keys, key);
                        if (index == -1)
                        {
                            throw new KeyNotFoundException();
                        }

                        return values[index];
                    }
                    set
                    {
                        int index = Array.IndexOf(keys, key);
                        if (index == -1)
                        {
                            Add(key, value);
                        }
                        else
                        {
                            values[index] = value;
                        }
                    }
                }

                public int Size //свойство для чтения размера
                {
                    get
                    {
                        return size;
                    }
                }

                public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() //GetEnumerator реализует интерфейс
                {
                    for (int i = 0; i < size; ++i)
                    {
                        yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
                    }
                }
            }

        static void Main(string[] args)
            {
                //TASK1
                Console.WriteLine("TASK 1");
                int rows, columns, minValue, maxValue;

                Console.WriteLine("Введите число строк:");
                rows = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите число столбцов:");
                columns = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите минимальное значение для заполнения:");
                minValue = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите максимальное значение для заполнения:");
                maxValue = int.Parse(Console.ReadLine());

                MyMatrix1 matrix = new MyMatrix1(rows, columns, minValue, maxValue);

                Console.WriteLine("Исходная матрица:");
                matrix.Show();
     
                Console.WriteLine("Введите число строк в новой матрице:");
                int newRows = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите число столбцов в новой матрице:");
                int newColumns = int.Parse(Console.ReadLine());
                Console.WriteLine("\nИзмененная матрица:");
                matrix.ChangeSize(newRows, newColumns, minValue, maxValue);
                matrix.Show();

                Console.WriteLine("Введите первую строку из новой матрицы для того, чтобы получить её часть:");
                int startRow = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите последнюю строку из новой матрицы для того, чтобы получить её часть:");
                int endRow = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите первый столбец из новой матрицы для того, чтобы получить её часть:");
                int startColumn = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите последний столбец из новой матрицы для того, чтобы получить её часть:");
                int endColumn = int.Parse(Console.ReadLine());
                Console.WriteLine("\nЧасть матрицы:");
                matrix.ShowPartialy(startRow, endRow, startColumn, endColumn);

                //TASK 2
                Console.WriteLine();
                Console.WriteLine("TASK 2");
                // Создаем экземпляр MyList<int>
                MyList<int> myList = new MyList<int>();

                // Добавляем элементы в список
                myList.Add(1);
                myList.Add(2);
                myList.Add(3);

                // Выводим элементы списка
                for (int i = 0; i < myList.Count; i++)
                {
                    Console.WriteLine(myList[i]);
                }

                //TASK 3
                Console.WriteLine();
                Console.WriteLine("TASK 3");
                MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();

                myDictionary[1] = "Value 1";
                myDictionary[2] = "Value 2";
                myDictionary[3] = "Value 3";

                string value = myDictionary[2];
                Console.WriteLine("Значение элемента по ключу 2: " + value);

                int size = myDictionary.Size;
                Console.WriteLine("Общее количество элементов: " + size);

                foreach (KeyValuePair<int, string> pair in myDictionary)
                {
                    Console.WriteLine("Ключ: " + pair.Key + ", Значение: " + pair.Value);
                }
                Console.Read();
            }

        }
    }
}   
