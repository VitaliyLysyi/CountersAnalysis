using System.Collections.Generic;

namespace CountersAnalysis
{
    public static class CalculationService
    {
        public static CounterScaleData scaleConsumption(CounterScaleData startScale, CounterScaleData endScale, int coeficient)
        {
            CounterScaleData scale = endScale;
            scale.value = 0;
            bool valuesAvailable = startScale.value != 0 && endScale.value != 0;
            if (valuesAvailable)
            {
                scale.value = (endScale.value - startScale.value) * coeficient;
            }
            scale.isError = !valuesAvailable;
            return scale;
        }

        public static CounterData counterConsumption(CounterData startCounter, CounterData endCounter)
        {
            CounterData counter = endCounter;
            int scaleCount = endCounter.scales.Count;
            counter.scales = new List<CounterScaleData>(scaleCount);
            for (int i = 0; i < scaleCount; i++)
            {
                counter.scales[i] = scaleConsumption(startCounter.scales[i], endCounter.scales[i], counter.coeficient);
            }
            return counter;
        }
    }
}