using System;
namespace TypographyApp{
    /// <summary>
    /// Издание (книга).
    /// </summary>
    public class Edition{
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public int EditorId { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Пустой конструктор. Нужен для случаев, когда объект заполняется по частям.
        /// </summary>
        public Edition() { }
        /// <summary>
        /// Конструктор с проверкой: количество страниц должно быть больше нуля.
        /// </summary>
        /// <param name="id">Идентификатор издания.</param>
        /// <param name="title">Название издания.</param>
        /// <param name="departmentId">Идентификатор отдела.</param>
        /// <param name="editorId">Идентификатор редактора.</param>
        /// <param name="pages">Количество страниц (должно быть &gt; 0).</param>
        /// <param name="price">Цена издания.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="pages"/> меньше или равно 0.
        /// </exception>
        public Edition(int id, string title, int departmentId, int editorId, int pages, decimal price){
            if (pages <= 0)
                throw new ArgumentException("Количество страниц должно быть больше 0.");
            Id = id;
            Title = title;
            DepartmentId = departmentId;
            EditorId = editorId;
            Pages = pages;
            Price = price;
        }
        /// <summary>
        /// Является ли издание толстым (больше 500 страниц).
        /// </summary>
        /// <returns>true, если страниц &gt; 500; иначе false.</returns>
        public bool IsThick(){
            return Pages > 500;
        }
        /// <summary>
        /// Цена за одну страницу издания.
        /// </summary>
        /// <returns>Число — цена, делённая на количество страниц.</returns>
        public decimal PricePerPage(){
            return Price / Pages;
        }
        /// <summary>
        /// Строковое представление издания.
        /// </summary>
        /// <returns>Строка вида «Название (N стр., M руб.)».</returns>
        public string GetInfo(){
            return $"{Title} ({Pages} стр., {Price} руб.)";
        }
    }
}