using System.Collections.Generic;
using System.Linq;

namespace CountersAnalysis
{
    public class DataHandler
    {
        public CountersPackage importPackage(string sourcePath)
        {
            return new CountersPackage(FileHandler.readXML<CountersPackageData>(sourcePath), sourcePath);
        }

        public CalculationPattern createCalculationPattern(string path)
        {
            CalculationPatternData patternData = new CalculationPatternData();
            FileHandler.writeXML(patternData, path);
            return new CalculationPattern(patternData, path);
        }

        public CalculationPattern openPattern(RegistrableData registredData)
        {
            CalculationPatternData patternData = FileHandler.readXML<CalculationPatternData>(registredData.path);
            CalculationPattern pattern = new CalculationPattern(patternData);
            pattern.updateRegistrableData(registredData);
            return pattern;
        }

        public void savePattern(CalculationPattern pattern)
        {
            RegistrableData registredData = pattern.getRegistrableData();
            FileHandler.writeXML(pattern.patternData, registredData.path);
        }

        public List<CounterData> createByNumbers(List<string> numbers)
        {
            List<CounterData> counterDatas = new List<CounterData>();
            foreach (string number in numbers)
            {
                CounterData counterData = new CounterData();
                counterData.number = number;
                counterDatas.Add(counterData);
            }
            return counterDatas;
        }

        public List<string> clearSplit(string text)
        {
            string replacedString = text.Replace("\r", "");
            return replacedString.Split('\n').ToList();
        }

        //public string counterCSV(CounterData counter)
        //{
        //    StringBuilder result = new StringBuilder();
        //    result.Append(counter.number);
        //    result.Append($", {counter.note}");

        //    foreach (var scale in counter.scales)
        //    {
        //        int value = (int)scale.value;
        //        result.Append($", {value}");
        //    }

        //    return result.ToString();
        //}

        //public List<string> packageCSV(CountersPackageData package)
        //{
        //    List<string> list = new List<string>
        //    {
        //        $"Date: {package.date}",
        //        $"Note: {package.note}",
        //        "Number:, Check ID:, Customer, A+(1), A+(2), A+(3), A+(4), A-(1), A-(2), A-(3), A-(4)",
        //        "Head Counter: ",
        //        counterCSV(package.headCounter),
        //        "Counters: "
        //    };

        //    foreach (CounterData counter in package.counters)
        //    {
        //        list.Add(counterCSV(counter));
        //    }

        //    return list;
        //}
    }
}