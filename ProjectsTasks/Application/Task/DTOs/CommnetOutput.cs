﻿namespace ProjectsTasks.Application.Task.DTOs
{
    public record CommnetOutput(string comment, DateTime createdAt, string author)
    {
        public static CommnetOutput With(string comment, DateTime createdAt, string author)
        {
            return new CommnetOutput(comment, createdAt, author);
        }
    }
}
