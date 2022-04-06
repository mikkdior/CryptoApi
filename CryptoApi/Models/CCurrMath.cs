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

        static public IUpdatedData FilterLust (int days, IEnumerable<IUpdatedData> list)
        {
            return list.First();
        }

        static public decimal? GetChangePrice (int days, IEnumerable<CCoinsExtDataM> coins)
        {
            var first = (CCoinsExtDataM)FilterLust(days, coins);
            var last = coins.Last();
            if (last.usd_price == null || first.usd_price == null) return null;

            return last.usd_price.Value - first.usd_price.Value;
        }

        static public decimal? GetChangePercentPrice(int days, IEnumerable<CCoinsExtDataM> coins)
        {
            if (coins.Count() == 0) return null;
            var last = coins?.Last()?.usd_price;
            var diff = GetChangePrice(days, coins);
            if (last == null || diff == null) return null;

            var result = Math.Round(100 / last.Value * diff.Value, 3);
            
            return result;
        }
    }
}
