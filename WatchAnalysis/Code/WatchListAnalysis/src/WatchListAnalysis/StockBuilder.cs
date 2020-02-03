using System;

namespace WatchListAnalysis
{
    public class StockBuilder
    {
        public static Stock Create(string csvString)
        {
            var stringParametes = csvString.Split(new string(","));
            var code = stringParametes[0];

            DateTime.TryParse(stringParametes[1], out DateTime dateTime);
            decimal.TryParse(stringParametes[2], out decimal openPrice);
            decimal.TryParse(stringParametes[3], out decimal highPrice);
            decimal.TryParse(stringParametes[4], out decimal lowPrice);
            decimal.TryParse(stringParametes[5], out decimal lastPrice);
            int.TryParse(stringParametes[6], out int volume);
            return new Stock() { Code = code, DateTimeRecorded = dateTime, Open = openPrice, High = highPrice, Low = lowPrice, Last = lastPrice, Volume = volume};
        }
    }
}