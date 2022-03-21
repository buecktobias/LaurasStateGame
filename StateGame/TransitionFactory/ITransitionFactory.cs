using Application.GameInformation;
using Application.Transitions;

namespace Application.TransitionFactory;

public interface ITransitionFactory <TGameInformation>
where TGameInformation : IGameInformation
{
    public abstract ITransition<TGameInformation> GetNoMatchTransition();
}