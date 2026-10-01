namespace TypographyApp{
    /// <summary>
    /// Отдел типографии.
    /// </summary>
    public class Department{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        /// <summary>
        /// Является ли отдел отделом художественной литературы.
        /// </summary>
        /// <returns>true, если название отдела — «Художественная литература»; иначе false.</returns>
        public bool IsFiction(){
            return Name == "Художественная_литература";
        }
        /// <summary>
        /// Строковое представление отдела.
        /// </summary>
        /// <returns>Строка вида «Название (зав.: ФИО)».</returns>
        public string GetInfo(){
            return $"{Name.Replace('_', ' ')} (зав.: {Head})";
        } 
    }
}