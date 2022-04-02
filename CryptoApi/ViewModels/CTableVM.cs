namespace CryptoApi.ViewModels
{
    public class CTableVM<TRow> : ITableVM
    {
        public delegate string DGetItem(TRow data);
        private Dictionary<string, DGetItem> items = new();
        public IEnumerable<string> keys => items.Keys;
        public IEnumerable<IEnumerable<string>> rows => GetRows();

        IEnumerable<TRow> data { get; set; }

        public CTableVM (IEnumerable<TRow> data)
        {
            this.data = data;
        }
        public IEnumerable<DGetItem> GetEnumerable()
        {
            foreach (var item in items)
            {
                yield return item.Value;
            }
        }

        public CTableVM<TRow> Add (string title, DGetItem callback)
        {
            items.Add (title, callback);
            return this;
        }

        private IEnumerable<IEnumerable<string>> GetRows ()
        {
            IEnumerable<string> GetItems (TRow row)
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
