namespace Application;

public interface ITransitionFactory
{
    ITransition GetTransition(string identifier);
    ITransition GetNoMatchTransition();
}