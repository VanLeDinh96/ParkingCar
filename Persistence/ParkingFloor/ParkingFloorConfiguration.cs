using Microsoft.EntityFrameworkCore;
using Domain.ParkingFloor;

namespace Persistence
{
    internal class ParkingFloorConfiguration : IEntityTypeConfiguration<ParkingFloor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ParkingFloor> builder)
        {
            throw new NotImplementedException();
        }
    }
}
