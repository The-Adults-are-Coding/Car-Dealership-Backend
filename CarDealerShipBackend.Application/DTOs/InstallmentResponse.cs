using System;

namespace CarDealerShipBackend.Application.DTOs
{
    public record InstallmentResponse(
        decimal InstallmentId,
        decimal Amount,
        DateTime DueDate,
        string Status
    );
}