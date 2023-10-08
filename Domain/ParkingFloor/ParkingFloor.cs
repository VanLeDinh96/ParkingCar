using URF.Core.EF.Trackable;

namespace Domain.ParkingFloor
{
    public partial class ParkingFloor : Entity
    {
        public int ParkingFloorId { get; set; }
        public string? FloorNumber { get; set; }
    }
}
