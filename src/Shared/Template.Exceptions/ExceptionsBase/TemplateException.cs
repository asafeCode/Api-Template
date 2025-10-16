using System.Net;

namespace MyRecipeBook.Exceptions.ExceptionsBase;

public abstract class TemplateException : SystemException
{
    protected TemplateException(string messages) : base(messages) {}

    public abstract HttpStatusCode GetStatusCode();
    public abstract IList<string> GetErrorMessage();

}
