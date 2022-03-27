using Application.GameInformation;
using Application.Transitions;

namespace Application.TransitionFactory;

public interface ITransitionFactory<TGameInformation>
    where TGameInformation : IGameInformation
{
    public ITransition<TGameInformation> GetNoMatchTransition();
}