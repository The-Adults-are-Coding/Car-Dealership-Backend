namespace CarDealerShipBackend.Application.DTOs
{
    public record CarResponse(
        decimal CarId,
        string Manufacturer,
        string ModelName,
        int CarYear,
        string Color,
        string CarCondition,
        decimal? Price,
        long? Mileage
    );
}