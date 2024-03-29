﻿using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Services.Interfaces
{
    public interface IUserService
    {
        public CreateUserOutput CreateUser(CreateUserInput input);

        public LoginOutPut Login(LoginInput input);

    }
}
