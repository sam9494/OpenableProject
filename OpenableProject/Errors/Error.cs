namespace OpenableProject.Errors;

public abstract class Error
{
    protected Error(int code, string message)
    {
        Code = code;
        Message = message;
    }

    public int Code { get; }
    public string Message { get; }
    
}