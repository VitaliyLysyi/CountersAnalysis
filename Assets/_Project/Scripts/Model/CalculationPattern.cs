using System.IO;

namespace CountersAnalysis
{
    public class CalculationPattern : IRegistrable
    {
        private RegisterElementData _registrableData;
        private CalculationPatternData _calculationPatternData;

        public CalculationPattern() { }

        public CalculationPattern(CalculationPatternData calculationPatternData, string path)
        {
            _calculationPatternData = calculationPatternData;

            _registrableData.path = path;
            _registrableData.name = Path.GetFileNameWithoutExtension(path);
            _registrableData.elementType = RegistredDataType.CalculationPattern.ToString();
        }

        public RegisterElementData getRegistrableData()
        {
            return _registrableData;
        }

        public void updateRegistrableData(RegisterElementData registrableData)
        {
            _registrableData = registrableData;
        }
    }
}