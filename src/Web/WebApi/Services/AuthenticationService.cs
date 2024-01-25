﻿using Application.Common.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Services;

public class AuthenticationService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : IAuthenticationService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IConfiguration _configuration = configuration;

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);


    public string CreateAccessToken(string username, IList<string> roles)
    {

        // Crear las claims con el nombre de usuario
        var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, username) };

        // Agregar las claims de roles
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        // Configurar la clave secreta y las credenciales de firma
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        // Configurar las opciones del token JWT
        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpirationTime"]!)),
            signingCredentials: signinCredentials);

        // Generar el token JWT
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return tokenString;
    }
}
