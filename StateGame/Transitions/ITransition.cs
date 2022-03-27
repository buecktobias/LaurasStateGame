using Application.GameInformation;
using Application.States;

namespace Application.Transitions;

public interface ITransition<TGameInformation> where TGameInformation : IGameInformation
{
    public bool Matches(string input, TGameInformation gameInformation);
    public TGameInformation Execute(string input, TGameInformation rockPaperScissorGameInformation);
    public IState<TGameInformation> GetTargetState();
    public string GetOutput();
}