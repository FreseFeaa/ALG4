// 1) Написать функцию, которая по списку L строит два новых
// списка: L1 – из положительных элементов и L2 – из отрицательных элементов списка L.


using System;
using System.Collections.Generic;

class Program
{
    static Tuple<List<int>, List<int>> SeparateElements(List<int> L)
    {
        List<int> L1 = new List<int>();
        List<int> L2 = new List<int>();

        foreach (int num in L)
        {
            if (num > 0)
            {
                L1.Add(num); // добавление положительного элемента в список L1
            }
            else if (num < 0)
            {
                L2.Add(num); // добавление отрицательного элемента в список L2
            }
        }

        return new Tuple<List<int>, List<int>>(L1, L2);
    }

    static void Main()
    {
        List<int> L = new List<int> { 1, -2, 3, -4, 5, -6, 7 }; // пример списка L
        var result = SeparateElements(L);

        Console.WriteLine("Список положительных элементов L1:");
        foreach (int num in result.Item1)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine("\nСписок отрицательных элементов L2:");
        foreach (int num in result.Item2)
        {
            Console.Write(num + " ");
        }
    }
}



// 2) 2.	Определить корректна ли данная скобочная последовательность
// Пример: [(())]([]) – корректно, [ ) – некорректно, [ (]) – некорректно, ) – некорректно

using System;
using System.Collections.Generic;

class Program
{
    static bool IsBalanced(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in input)
        {
            if (c == '(' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' && (stack.Count == 0 || stack.Pop() != '('))
            {
                return false;
            }
            else if (c == ']' && (stack.Count == 0 || stack.Pop() != '['))
            {
                return false;
            }
        }

        return stack.Count == 0;
    }

    static void Main()
    {
        string input1 = "[(())]([])";  // корректная последовательность
        string input2 = "[ )";         // некорректная последовательность
        string input3 = "[ (])";       // некорректная последовательность
        string input4 = ")";           // некорректная последовательность

        Console.WriteLine(IsBalanced(input1)); // должно вывести True
        Console.WriteLine(IsBalanced(input2)); // должно вывести False
        Console.WriteLine(IsBalanced(input3)); // должно вывести False
        Console.WriteLine(IsBalanced(input4)); // должно вывести False
    }
}


// 3)Определить, расположены ли элементы в двусвязном списке симметричным образом.

using System;
using System.Collections.Generic;

public class ListNode
{
    public int Value;
    public ListNode Next;
    public ListNode Prev;

    public ListNode(int value)
    {
        Value = value;
    }
}

public class LinkedList
{
    public ListNode Head;

    public bool IsSymmetric()
    {
        if (Head == null)
            return true;

        ListNode left = Head;
        ListNode right = GetLastNode();

        while (left != null && right != null)
        {
            if (left.Value != right.Value)
                return false;

            left = left.Next;
            right = right.Prev;
        }

        return true;
    }

    private ListNode GetLastNode()
    {
        ListNode current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        return current;
    }
}

class Program
{
    static void Main()
    {
        // Пример создания двусвязного списка
        LinkedList list = new LinkedList();
        list.Head = new ListNode(1);
        list.Head.Next = new ListNode(2);
        list.Head.Next.Prev = list.Head;
        list.Head.Next.Next = new ListNode(1);
        list.Head.Next.Next.Prev = list.Head.Next;

        // Проверка, является ли список симметричным
        bool isSymmetric = list.IsSymmetric();

        Console.WriteLine("Элементы в двусвязном списке симметричны: " + isSymmetric);
    }
}



// 4)	Напишите код класса для односвязного списка с только следующими методами:
// •	insert(data) – вставить узел в голову
// •	add(data) – вставить узел в хвост
// •	removeFirst() – удалить узел из головы
// •	removeLast() – удалить узел из хвоста
// •	print() – напечатать все узлы
// •	size() – длина списка


using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList
{
    private Node Head;
    private Node Tail;
    private int Count;

    public void Insert(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = Head;
        Head = newNode;

        if (Tail == null)
        {
            Tail = newNode;
        }

        Count++;
    }

    public void Add(int data)
    {
        Node newNode = new Node(data);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;
    }

    public void RemoveFirst()
    {
        if (Head == null)
        {
            return;
        }

        Head = Head.Next;
        Count--;

        if (Head == null)
        {
            Tail = null;
        }
    }

    public void RemoveLast()
    {
        if (Head == null)
        {
            return;
        }

        Count--;

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        Node current = Head;
        while (current.Next != Tail)
        {
            current = current.Next;
        }

        current.Next = null;
        Tail = current;
    }

    public void Print()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public int Size()
    {
        return Count;
    }
}

class Program
{
    static void Main()
    {
        SinglyLinkedList list = new SinglyLinkedList();

        list.Insert(3);
        list.Insert(2);
        list.Insert(1);
        
        list.Add(4);
        list.Add(5);
        list.Add(6);

        list.Print(); // Должно вывести: 1 2 3 4 5 6

        list.RemoveFirst();
        list.RemoveLast();

        list.Print(); // Должно вывести: 2 3 4 5

        int size = list.Size();
        Console.WriteLine("Длина списка: " + size); // Должно вывести: 4
    }
}



// 5)Дети выстраиваются в круг, с одного из них начинается отсчет по часовой стрелке. 
// Тот, на ком счет останавливается, выбывает из круга. 
// Используя структуру данных “очередь”, напишите про- грамму-симуляцию, 
// которая по числу, использующемуся в считалке,
//  определяет имя последнего оставшегося ребенка.
// Пример. input: 4, Петя, Лена, Гена, Витя, Саша output: Петя


using System;
using System.Collections.Generic;

public class ChildGame
{
    public string GetLastChild(int n, string[] children)
    {
        Queue<string> queue = new Queue<string>(children);

        while (queue.Count > 1)
        {
            for (int i = 1; i < n; i++)
            {
                string currentChild = queue.Dequeue();
                queue.Enqueue(currentChild);
            }

            string removedChild = queue.Dequeue();
            Console.WriteLine("Уходит " + removedChild);
        }

        return queue.Peek();
    }
}

class Program
{
    static void Main()
    {
        int n = 4;
        string[] children = { "Петя", "Лена", "Гена", "Витя", "Саша" };

        ChildGame game = new ChildGame();
        string lastChild = game.GetLastChild(n, children);

        Console.WriteLine("Последний оставшийся ребенок: " + lastChild);
    }
}




// 6)	Даны два списка чисел, которые могут содержать до 100000 чисел каждый. Посчитайте, сколько чисел содержится одновременно как в первом списке, так и во втором.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Пример двух списков чисел
        List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int> { 3, 4, 5, 6, 7 };

        // Создаем HashSet для быстрой проверки наличия элементов
        HashSet<int> set = new HashSet<int>(list1);

        // Счетчик чисел, которые содержатся одновременно в обоих списках
        int count = 0;

        foreach (int num in list2)
        {
            if (set.Contains(num))
            {
                count++;
            }
        }

        Console.WriteLine("Количество чисел, которые содержатся одновременно в обоих списках: " + count);
    }
}


// 7)Вам дан словарь, состоящий из пар слов. 
// Каждое слово является синонимом к парному ему слову.
// Все слова в словаре различны. Для одного данного слова определите его синоним.
// Входные данные
// Программа получает на вход количество пар синонимов N. Далее следует N строк, 
// каждая строка содержит ровно два слова-синонима. После этого следует одно слово.
// Выходные данные
// Программа должна вывести синоним к данному слову.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество пар синонимов (N):");
        int N = int.Parse(Console.ReadLine());

        Dictionary<string, string> synonymDict = new Dictionary<string, string>();

        Console.WriteLine("Введите пары синонимов (каждая пара на новой строке):");
        for (int i = 0; i < N; i++)
        {
            string[] synonyms = Console.ReadLine().Split();
            synonymDict[synonyms[0]] = synonyms[1];
            synonymDict[synonyms[1]] = synonyms[0];
        }

        Console.WriteLine("Словарь синонимов заполнен.");

        Console.WriteLine("Введите слово для поиска синонима:");
        string word = Console.ReadLine();

        if (synonymDict.ContainsKey(word))
        {
            Console.WriteLine($"Синоним для слова '{word}' - '{synonymDict[word]}'");
        }
        else
        {
            Console.WriteLine("Синоним не найден.");
        }
    }
}


// 8)Однажды, разбирая старые книги на чердаке, школьник Вася нашёл англо-латинский словарь. Английский он к тому времени знал в совершенстве, и его мечтой было изучить латынь. Поэтому попавшийся словарь был как раз кстати.

// К сожалению, для полноценного изучения языка недостаточно только одного словаря: кроме англо-латинского необходим латинско-английский. За неимением лучшего он решил сделать второй словарь из первого.

// Как известно, словарь состоит из переводимых слов, к каждому из которых приводится несколько слов-переводов. Для каждого латинского слова, встречающегося где-либо в словаре, Вася предлагает найти все его переводы (то есть все английские слова, для которых наше латинское встречалось в его списке переводов), и считать их и только их переводами этого латинского слова.

// Помогите Васе выполнить работу по созданию латинско-английского словаря из англо-латинского.
// Входные данные
// В первой строке содержится единственное целое число N — количество английских слов в словаре. Далее следует N описаний. Каждое описание содержится в отдельной строке, в которой записано сначала английское слово, затем отделённый пробелами дефис (символ номер 45), затем разделённые запятыми с пробелами переводы этого английского слова на латинский. Переводы отсортированы в лексикографическом порядке. Порядок следования английских слов в словаре также лексикографический.
// Все слова состоят только из маленьких латинских букв, длина каждого слова не превосходит 15 символов. Общее количество слов на входе не превышает 100000.
// Выходные данные
// В первой строке программа должна вывести количество слов в соответствующем данному латинско-английском словаре. Со второй строки выведите сам словарь, в точности соблюдая формат входных данных. В частности, первым должен идти перевод лексикографически минимального латинского слова, далее — второго в этом порядке и т.д. Внутри перевода английские слова должны быть также отсортированы лексикографически.



using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Dictionary<string, List<string>> engToLatin = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> latinToEng = new Dictionary<string, List<string>>();

        for (int i = 0; i < N; i++)
        {
            string[] words = Console.ReadLine().Split(new char[] { '-' });

            string englishWord = words[0].Trim();
            string[] latinWords = words[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Добавляем английское слово и его переводы в engToLatin словарь
            if (!engToLatin.ContainsKey(englishWord))
            {
                engToLatin[englishWord] = new List<string>();
            }
            engToLatin[englishWord].AddRange(latinWords);

            // Добавляем латинские слова и их переводы в latinToEng словарь
            foreach (string latinWord in latinWords)
            {
                if (!latinToEng.ContainsKey(latinWord))
                {
                    latinToEng[latinWord] = new List<string>();
                }
                latinToEng[latinWord].Add(englishWord);
            }
        }

        // Создаем латинско-английский словарь на основе latinToEng словаря
        List<string> latinEngTranslations = new List<string>();
        foreach (var entry in latinToEng.OrderBy(e => e.Key))
        {
            string latinWord = entry.Key;
            List<string> englishTranslations = entry.Value.Distinct().OrderBy(t => t).ToList();

            foreach (string engWord in englishTranslations)
            {
                latinEngTranslations.Add($"{latinWord} - {engWord}");
            }
        }

        Console.WriteLine(latinEngTranslations.Count);
        foreach (string translation in latinEngTranslations)
        {
            Console.WriteLine(translation);
        }
    }
}

//Входные данные:
//5
//apple - malum, pomum, popula
//fruit - baca, bacca, popum
//punishment - malum, multa
//the - the, this
//tree - arbor, malus



// 9)В кинотеатре n рядов по m мест в каждом (n и m не превосходят 20). В двумерном массиве хранится информация о проданных билетах, число 1 означает, что билет на данное место уже продан, число 0 означает, что место свободно. Поступил запрос на продажу k билетов на соседние места в одном ряду. Определите, можно ли выполнить такой запрос.
// Формат входных данных
// Программа получает на вход числа n и m. Далее идет n строк, содержащих m чисел (0 или 1), разделенных пробелами. Затем дано число k.
// Формат выходных данных
// Программа должна вывести номер ряда, в котором есть k подряд идущих свободных мест. Если таких рядов несколько, то выведите номер наименьшего подходящего ряда. Если подходящего ряда нет, выведите число 0.

using System;

class Program
{
    static void Main()
    {
        // Ввод данных: количество рядов и мест, информация о проданных билетах и число k
        Console.WriteLine("Введите количество рядов (n):");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество мест в каждом ряду (m):");
        int m = int.Parse(Console.ReadLine());

        int[][] seats = new int[n][];
        Console.WriteLine("Введите информацию о проданных билетах (0 - свободно, 1 - продано):");
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            seats[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                seats[i][j] = int.Parse(row[j]);
            }
        }

        Console.WriteLine("Введите число билетов, которые нужно продать (k):");
        int k = int.Parse(Console.ReadLine());

        // Поиск подходящего ряда
        bool found = false;
        for (int i = 0; i < n; i++)
        {
            int consecutiveFreeSeats = 0;
            for (int j = 0; j < m; j++)
            {
                if (seats[i][j] == 0)
                {
                    consecutiveFreeSeats++;
                    if (consecutiveFreeSeats == k)
                    {
                        found = true;
                        Console.WriteLine($"Найден ряд с свободными местами для {k} билетов: Ряд {i + 1}");
                        break;
                    }
                }
                else
                {
                    consecutiveFreeSeats = 0;
                }
            }
            if (found)
            {
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Подходящий ряд не найден.");
        }
    }
}




// 10) По данным числам n и m заполните двумерный массив размером n×m числами от 1 до n×m “змейкой”
using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        int[][] matrix = new int[n][];

        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[m];
        }

        int rowStart = 0;
        int rowEnd = n - 1;
        int colStart = 0;
        int colEnd = m - 1;
        int number = 1;

        while (number <= n * m)
        {
            for (int i = colStart; i <= colEnd; i++)
            {
                matrix[rowStart][i] = number;
                number++;
            }
            rowStart++;

            for (int i = rowStart; i <= rowEnd; i++)
            {
                matrix[i][colEnd] = number;
                number++;
            }
            colEnd--;

            for (int i = colEnd; i >= colStart; i--)
            {
                matrix[rowEnd][i] = number;
                number++;
            }
            rowEnd--;

            for (int i = rowEnd; i >= rowStart; i--)
            {
                matrix[i][colStart] = number;
                number++;
            }
            colStart++;
        }

        // Вывод заполненной матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

