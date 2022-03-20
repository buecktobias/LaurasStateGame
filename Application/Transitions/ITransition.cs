namespace Application;

public interface ITransition
{
    public bool Matches(string input);
    public IState GetTargetState();
}