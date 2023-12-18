namespace CountersAnalysis
{
    public interface IRegistrable
    {
        public RegistrableData getRegistrableData();

        public void updateRegistrableData(RegistrableData registrableData);
    }
}