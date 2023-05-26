﻿using Application.Common.Models.Auth;

namespace Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
        Task<string> GenerateEmailActivationToken(string userId, CancellationToken cancellationToken);
        Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken);

        Task<JwtDto> LoginAsync(AuthLoginRequest authLoginRequest, CancellationToken cancellationToken);
    }
}
