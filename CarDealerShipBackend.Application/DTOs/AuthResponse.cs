using System.ComponentModel.DataAnnotations;

namespace CarDealerShipBackend.Application.DTOs
{
  public record AuthResponse(
      string Id,
      string Email,
      string Token
  // List<string> Roles,
  // List<string> Permissions
  );
}