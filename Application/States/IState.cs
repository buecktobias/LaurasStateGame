using Application.Transitions;

namespace Application;

public interface IState
{
    public string GetIntroOutput();
    public ITransition GetMatchingTransitionInput(string input, IGameInformation gameInformation);
    public string GetOutroOutput();
    public bool IsEndState();
    public IGameInformation Execute(IGameInformation gameInformation);
}