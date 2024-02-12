﻿namespace ProjectsTasks.Application.Task
{
    public record ChangeDescription(string description, int taskId, string email)
    {
        public static ChangeDescription With(string description, int taskId, string email = "")
        {
            return new ChangeDescription(description, taskId, email);
        }
    }
}
