namespace CryptoApi.Sitemap
{
    /// <summary>
    /// Предназначен для создания карты сайта на основе информации о страницах, которая передаётся в конструктор.
    /// </summary>
    public class CWriter
    {
        int countUrls = 1000;
        string mainFileName = "_sitemap.xml";
        string subFileName = "_sitemap-{index}.xml";
        string root = "./wwwroot/";
        string lastmod = DateTime.Now.ToString("yyyy-MM-dd");
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
        
        string GetSubFileName(int index) => subFileName.Replace("{index}", index.ToString());
        
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

            CreateSubfile(part_pages, ++files_count);

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
            
            string path = root + GetSubFileName(index);
            string sample = "\t\t<url>\r\t\t\t<loc>{url}</loc>\r\t\t\t<lastmod>{lastmod}</lastmod>\r\t\t</url>";

            using (var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sw.WriteLine("<sitemapindex xmlns=\"https://www.sitemaps.org/schemas/sitemap/0.9\">");
                sw.WriteLine("\t<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

                foreach (var page in pages)
                    sw.WriteLine(sample.Replace("{url}", page.url).Replace("{lastmod}", lastmod));

                sw.WriteLine("\t</urlset>");
                sw.WriteLine("</sitemapindex>");
            }
        }

        /// <summary>
        /// Создаёт главный файл карты по ТЗ.
        /// Имя лежит в поле mainFileName.
        /// </summary>
        /// <param name="count">Количество под-файлов</param>
        void CreateMainFile(int count)
        {
            // TODO: реализовать

            string path = root + mainFileName;

            using (var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sw.WriteLine("<sitemapindex xmlns=\"https://www.sitemaps.org/schemas/sitemap/0.9\">");

                for (int i = 1; i < count + 1; i++)
                    sw.WriteLine($"\t<sitemap>\r\t\t<loc>/sitemap-{i}.xml</loc>\r\t</sitemap>");

                sw.WriteLine("</sitemapindex>");
            }
        }

        /// <summary>
        /// Новые файлы карт создаются со знаком "_" в начале имени.
        /// Это нужно для того, чтобы отличить старые файлы от новых.
        /// Этот метод должен удалить старые файлы карт.
        /// </summary>
        void RemoveOldFiles()
        {
            // TODO: реализовать

            foreach (var filepath in Directory.GetFiles(root))
            {
                string file_name = filepath.Split('/').Last();

                if (file_name.StartsWith("sitemap"))
                    File.Delete(filepath);
            }
        }

        /// <summary>
        /// Переименовывает все новые файлы карт - убирает с начала имени символ "_".
        /// </summary>
        void RenameNewFiles()
        {
            // TODO: реализовать
            foreach (var old_path in Directory.GetFiles(root))
            {
                string file_name = old_path.Split('/').Last();

                if (file_name.StartsWith("_sitemap"))
                {
                    string new_path = old_path.Replace(file_name, file_name.Substring(1));
                    File.Move(old_path, new_path);
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        public void UpdateMainSitemap()
        {
            int count_subfiles = (int)Math.Ceiling((double)count / countUrls);
            CreateMainFile(count_subfiles);
            RemoveOldFiles();
            RenameNewFiles();
        }

        public string? GetSubSitemap(int index)
        {
            var curr_pages = pages.Skip(countUrls * (index - 1)).Take(countUrls);
            if (curr_pages.Count() == 0) return null;

            string sample = "\t\t<url>\r\t\t\t<loc>{url}</loc>\r\t\t\t<lastmod>{lastmod}</lastmod>\r\t\t</url>";

            string result = "";
            result += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r";
            result += "<sitemapindex xmlns=\"https://www.sitemaps.org/schemas/sitemap/0.9\">\r";
            result += "\t<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">\r";

            foreach (var page in curr_pages)
                result += sample.Replace("{url}", page.url).Replace("{lastmod}", lastmod) + "\r";

            result += "\t</urlset>\r";
            result += "</sitemapindex>";

            return result;
        }
    }
}
