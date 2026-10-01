namespace TypographyApp{
    /// <summary>
    /// Редактор изданий.
    /// </summary>
    public class Editor{
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Experience { get; set; }
        public string Specialty { get; set; }
        /// <summary>
        /// Является ли редактор опытным (стаж больше 10 лет).
        /// </summary>
        /// <returns>true, если стаж &gt; 10; иначе false.</returns>
        public bool IsSenior{
            get { return Experience > 10; }
        }
        /// <summary>
        /// Строковое представление редактора.
        /// </summary>
        /// <returns>Строка вида «ФИО (N лет опыта)».</returns>
        public string GetInfo(){
            return $"{FullName} ({Experience} лет опыта)";
        }
    }
}