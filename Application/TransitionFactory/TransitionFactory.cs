namespace Application;

public class TransitionFactory : ITransitionFactory
{
    public ITransition GetNoMatchTransition()
    {
        return GetQuitTransition();
    }

    public ITransition GetQuitTransition()
    {
        return new QuitTransition();
    }
    public ITransition GetTransition(string identifier)
    {
        throw new NotImplementedException();
    }
}