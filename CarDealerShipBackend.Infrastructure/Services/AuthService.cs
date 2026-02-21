using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CarDealerShipBackend.Application.DTOs;
using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Constants;
using CarDealerShipBackend.Domain.Entities;

namespace CarDealerShipBackend.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null) throw new Exception("User already exists");

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registration failed: {errors}");
            }

            var roleToAssign = Roles.User;
            await AddToRoleAsync(user, roleToAssign);

            if (roleToAssign == Roles.Admin)
            {
                await _userManager.AddClaimAsync(user, new Claim("Permission", Permissions.CanManageUsers));
                await _userManager.AddClaimAsync(user, new Claim("Permission", Permissions.CanViewDashboard));
            }
            else
            {
                // Normal user specific permission
                await _userManager.AddClaimAsync(user, new Claim("Permission", Permissions.CanEditProfile));
            }

            return await GenerateAuthResponse(user);
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Invalid credentials");
            }

            return await GenerateAuthResponse(user);
        }

        // Helper to Create Token
        private async Task<AuthResponse> GenerateAuthResponse(ApplicationUser user)
        {
            // var userRoles = await _userManager.GetRolesAsync(user);
            // var userClaims = await _userManager.GetClaimsAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id)
            };

            // foreach (var role in userRoles)
            // {
            //     authClaims.Add(new Claim(ClaimTypes.Role, role));
            // }

            // var permissions = new List<string>();
            // foreach (var claim in userClaims.Where(c => c.Type == "Permission"))
            // {
            //     authClaims.Add(claim);
            //     permissions.Add(claim.Value);
            // }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new AuthResponse(
                user.Id,
                user.Email!,
                new JwtSecurityTokenHandler().WriteToken(token)
                // userRoles.ToList(),
                // permissions
            );
        }

        private async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}