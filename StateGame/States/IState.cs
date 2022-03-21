using Application.GameInformation;
using Application.Transitions;

namespace Application.States;

public delegate IGameInformation ExecutionFunction(IGameInformation gameInformation);
public interface IState <TGameInformation> where TGameInformation : IGameInformation
{
    public string GetIntroOutput();
    public ITransition<TGameInformation> GetMatchingTransitionInput(string input, TGameInformation gameInformation);
    public string GetOutroOutput();
    public bool IsEndState();
    public TGameInformation Execute(TGameInformation gameInformation);
    public void CreateTransitions();
}