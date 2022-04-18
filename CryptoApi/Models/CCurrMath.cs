using CryptoApi.Models.DB;

namespace CryptoApi.Models
{
    static public class CCurrMath
    {
        static public decimal? Exchange (decimal? val1, decimal? val2)
        {
            if (val1 == null || val2 == null || val1 == 0 || val2 == 0) return null;

            return Math.Round((decimal)(100 / val1 * val2), 4);
        }

        /*static public IUpdatedData? FilterLust (int days, IEnumerable<IUpdatedData> list)
        {
            if (list.Count() == 0) return null;

            IUpdatedData? item = list.Where(i => i.last_updated.Date == DateTime.Now.AddDays(-days).Date).FirstOrDefault();
            if (item != null) return item;

            int _days = days;

            while (item == null)
            {
                if (--days > 0)
                {
                    item = list.Where(i => i.last_updated.Date == DateTime.Now.AddDays(-days).Date).FirstOrDefault(); //ищем соответствие в ближайшем от заданного дня к сегоднешнему дню
                    if (item != null) return item;
                }

                ++_days;

                item = list.Where(i => i.last_updated.Date == DateTime.Now.AddDays(-_days).Date).FirstOrDefault(); //ищем соответствие в ближайшем от заданного дня к предыдущим дням
            }

            return item;


            *//*return list.Count() == 0 ? null : list.First();*//*
            // TODO: вернуть элемент списка который соответствует дате, если нету то ближайшую к требуемой.
        }

        static public decimal? GetChangePrice (int days, IEnumerable<CCoinsExtDataM> coins)
        {
            var first = (CCoinsExtDataM)FilterLust(days, coins);
            if (first == null) return 0;

            var last = coins.OrderBy(i => i.last_updated).Last();

            if (last.usd_price == null || first.usd_price == null) return 0;

            return last.usd_price.Value - first.usd_price.Value;
        }*/

        static public IUpdatedData? FilterLust(int days, IEnumerable<IUpdatedData> list, DateTime last_date)
        {
            if (list.Count() == 0) return null;
            
            IUpdatedData? item = list.Where(i => i.last_updated.Date == last_date.AddDays(-days).Date).FirstOrDefault();
            if (item != null) return item;

            int _days = days;
            var res = list.Where(i => i.last_updated.Date != last_date.Date); //ищем соответствие в ближайшем от заданного дня к сегоднешнему дню
            if (res.Count() == 0) return null;

            while (item == null)
            {
                if (--days > 0)
                {
                    item = list.Where(i => i.last_updated.Date == last_date.AddDays(-days).Date).FirstOrDefault(); //ищем соответствие в ближайшем от заданного дня к сегоднешнему дню
                    if (item != null) return item;
                }

                ++_days;

                item = list.Where(i => i.last_updated.Date == last_date.AddDays(-_days).Date).FirstOrDefault(); //ищем соответствие в ближайшем от заданного дня к предыдущим дням
            }

            return item;
        }

        static public decimal? GetChangePrice(int days, IEnumerable<CCoinsExtDataM> coins)
        {
            if (coins.Count() == 0) return 0;

            var last = coins.OrderBy(i => i.last_updated).Last();
            var first = (CCoinsExtDataM)FilterLust(days, coins, last.last_updated.Date);

            if (first == null) return 0;

            if (last.usd_price == null || first.usd_price == null) return 0;

            return last.usd_price.Value - first.usd_price.Value;
        }

        static public decimal? GetChangePercentPrice(int days, IEnumerable<CCoinsExtDataM> coins)
        {
            if (coins.Count() == 0) return null;
            var last = coins?.Last()?.usd_price;
            var diff = GetChangePrice(days, coins);
            if (last == null || diff == null) return null;

            if (last.Value == 0) return 0;

            var result = Math.Round(100 / last.Value * diff.Value, 3);
            
            return result;
        }
    }
}
