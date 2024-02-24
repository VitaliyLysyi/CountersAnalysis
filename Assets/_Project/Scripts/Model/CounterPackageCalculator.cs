using System.Collections.Generic;

namespace CountersAnalysis
{
    public class CounterPackageCalculator
    {
        public CountersPackageData makeConsumptionPackageData(CountersPackage startPackage, CountersPackage endPackage, CalculationPattern calculationPattern)
        {
            CountersPackageData resultPackageData = new CountersPackageData();
            resultPackageData.counters = new List<CounterData>();
            CalculationPatternData patternData = calculationPattern.patternData;

            CounterData headCounter = patternData.headCounter;
            CounterData headCounterStart = startPackage.getCounterData(headCounter.number);
            CounterData headCounterEnd = endPackage.getCounterData(headCounter.number);
            resultPackageData.headCounter = calculateCounterConsumption(headCounterStart, headCounterEnd);

            patternData.counters.ForEach(counter =>
            {
                CounterData startCounter = startPackage.getCounterData(counter.number);
                CounterData endCounter = endPackage.getCounterData(counter.number);
                CounterData consumptionData = calculateCounterConsumption(startCounter, endCounter);
                resultPackageData.counters.Add(consumptionData);
            });

            return resultPackageData;
        }

        private CounterData calculateCounterConsumption(CounterData startCounter, CounterData endCounter)
        {
            string errorString = string.Empty;
            bool hasErrors = checkCountersForErrors(startCounter, endCounter, ref errorString);
            if (hasErrors)
            {
                CounterData counterWithError = new CounterData();
                counterWithError.hasError = true;
                counterWithError.errorNote = errorString;
                return counterWithError;
            }

            CounterData resultCounter = new CounterData();
            return resultCounter;
        }

        private bool checkCountersForErrors(CounterData startCounter, CounterData endCounter, ref string errorMessage)
        {
            bool startCounterIsNull = startCounter.Equals(default(CounterData));
            bool unavailableCounters = startCounterIsNull || endCounter.Equals(default(CounterData));
            if (unavailableCounters)
            {
                errorMessage = "UnAvailableCounters";
                return true;
            }

            bool diverseNumbers = startCounter.number != endCounter.number;
            if (diverseNumbers)
            {
                errorMessage = "DiverseNumbers";
                return true;
            }

            bool diverseCoeficient = startCounter.coefficient != endCounter.coefficient;
            if (diverseCoeficient)
            {
                errorMessage = "DiverseCoeficient";
                return true;
            }

            bool diverseAmountOfScales = startCounter.scales.Count != endCounter.scales.Count;
            if (diverseAmountOfScales)
            {
                errorMessage = "DiverseAmountOfScales";
                return true;
            }

            return false;
        }

        private CounterScaleData calculateScaleConsumption(CounterScaleData startScale, CounterScaleData endScale, int coefficient = 1)
        {
            string errorString = string.Empty;
            bool hasErrors = checkScalesForErrors(startScale, endScale, ref errorString);
            if (hasErrors)
            {
                CounterScaleData scaleWithError = new CounterScaleData();
                scaleWithError.isError = true;
                scaleWithError.errorNote = errorString;
                return scaleWithError;
            }

            CounterScaleData resultScale = endScale;
            resultScale.value = coefficient * (endScale.value - startScale.value);
            return resultScale;
        }

        private bool checkScalesForErrors(CounterScaleData startScale, CounterScaleData endScale, ref string errorMessage)
        {
            bool invalidValues = startScale.value == 0 || endScale.value == 0;
            if (invalidValues)
            {
                errorMessage = "InvalidValues";
                return true;
            }

            bool diverseZoneType = startScale.zoneType != endScale.zoneType;
            if (diverseZoneType)
            {
                errorMessage = "DiverseZoneType";
                return true;
            }

            bool diverseFlow = startScale.isBackward != endScale.isBackward;
            if (diverseFlow)
            {
                errorMessage = "DiverseFlow";
                return true;
            }

            bool hasErrorrs = startScale.isError || endScale.isError;
            if (hasErrorrs)
            {
                errorMessage = "DataInputError";
                return true;
            }

            return false;
        }
    }
}