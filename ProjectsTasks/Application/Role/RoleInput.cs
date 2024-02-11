﻿namespace ProjectsTasks.Application.User
{
    public record RoleInput(int Id, string Name)
    {
        public static RoleInput With(int Id, string Name) 
        {
            return new RoleInput(Id, Name);
        }
    }
}
