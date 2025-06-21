﻿namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output port for the list available vehicles use case.
    /// </summary>
    public interface IListAvailableVehiclesOutputPort : IOutputPortStandard<ListAvailableVehiclesOutput>, IOutputPortNotFound
    {
    }
}
