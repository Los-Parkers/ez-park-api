﻿using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Users.Domain.Model.Aggregates;
using ez_park_platform.Users.Domain.Model.Commands;
using ez_park_platform.Users.Domain.Repositories;
using ez_park_platform.Users.Domain.Services;

namespace ez_park_platform.EzPark.Application.Internal.CommandServices
{
    public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
    {
        public async Task<User?> Handle(CreateUserCommand command)
        {

            User user = new(command);

            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine($"It seems that something bad happened. {e.Message}");
                return null;
            }
        }
    }
}