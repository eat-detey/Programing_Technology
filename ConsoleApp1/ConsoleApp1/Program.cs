using System;
using System.Collections.Generic;
namespace TypographyApp{
    internal class Program{
        /// <summary>
        /// Точка входа. Спрашивает источник данных, загружает списки и вызывает аналитические методы.
        /// Все операции обёрнуты в try/catch: при ошибке программа останавливается и выводит сообщение.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        static void Main(string[] args){
            try{
                Console.WriteLine("Выберите источник данных:");
                Console.WriteLine("1 - InMemoryRepository");
                Console.WriteLine("2 - CsvRepository");
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice)){
                    Console.WriteLine("Неверный выбор");
                    return;
                }
                List<Department> departments = new List<Department>();
                List<Editor> editors = new List<Editor>();
                List<Edition> editions = new List<Edition>();
                switch (choice){
                    case 1:
                        InMemoryRepository repo1 = new InMemoryRepository();
                        departments = repo1.GetDepartments();
                        editors = repo1.GetEditors();
                        editions = repo1.GetEditions();
                        break;
                    case 2:
                        CsvRepository repo2 = new CsvRepository("data");
                        departments = repo2.GetDepartments();
                        editors = repo2.GetEditors();
                        editions = repo2.GetEditions();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }
                Console.WriteLine();

                Console.WriteLine("1. FindEditor(\"Тихий Дон\"):");
                Editor editor = FindEditor(editions, editors, "Тихий_Дон");
                Console.WriteLine(editor != null ? editor.GetInfo() : "Не найдено");

                Console.WriteLine("\n2. FindDepartment(edition \"Тихий Дон\"):");
                Department dept = FindDepartment(editions, departments, "Тихий_Дон");
                Console.WriteLine(dept != null ? dept.GetInfo() : "Не найдено");

                Console.WriteLine("\n3. GetTotalPages:");
                Console.WriteLine(GetTotalPages(editions));

                Console.WriteLine("\n4. GetEditorWithMostPages:");
                Editor top = GetEditorWithMostPages(editions, editors);
                Console.WriteLine(top != null ? top.GetInfo() : "Не найдено");

                Console.WriteLine("\n5. PrintAllEditions:");
                PrintAllEditions(editions, editors, departments);

                Console.WriteLine();
                Editor notFound = FindEditor(editions, editors, "Неизвестное_издание");
                Console.WriteLine("Не найдено: FindEditor(\"Неизвестное издание\") -> " +
                                  (notFound == null ? "null" : notFound.GetInfo()));
            }
            catch (ArgumentException ex){
                // Сработает, например, если Pages <= 0 в конструкторе Edition
                Console.WriteLine($"Ошибка данных: {ex.Message}");
                Console.WriteLine("Дальнейшие команды не выполняются.");
            }
            catch (FormatException ex){
                // Ошибка парсинга числа из CSV
                Console.WriteLine($"Ошибка формата числа: {ex.Message}");
                Console.WriteLine("Дальнейшие команды не выполняются.");
            }
            catch (Exception ex){
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Поиск редактора по названию издания.
        /// </summary>
        /// <param name="editions">Список всех изданий.</param>
        /// <param name="editors">Список всех редакторов.</param>
        /// <param name="title">Название искомого издания.</param>
        /// <returns>Объект Editor, либо null, если издание не найдено.</returns>
        static Editor FindEditor(List<Edition> editions, List<Editor> editors, string title){
            Edition found = null;
            foreach (Edition e in editions){
                if (e.Title == title) { found = e; break; }
            }
            if (found == null) return null;
            foreach (Editor ed in editors){
                if (ed.Id == found.EditorId) return ed;
            }
            return null;
        }
        /// <summary>
        /// Поиск отдела по названию издания.
        /// </summary>
        /// <param name="editions">Список всех изданий.</param>
        /// <param name="departments">Список всех отделов.</param>
        /// <param name="title">Название искомого издания.</param>
        /// <returns>Объект Department, либо null, если издание не найдено.</returns>
        static Department FindDepartment(List<Edition> editions, List<Department> departments, string title){
            Edition found = null;
            foreach (Edition e in editions){
                if (e.Title == title) { found = e; break; }
            }
            if (found == null) return null;
            foreach (Department d in departments){
                if (d.Id == found.DepartmentId) return d;
            }
            return null;
        }
        /// <summary>
        /// Суммарное количество страниц во всех изданиях.
        /// </summary>
        /// <param name="editions">Список изданий.</param>
        /// <returns>Общее число страниц. Пустой список — 0.</returns>
        static int GetTotalPages(List<Edition> editions){
            int total = 0;
            foreach (Edition e in editions) total += e.Pages;
            return total;
        }
        /// <summary>
        /// Поиск редактора с максимальным суммарным количеством страниц.
        /// При равенстве — первый найденный.
        /// </summary>
        /// <param name="editions">Список изданий.</param>
        /// <param name="editors">Список редакторов.</param>
        /// <returns>Объект Editor с максимумом страниц, либо null, если изданий нет.</returns>
        static Editor GetEditorWithMostPages(List<Edition> editions, List<Editor> editors){
            if (editions.Count == 0) return null;

            int bestEditorId = -1;
            int bestSum = -1;

            foreach (Editor ed in editors){
                int sum = 0;
                foreach (Edition e in editions){
                    if (e.EditorId == ed.Id) sum += e.Pages;
                }
                if (sum > bestSum){
                    bestSum = sum;
                    bestEditorId = ed.Id;
                }
            }
            foreach (Editor ed in editors){
                if (ed.Id == bestEditorId) return ed;
            }
            return null;
        }
        /// <summary>
        /// Вывод всех изданий с информацией о редакторе и отделе.
        /// Если редактор или отдел не найдены — выводится "—".
        /// </summary>
        /// <param name="editions">Список изданий.</param>
        /// <param name="editors">Список редакторов.</param>
        /// <param name="departments">Список отделов.</param>
        static void PrintAllEditions(List<Edition> editions, List<Editor> editors, List<Department> departments){
            foreach (Edition e in editions){
                Editor editor = null;
                foreach (Editor ed in editors){
                    if (ed.Id == e.EditorId) { editor = ed; break; }
                }
                Department dept = null;
                foreach (Department d in departments){
                    if (d.Id == e.DepartmentId) { dept = d; break; }
                }
                string editorName = editor != null ? editor.FullName : "—";
                string deptName = dept != null ? dept.Name.Replace('_', ' ') : "—";
                Console.WriteLine($"\"{e.GetInfo()}\" - редактор {editorName}, отдел \"{deptName}\"");
            }
        }
    }
}