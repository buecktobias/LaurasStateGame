namespace Application.Exceptions;

public class TargetStateNotSetException : Exception
{
    public override string Message => " Transitions Target State Not Set " + base.Message;
}