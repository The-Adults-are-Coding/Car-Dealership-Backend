namespace CarDealerShipBackend.Application.DTOs
{
    public record CustomerCarResponse(
        decimal CarId,
        string Manufacturer,
        string ModelName,
        int CarYear,
        decimal? Price,
        string ContractNumber,
        DateTime SaleDate
    );
}