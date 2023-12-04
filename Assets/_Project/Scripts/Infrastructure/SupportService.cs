using System.Collections.Generic;
using System.Text;

namespace CountersAnalysis
{
    public static class SupportService
    {
        public static string counterCSV(CounterData counter)
        {
            StringBuilder result = new StringBuilder();
            result.Append(counter.number);
            result.Append($", {counter.note}");

            foreach (var scale in counter.scales)
            {
                int value = (int)scale.value;
                result.Append($", {value}");
            }

            return result.ToString();
        }

        public static List<string> packageCSV(CountersPackageData package)
        {
            List<string> list = new List<string>
            {
                $"Date: {package.date}",
                $"Note: {package.note}",
                "Number:, Check ID:, Customer, A+(1), A+(2), A+(3), A+(4), A-(1), A-(2), A-(3), A-(4)",
                "Head Counter: ",
                counterCSV(package.headCounter),
                "Counters: "
            };

            foreach (CounterData counter in package.counters)
            {
                list.Add(counterCSV(counter));
            }

            return list;
        }
    }
}