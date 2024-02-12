using System.Runtime.InteropServices;

namespace ProjectsTasks.Application.Task.DTOs
{
    public record AddCommentInput(string comment)
    {
        public static AddCommentInput With(string comment)
        {
            return new AddCommentInput(comment);
        }
    }
}
