﻿namespace ez_park_platform.Users.Domain.Model.Commands
{
    public record CreateUserCommand(string Email, string Password, string FirstName, string LastName, string Dni, string Phone, DateTime DateOfBirth);
}
