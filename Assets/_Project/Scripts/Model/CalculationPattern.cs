using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountersAnalysis
{
    public class CalculationPattern : IRegistrable
    {
        private RegistrableData _registrableData;
        private CalculationPatternData _patternData;

        public CalculationPattern() { }

        public CalculationPattern(CalculationPatternData patternData)
        {
            _patternData = patternData;
        }

        public CalculationPattern(CalculationPatternData patternData, string path)
        {
            _patternData = patternData;

            _registrableData.path = path;
            _registrableData.name = Path.GetFileNameWithoutExtension(path);
            _registrableData.elementType = RegistredDataType.CalculationPattern.ToString();
        }

        public RegistrableData getRegistrableData()
        {
            return _registrableData;
        }

        public void updateRegistrableData(RegistrableData registrableData)
        {
            _registrableData = registrableData;
        }

        public void addCounter(List<CounterData> counters)
        {
            counters.ForEach(counter => { addCounter(counter); });
        }

        public void addCounter(CounterData counter)
        {
            CounterData existCounter = existingCounter(counter.number);
            bool counterExist = !existCounter.Equals(default(CounterData));
            if (counterExist)
                return;

            _patternData.counters.Add(counter);
        }

        public void removeCounter(List<CounterData> counters)
        {
            counters.ForEach(counter => { removeCounter(counter); });
        }

        public void removeCounter(CounterData counter)
        {
            CounterData existCounter = existingCounter(counter.number);
            bool counterNotExist = existCounter.Equals(default(CounterData));
            if (counterNotExist)
                return;

            _patternData.counters.Remove(existCounter);
        }

        private CounterData existingCounter(string number)
        {
            return _patternData.counters.FirstOrDefault(counter => counter.number == number);
        }

        public CalculationPatternData patternData => _patternData;
    }
}