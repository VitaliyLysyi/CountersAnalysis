using System.Linq;
using UnityEngine;

namespace CountersAnalysis
{
    public static class MyDebugger
    {
        private static System.Random random = new System.Random();

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void log(string message)
        {
            Debug.Log(message);
        }

        public static void logRegisterElementDeployed(RegisterElementData registerElement)
        {
            Debug.Log("===REGISTER ELEMENT " + registerElement.name + "===");
            Debug.Log("===ID " + registerElement.registerID + "===");
            Debug.Log("Path = " + registerElement.path);
            Debug.Log("Date = " + registerElement.date);
            Debug.Log("Data Type = " + registerElement.elementType);
            Debug.Log("Note = " + registerElement.note);
        }

        public static void logPackageDeployed(CountersPackageData package)
        {
            Debug.Log("===PACKAGE " +  package + "===");
            Debug.Log("===DATE " + package.date + "===");
            Debug.Log("Note = " + package.note);
            Debug.Log("Head Counter:");
            logCounterDeployed(package.headCounter);
            if (package.counters != null)
            {
                Debug.Log("Counters Count = " + package.counters.Count + " ===>");
                foreach (CounterData counter in package.counters)
                {
                    logCounterDeployed(counter);
                }
            }
        }

        public static void logCounterDeployed(CounterData counter, int spacing = 20)
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
                    logScaleDeployed(scale);
                }
            }
        }

        public static void logScaleDeployed(CounterScaleData scale, int spacing = 5)
        {
            string spacingString = new string('.', spacing); 
            Debug.Log(spacingString 
                + "Scale = " + scale.zoneType 
                + " Value = " + scale.value 
                + " IsActive = " + scale.isActive 
                + " IsBackward = " + scale.isBackward
                + " IsErrored = " + scale.isError
                );
        }
    }
}