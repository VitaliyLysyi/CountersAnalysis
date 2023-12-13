namespace CountersAnalysis
{
    public interface IRegistrable
    {
        public RegisterElementData getRegistrableData();

        public void updateRegistrableData(RegisterElementData registrableData);
    }
}