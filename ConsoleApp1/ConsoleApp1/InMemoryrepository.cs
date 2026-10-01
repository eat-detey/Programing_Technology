using System.Collections.Generic;
namespace TypographyApp{
    /// <summary>
    /// Репозиторий с тестовыми данными в памяти.
    /// </summary>
    public class InMemoryRepository{
        private List<Department> _departments;
        private List<Editor> _editors;
        private List<Edition> _editions;
        /// <summary>
        /// Конструктор, заполняющий списки тестовыми данными.
        /// </summary>
        public InMemoryRepository(){
            _departments = new List<Department>{
                new Department { Id = 1, Name = "Художественная_литература", Head = "Смирнова Е.В." },
                new Department { Id = 2, Name = "Научная_литература",        Head = "Петров А.С." },
                new Department { Id = 3, Name = "Детская_литература",        Head = "Орлова М.И." },
                new Department { Id = 4, Name = "Учебная_литература",        Head = "Иванов И.И." },
                new Department { Id = 5, Name = "Справочная_литература",     Head = "Сидорова А.А." }
            };
            _editors = new List<Editor>{
                new Editor { Id = 1, FullName = "Смирнова Е.В.", Experience = 15, Specialty = "Проза" },
                new Editor { Id = 2, FullName = "Орлова М.И.",   Experience = 8,  Specialty = "Поэзия" },
                new Editor { Id = 3, FullName = "Петров А.С.",   Experience = 20, Specialty = "Наука" },
                new Editor { Id = 4, FullName = "Иванов И.И.",   Experience = 5,  Specialty = "Учебники" },
                new Editor { Id = 5, FullName = "Сидорова А.А.", Experience = 12, Specialty = "Справочники" }
            };
            _editions = new List<Edition>{
                new Edition(1, "Тихий_Дон",                  1, 1, 600,  1200),
                new Edition(2, "Война_и_мир",                1, 1, 1225, 1800),
                new Edition(3, "Преступление_и_наказание",   1, 3, 671,  1000),
                new Edition(4, "Физика_7_класс",             4, 4, 300,  700),
                new Edition(5, "Справочник_по_математике",   5, 5, 800,  1500)
            };
        }
        /// <summary>
        /// Возвращает список отделов.
        /// </summary>
        /// <returns>Список объектов Department.</returns>
        public List<Department> GetDepartments() { return _departments; }
        /// <summary>
        /// Возвращает список редакторов.
        /// </summary>
        /// <returns>Список объектов Editor.</returns>
        public List<Editor> GetEditors() { return _editors; }
        /// <summary>
        /// Возвращает список изданий.
        /// </summary>
        /// <returns>Список объектов Edition.</returns>
        public List<Edition> GetEditions() { return _editions; }
    }
}