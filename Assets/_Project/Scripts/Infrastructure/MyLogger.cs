using UnityEngine;

namespace CountersAnalysis
{
    public static class MyLogger
    {
        public static void LogPackage(CountersPackageData package)
        {
            Debug.Log("===PACKAGE " +  package + "===");
            Debug.Log("===DATE " + package.date + "===");
            Debug.Log("Note = " + package.note);
            Debug.Log("Head Counter:");
            LogCounter(package.headCounter);
            if (package.counters != null)
            {
                Debug.Log("Counters Count = " + package.counters.Count + " ===>");
                foreach (CounterData counter in package.counters)
                {
                    LogCounter(counter);
                }
            }
        }

        public static void LogCounter(CounterData counter, int spacing = 20)
        {
            string spacingString = new string('=', spacing);
            Debug.Log(spacingString);
            Debug.Log("Counter number = " + counter.number
                + " Coeficient = " + counter.coeficient
                );
            Debug.Log("Note = " + counter.note);
            if (counter.scales != null)
            {
                foreach (CounterScaleData scale in counter.scales)
                {
                    LogScale(scale);
                }
            }
        }

        public static void LogScale(CounterScaleData scale, int spacing = 5)
        {
            string spacingString = new string('.', spacing); 
            Debug.Log(spacingString 
                + "Scale = " + scale.zoneNumber 
                + " Value = " + scale.value 
                + " IsActive = " + scale.isActive 
                + " IsBackward = " + scale.isBackward
                + " IsErrored = " + scale.isErrored
                );
        }
    }
}