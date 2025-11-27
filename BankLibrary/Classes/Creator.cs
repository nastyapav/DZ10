namespace DZ10.Chapter11
{
    public class Creator
    {
        private static readonly Dictionary<Guid, Building> _buildings = new Dictionary<Guid, Building>();
        private Creator()
        {
           
        }
        public static Guid CreateBuild(string address)
        {
            Guid id = Guid.NewGuid();
            var building = new Building(id, address);
            _buildings[id] = building;
            return id;
        }
        public static bool RemoveBuild(Guid buildingId)
        {
            return _buildings.Remove(buildingId);
        }
    }
}