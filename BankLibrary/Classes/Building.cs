namespace DZ10.Chapter11
{
    public class Building
    {
        public readonly Guid BuildingID;
        public string Address;
        internal Building(Guid buildingID, string address)
        {
            BuildingID = buildingID;
            Address = address;
        }
    }
}