namespace Git.Error
{
    public interface IError
    {
        string Message { get; }
        //HttpStatusCode StatusCode { get; }
    }
}
