namespace Task3.Mapping
{
    public class AddToDeathRate : IVirusDataMap
    {
        private readonly double _val;

        public AddToDeathRate(double val)
        {
            _val = val;
        }

        public VirusData Map(VirusData x)
        {
            return new VirusData(x.VirusName, x.DeathRate + _val,
                x.InfectionRate, x.Genomes);
        }
    }
}