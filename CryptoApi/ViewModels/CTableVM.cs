using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using System.Web;
using Sass.TagHelpers;

namespace CryptoApi.ViewModels
{
    public class CTableVM<TRow> : ITableVM
    {
        public delegate string DGetItem(TRow data);
        public delegate IHtmlContent DGetHtmlItem(TRow data);
        private Dictionary<IHtmlContent, DGetHtmlItem> items = new();
        public IEnumerable<IHtmlContent> keys => items.Keys;
        public IEnumerable<IEnumerable<IHtmlContent>> rows => GetRows();

        IEnumerable<TRow> data { get; set; }

        public CTableVM (IEnumerable<TRow> data)
        {
            
            this.data = data;
        }
        public IEnumerable<DGetHtmlItem> GetEnumerable()
        {
            foreach (var item in items)
            {
                yield return item.Value;
            }
        }

        public CTableVM<TRow> Add (string title, DGetItem callback)
        {
            items.Add(new HtmlContentBuilder().AppendHtml(title), i =>
            {
                return new HtmlContentBuilder().AppendHtml(callback(i));
            });

            return this;
        }
        public CTableVM<TRow> Add(string title, DGetHtmlItem callback)
        {
            items.Add(new HtmlContentBuilder().AppendHtml(title), callback);
            return this;
        }

        private IEnumerable<IEnumerable<IHtmlContent>> GetRows ()
        {
            IEnumerable<IHtmlContent> GetItems (TRow row)
            {
                foreach(var item in items)
                {
                    yield return item.Value(row);
                }
            }

            foreach(var row in data)
            {
                yield return GetItems(row);
            }
        }
    }
}
