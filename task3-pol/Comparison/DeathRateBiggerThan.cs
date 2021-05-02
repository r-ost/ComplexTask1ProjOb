namespace Task3.Comparison
{
    public class DeathRateBiggerThan : IVirusDataComparison
    {
        private readonly double _val;
        public DeathRateBiggerThan(double val)
        {
            _val = val;
        }

        public bool Compare(VirusData a)
        {
            return a.DeathRate > _val;
        }
    }
}