using System;
using System.Text;
using Services;

namespace PL
{
    class Menu : Getters
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            EmployeesServices employeesServices = new EmployeesServices();
            PositionsServices positionsServices = new PositionsServices();
            UnitsServices unitsServices = new UnitsServices();
            SearchService searchService = new SearchService();

            while (true)
            {
                Console.Clear();
                Console.Write("Введіть сутність з якою бажаєте працювати або її номер:\n" +
                              "1. Працівник\n" +
                              "2. Підрозділ\n" +
                              "3. Посада\n" +
                              "4. Пошук\n" +
                              "Щоб закрити програму введіть \"Вихід\": \n");

                string entity = Console.ReadLine();
                Console.Clear();

                if (entity == "1" || UppercaseFirstLetter(entity) == "Працівник")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або обновити дані робіника\n" +
                              "2. Видалити дані робітника\n" +
                              "3. Переглянути дані робітника за іднтифікаційним номером\n" +
                              "4. Переглянути список всіх робітників\n" +
                              "5. Переглянути список проектів, в яких брав участь робітник\n" +
                              "6. Додати проект робінику\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або обновити дані робітника" || UppercaseFirstLetter(action) == "Додати" || UppercaseFirstLetter(action) == "Обновити")
                        {
                            Console.Clear();
                            employeesServices.AddOrUpdateEmployee(GetString("Ім'я: "), GetString("Прізвище: "), GetInt("Вік: ", 18, 115), GetEmail(), GetIdentificationCode(), GetInt("Досвід: ", 1), GetBankCardNumber(), GetString("Підрозділ: ", true), GetString("Посада: ", true));

                            Console.WriteLine("Дані робітника успішно додано, щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Видалити працівника" || UppercaseFirstLetter(action) == "Видалити")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode();

                            Console.WriteLine(employeesServices.DeleteEmployee(id));

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані працівника")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode();

                            Console.Clear();
                            Console.WriteLine(employeesServices.GetEmployeeInfo(id));

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх студентів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            Console.WriteLine("Список проектів: ");

                            Console.WriteLine(employeesServices.GetEmployeesInfo());

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "5" || UppercaseFirstLetter(action) == "Переглянути список проектів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode();
                            Console.WriteLine("Список проектів: ");

                            Console.WriteLine(employeesServices.GetEmployeeProjectsInfo(id));

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "6" || UppercaseFirstLetter(action) == "Додати проект")
                        {
                            Console.Clear();

                            Console.WriteLine(employeesServices.AddProject(GetIdentificationCode("Ідентифікаційний номер робітника: "), GetString("Назва проекту: ", true), GetString("Статус проекту: ", true), GetInt("Бюджет проекту(грн): ")));

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }

                        Console.Clear();
                    }
                }
                else if (entity == "2" || UppercaseFirstLetter(entity) == "Підрозділ")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або змінити дані підрозділу\n" +
                              "2. Переглянути дані підрозділу\n" +
                              "3. Переглянути список усіх робітників підрозділу, відсортованих по посаді\n" +
                              "4. Переглянути список усіх робітників підрозділу, відсортованих по сумарній вартості проектів\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або змінити дані підрозділу")
                        {
                            Console.Clear();

                            Console.WriteLine(unitsServices.AddOrUpdateUnit(GetInt("Ідентифікаційний номер підрозділу: ").ToString(), GetString("Назва підрозділу: ")) + "\nЩоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Переглянути дані підрозділу")
                        {
                            Console.Clear();

                            string id = GetInt("Ідентифікаційний номер підрозділу: ").ToString();

                            Console.WriteLine(unitsServices.GetUnitInfo(id));

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути список усіх робітників підрозділу, відсортованих по посаді")
                        {
                            Console.Clear();

                            string id = GetInt("Ідентифікаційний номер підрозділу: ").ToString();

                            Console.WriteLine(unitsServices.GetSortedUnitsInfo(id));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список усіх робітників підрозділу, відсортованих по сумарній вартості проектів")
                        {
                            Console.Clear();

                            string id = GetInt("Ідентифікаційний номер підрозділу: ").ToString();

                            Console.WriteLine(unitsServices.GetSortedUnitsInfo(id, "budget"));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "3" || UppercaseFirstLetter(entity) == "Посада")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або змінити дані посади\n" +
                              "2. Визначити 5 найбільш привабливих посад \n" +
                              "3. Визначити найбільш прибуткового робітника\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або змінити дані посади")
                        {
                            Console.Clear();
                            Console.WriteLine(positionsServices.AddOrUpdatePosition(GetString("Назва посади: ", true), GetInt("Заробітня плата(за місяць): ", 1), GetInt("Кількість робочих годин в день: ", 1, 24)));

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Визначити 5 найбільш привабливих посад")
                        {
                            Console.Clear();

                            Console.WriteLine(positionsServices.GetTopFivePosition() + "\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Визначити найбільш прибуткового робітника")
                        {
                            Console.Clear();

                            string positionName = GetString("Назва посади: ");

                            Console.WriteLine(positionsServices.GetBestEmployee(positionName) + "\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "4" || UppercaseFirstLetter(entity) == "Пошук за ключовим словом")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Пошук в базі робітників\n" +
                              "2. Пошук в базі проектів\n" +
                              "3. Пошук в базі робітників та проектів\n" +
                              "4. Розширений пошук клієнта\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Пошук в базі робітників")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: ");
                            string key = Console.ReadLine();

                            if (searchService.FindEmployeesByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchService.FindEmployeesByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Пошук в базі проектів")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: \n");
                            string key = Console.ReadLine();

                            if (searchService.FindProjectsByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchService.FindProjectsByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Визначити, чи бажаний об'єкт знаходиться у списку доступних об'єктів нерухомості")
                        {
                            Console.Clear();
                            Console.Write("Введіть ключове слово: \n");
                            string key = Console.ReadLine();

                            if (searchService.FindAllByKeyWord(key) == "")
                            {
                                Console.WriteLine("\nЗа вашим ключевим словом нічого не знайдено.\n");
                            }
                            else
                            {
                                Console.WriteLine(searchService.FindAllByKeyWord(key));
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Розширений пошук клієнта")
                        {
                            Console.Clear();
                            Console.WriteLine("Введіть потрібні параметри для пошуку клієнта: \n");
                            string findedClient = searchService.FindEmployeesByParameters(GetString("Ім'я: ", false, false), GetString("Прізвище: ", false, false), GetInt("Вік: ", 18, 115, false), GetEmail(false),
                                GetIdentificationCode("Ідентифікаційний код робітника: ", false), GetInt("Досвід: ", 1, int.MaxValue, false), GetBankCardNumber("Номер банківської карти: ", false), GetString("Підрозділ: ", true, false), GetString("Посада: ", true, false));

                            if (findedClient == "")
                            {
                                Console.Clear();
                                Console.WriteLine("\nКлієнта за даними параметрми не знайдено.\n");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(findedClient);
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (UppercaseFirstLetter(entity) == "Вихід")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
