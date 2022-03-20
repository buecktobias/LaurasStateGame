namespace Application;

public interface IState
{
    public string GetIntroOutput();
    public ITransition GetMatchingTransitionInput(string input);
    public string GetOutroOutput();
    public bool IsEndState();
}