using System;
using System.Collections.Generic;
using System.IO;
namespace TypographyApp{
    /// <summary>
    /// Репозиторий для загрузки данных из CSV-файлов (разделитель — пробел).
    /// </summary>
    public class CsvRepository{
        private string _basePath;
        /// <summary>
        /// Конструктор, задающий папку с CSV-файлами.
        /// </summary>
        /// <param name="basePath">Путь к папке с файлами departments.csv, editors.csv, editions.csv.</param>
        public CsvRepository(string basePath){
            _basePath = basePath;
        }
        /// <summary>
        /// Загружает отделы из файла departments.csv.
        /// </summary>
        /// <returns>Список объектов Department. Пустой список, если файл не найден.</returns>
        public List<Department> GetDepartments(){
            List<Department> result = new List<Department>();
            string path = Path.Combine(_basePath, "departments.csv");
            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 3) continue;

                Department d = new Department();
                d.Id = int.Parse(parts[0]);
                d.Name = parts[1];
                d.Head = parts[2].Replace('_', ' ');
                result.Add(d);
            }
            return result;
        }
        /// <summary>
        /// Загружает редакторов из файла editors.csv.
        /// </summary>
        /// <returns>Список объектов Editor. Пустой список, если файл не найден.</returns>
        public List<Editor> GetEditors(){
            List<Editor> result = new List<Editor>();
            string path = Path.Combine(_basePath, "editors.csv");
            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 4) continue;

                Editor e = new Editor();
                e.Id = int.Parse(parts[0]);
                e.FullName = parts[1].Replace('_', ' ');
                e.Experience = int.Parse(parts[2]);
                e.Specialty = parts[3].Replace('_', ' ');
                result.Add(e);
            }
            return result;
        }
        /// <summary>
        /// Загружает издания из файла editions.csv.
        /// Использует конструктор Edition с проверкой pages &gt; 0.
        /// </summary>
        /// <returns>Список объектов Edition. Пустой список, если файл не найден.</returns>
        public List<Edition> GetEditions(){
            List<Edition> result = new List<Edition>();
            string path = Path.Combine(_basePath, "editions.csv");
            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++){
                string[] parts = lines[i].Split(' ');
                if (parts.Length < 6) continue;

                int id = int.Parse(parts[0]);
                string title = parts[1];
                int departmentId = int.Parse(parts[2]);
                int editorId = int.Parse(parts[3]);
                int pages = int.Parse(parts[4]);
                decimal price = decimal.Parse(parts[5]);
                Edition ed = new Edition(id, title, departmentId, editorId, pages, price);
                result.Add(ed);
            }
            return result;
        }
    }
}