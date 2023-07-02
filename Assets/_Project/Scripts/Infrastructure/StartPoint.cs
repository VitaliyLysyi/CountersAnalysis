using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public enum CountersPackageType
    {
        PowerConsumption,
        CountersData
    }

    public class StartPoint : MonoBehaviour
    {
        [SerializeField] private MainWindow _mainWindowContentPanel;
        private CountersPackageRegister _packageRegister;
        private DataController _dataController;

        private void Start()
        {
            _packageRegister = new CountersPackageRegister();
            _packageRegister.loadRegister();

            _dataController = new DataController();
            _dataController.init(_packageRegister, _mainWindowContentPanel);
        }

        //private CountersPackageData makeConsumptionPackage(
        //            //CounterData headCounter,
        //            CountersPackageData startData,
        //            CountersPackageData endData)
        //{
        //    CountersPackageData consumptionPackage = new CountersPackageData();
        //    consumptionPackage.date = endData.date;
        //    consumptionPackage.note = CountersPackageType.PowerConsumption.ToString();
        //    //consumptionPackage.headCounter = headCounter;
        //    consumptionPackage.counters = new List<CounterData>();

        //    CounterData matchCounter = new CounterData();
        //    foreach (CounterData counter in endData.counters)
        //    {
        //        if (findMatchCounter(counter, out matchCounter, startData.counters))
        //        {
        //            CounterData counterConsumptionData = createConsumptionData(matchCounter, counter);
        //            consumptionPackage.counters.Add(counterConsumptionData);
        //        }
        //    }

        //    return consumptionPackage;
        //}

        //private bool findMatchCounter(CounterData counterReference, out CounterData matchCounter, List<CounterData> counters)
        //{
        //    matchCounter = counters.FirstOrDefault(counter => counter.number == counterReference.number);
        //    bool found = !matchCounter.Equals(default(CounterData));
        //    return found;
        //}

        //private CounterData createConsumptionData(CounterData startData, CounterData endData)
        //{
        //    CounterData counter = new CounterData();
        //    counter.number = endData.number;
        //    counter.note = endData.note;
        //    counter.coeficient = endData.coeficient;
        //    counter.scales = new List<CounterScaleData>();

        //    int minLenght = Mathf.Min(startData.scales.Count, endData.scales.Count);
        //    for (int i = 0; i < minLenght; i++)
        //    {
        //        bool boothScalesIsActive = startData.scales[i].isActive && endData.scales[i].isActive;
        //        if (boothScalesIsActive)
        //        {
        //            int coeficient = endData.coeficient == 0 ? 1 : endData.coeficient;
        //            CounterScaleData scale = calculateConsumtion(coeficient, startData.scales[i], endData.scales[i]);
        //            counter.scales.Add(scale);
        //        }
        //        else
        //        {
        //            CounterScaleData scale = endData.scales[i];
        //            scale.value = 0;
        //        }
        //    }

        //    return counter;
        //}

        //private CounterScaleData calculateConsumtion(int coeficient, CounterScaleData startScale, CounterScaleData endScale)
        //{
        //    CounterScaleData scale = new CounterScaleData();
        //    scale.zoneNumber = endScale.zoneNumber;
        //    scale.isActive = endScale.isActive;
        //    scale.isBackward = endScale.isBackward;

        //    bool valuesAvailable = startScale.value != 0 && endScale.value != 0;
        //    if (valuesAvailable)
        //    {
        //        scale.value = (endScale.value - startScale.value) * coeficient;
        //        scale.isErrored = false;
        //    }
        //    else
        //    {
        //        scale.value = 0;
        //        scale.isErrored = true;
        //    }

        //    return scale;
        //}
    }
}