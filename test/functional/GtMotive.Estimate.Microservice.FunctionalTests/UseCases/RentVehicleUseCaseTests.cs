using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.ValueObjects;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.UseCases
{
    public class RentVehicleUseCaseTests
    {
        [Fact]
        public async Task ExecuteValidInputCallsStandardHandle()
        {
            var vehicleRepository = new Mock<IVehicleRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var outputPort = new Mock<IRentVehicleOutputPort>();
            var logger = new Mock<IAppLogger<RentVehicleUseCase>>();
            var vehicle = new VehicleEntity(VehicleId.NewId(), "Toyota Corolla", new ManufactureDate(DateTime.UtcNow.AddYears(-6)));
            vehicleRepository.Setup(r => r.GetBy(It.IsAny<VehicleId>())).ReturnsAsync(vehicle);
            vehicleRepository.Setup(r => r.HasActiveRental(It.IsAny<CustomerId>())).ReturnsAsync(false);
            var useCase = new RentVehicleUseCase(vehicleRepository.Object, unitOfWork.Object, outputPort.Object, logger.Object);

            var input = new RentVehicleInput(new VehicleId(Guid.NewGuid()), new CustomerId(Guid.NewGuid()));
            await useCase.Execute(input);

            outputPort.Verify(p => p.StandardHandle(It.IsAny<RentVehicleOutput>()), Times.Once());
        }
    }
}
