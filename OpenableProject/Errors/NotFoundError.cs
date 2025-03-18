namespace OpenableProject.Errors;

public class NotFoundError<T> :Error where T : class
{
    public NotFoundError() 
        : base(StatusCodes.Status404NotFound, $"{typeof(T).Name} not found.")
    {
    }
}