namespace CryptoApi.Sitemap
{
    /// <summary>
    /// Предназначен для создания карты сайта на основе информации о страницах, которая передаётся в конструктор.
    /// </summary>
    public class CWriter
    {
        int countUrls = 100;
        string mainFileName = "_sitemap.xml";
        string subFileName = "_sitemap{index}.xml";

        IEnumerable<CPageInfo> pages { get; set; }
        int count { get; set; }

        public CWriter (IEnumerable<CPageInfo> pages, int count)
        {
            this.count = count;
            this.pages = pages;
        }
        
        public void Write ()
        {
            int count = CreateSubFiles();
            CreateMainFile(count);
            RemoveOldFiles();
            RenameNewFiles();
        }
        string GetSubFileName(int index)
        {
            return subFileName.Replace("{index}", index.ToString());
        }
        int CreateSubFiles()
        {
            List<CPageInfo> part_pages = new List<CPageInfo>();
            int index = 0;
            int files_count = 0;

            foreach (var page in pages)
            {
                if (index++ >= countUrls)
                {
                    files_count++;
                    index = 0;
                    CreateSubfile(part_pages, files_count);
                    part_pages.Clear();
                }

                part_pages.Add(page);
            }

            return files_count;
        }

        /// <summary>
        /// Создаёт один частичный файл по ТЗ.
        /// Для получения имени файла использовать метод string GetSubFileName(int index).
        /// </summary>
        /// <param name="pages">Список страниц, которые нужно записать в этот файл</param>
        /// <param name="index">Порядковый номер файла</param>
        void CreateSubfile(List<CPageInfo> pages, int index)
        {
            // TODO: реализовать
            foreach (var page in pages)
                Console.WriteLine(page.url);

            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Создаёт главный файл карты по ТЗ.
        /// Имя лежит в поле mainFileName.
        /// </summary>
        /// <param name="count">Количество под-файлов</param>
        void CreateMainFile(int count)
        {
            // TODO: реализовать
        }

        /// <summary>
        /// Новые файлы карт создаются со знаком "_" в начале имени.
        /// Это нужно для того, чтобы отличить старые файлы от новых.
        /// Этот метод должен удалить старые файлы карт.
        /// </summary>
        void RemoveOldFiles()
        {
            // TODO: реализовать
        }

        /// <summary>
        /// Переименовывает все новые файлы карт - убирает с начала имени символ "_".
        /// </summary>
        void RenameNewFiles()
        {
            // TODO: реализовать
        }
    }
}
