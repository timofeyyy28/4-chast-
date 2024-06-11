using ClassLibraryLabor10;
using System;
namespace lab12._4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Musicalinstrument> myCollection = null;

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать коллекцию со случайными элементами");
                Console.WriteLine("2. Распечатать коллекцию");
                Console.WriteLine("3. Добавить элемент в конец коллекции");
                Console.WriteLine("4. Добавить элемент в начало коллекции");
                Console.WriteLine("5. Удалить элемент из коллекции");
                Console.WriteLine("6. Поиск элемента в коллекции");
                Console.WriteLine("7. Очистить коллекцию");
                Console.WriteLine("8. Добавить элемент (IList.Add)");
                Console.WriteLine("9. Найти индекс элемента (IList.IndexOf)");
                Console.WriteLine("10. Вставить элемент (IList.Insert)");
                Console.WriteLine("11. Удалить элемент по индексу (IList.RemoveAt)");
                Console.WriteLine("12. Проверить наличие элемента (ICollection<T>.Contains)");
                Console.WriteLine("13. Скопировать элементы в массив (ICollection<T>.CopyTo)");
                Console.WriteLine("14. Удалить элемент (ICollection<T>.Remove)");
                Console.WriteLine("15. Выход");

                if (!int.TryParse(Console.ReadLine(), out int answer))
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    continue;
                }

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Введите количество элементов:");
                        if (int.TryParse(Console.ReadLine(), out int size))
                        {
                            myCollection = new MyCollection<Musicalinstrument>(size);
                            Console.WriteLine("Коллекция создана.");
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                        break;

                    case 2:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Распечатывание коллекции:");
                            foreach (var item in myCollection)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;

                    case 3:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Musicalinstrument newItem = new Musicalinstrument();
                            newItem.Init();
                            myCollection.AddToEnd(newItem);
                            Console.WriteLine("Элемент добавлен в конец.");
                        }
                        break;

                    case 4:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Musicalinstrument newItem = new Musicalinstrument();
                            newItem.Init();
                            myCollection.AddToBegin(newItem);
                            Console.WriteLine("Элемент добавлен в начало.");
                        }
                        break;

                    case 5:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Введите индекс для удаления:");
                            if (int.TryParse(Console.ReadLine(), out int index))
                            {
                                try
                                {
                                    myCollection.RemoveAt(index);
                                    Console.WriteLine("Элемент удалён.");
                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    Console.WriteLine($"Ошибка: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод.");
                            }
                        }
                        break;

                    case 6:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Musicalinstrument itemToFind = new Musicalinstrument();
                            Console.WriteLine("Введите экземпляр для поиска:");
                            itemToFind.Init();
                            int foundIndex = myCollection.IndexOf(itemToFind);
                            if (foundIndex != -1)
                            {
                                Console.WriteLine($"Экземпляр найден на индексе: {foundIndex}");
                            }
                            else
                            {
                                Console.WriteLine("Экземпляр не найден.");
                            }
                        }
                        break;

                    case 7:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            myCollection = new MyCollection<Musicalinstrument>();
                            Console.WriteLine("Коллекция очищена.");
                        }
                        break;

                    case 8:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Добавление элемента (IList.Add):");
                            Musicalinstrument instrument1 = new Musicalinstrument();
                            instrument1.Init();
                            myCollection.Add(instrument1);
                            Console.WriteLine("Элемент добавлен через Add.");
                        }
                        break;

                    case 9:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Поиск индекса элемента (IList.IndexOf):");
                            Musicalinstrument instrument2 = new Musicalinstrument();
                            instrument2.Init();
                            int index = myCollection.IndexOf(instrument2);
                            Console.WriteLine($"Индекс элемента: {index}");
                        }
                        break;

                    case 10:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Вставка элемента (IList.Insert):");
                            Console.Write("Введите индекс для вставки: ");
                            int insertIndex = int.Parse(Console.ReadLine());
                            Musicalinstrument instrument3 = new Musicalinstrument();
                            instrument3.Init();
                            myCollection.Insert(insertIndex, instrument3);
                            Console.WriteLine("Элемент вставлен через Insert.");
                        }
                        break;

                    case 11:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Удаление элемента по индексу (IList.RemoveAt):");
                            Console.Write("Введите индекс для удаления: ");
                            int removeIndex = int.Parse(Console.ReadLine());
                            try
                            {
                                myCollection.RemoveAt(removeIndex);
                                Console.WriteLine("Элемент удалён через RemoveAt.");
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                        break;

                    case 12:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Проверка наличия элемента (ICollection<T>.Contains):");
                            Musicalinstrument itemToCheck = new Musicalinstrument();
                            itemToCheck.Init();
                            bool contains = myCollection.Contains(itemToCheck);
                            Console.WriteLine($"Элемент {(contains ? "найден" : "не найден")} в коллекции.");
                        }
                        break;

                    case 13:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Копирование элементов в массив (ICollection<T>.CopyTo):");
                            Musicalinstrument[] array = new Musicalinstrument[myCollection.Count];
                            myCollection.CopyTo(array, 0);
                            Console.WriteLine("Элементы скопированы в массив:");
                            foreach (var item in array)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;

                    case 14:
                        if (myCollection == null)
                        {
                            Console.WriteLine("Необходимо сначала создать коллекцию.");
                        }
                        else
                        {
                            Console.WriteLine("Удаление элемента (ICollection<T>.Remove):");
                            Musicalinstrument itemToRemove = new Musicalinstrument();
                            itemToRemove.Init();
                            bool removed = myCollection.Remove(itemToRemove);
                            Console.WriteLine($"Элемент {(removed ? "удален" : "не найден")} в коллекции.");
                        }
                        break;

                    case 15:
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}