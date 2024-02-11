﻿namespace ProjectsTasks.Application.User
{
    public record UserRoleInput( RoleInput Role, int RoleId, int UserId  )
    {
        public static UserRoleInput With(RoleInput Role, int RoleId, int UserId)
        {
            return new UserRoleInput(Role, RoleId, UserId);
        }
    }
}
