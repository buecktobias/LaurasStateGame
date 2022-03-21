using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;
namespace Application.States;

public class SimpleState<TGameInformation, TTransitionFactory> : AbstractState<TGameInformation, TTransitionFactory>
where TGameInformation : IGameInformation
where TTransitionFactory : ITransitionFactory<TGameInformation>
{
    internal string IntroOutput { get; set; }
    internal string OutroOutput { get; set; }
    internal bool EndState { get; set; }

    internal IList<ITransition<TGameInformation>> NewTransitions { get; set; }
    internal ExecutionFunction ExecuteFunc { get; set; }

    internal SimpleState(TTransitionFactory transitionFactory) : base(transitionFactory)
    {
        IntroOutput = "";
        OutroOutput = "";
        EndState = false;
        NewTransitions = new List<ITransition<TGameInformation>>();
        ExecuteFunc = (_ => _);
    }


    public override string GetIntroOutput()
    {
        return IntroOutput;
    }

    public override string GetOutroOutput()
    {
        return OutroOutput;
    }

    public override bool IsEndState()
    {
        return EndState;
    }

    public override TGameInformation Execute(TGameInformation rockPaperScissorGameInformation)
    {
        return (TGameInformation) ExecuteFunc(rockPaperScissorGameInformation);
    }

    public override void CreateTransitions()
    {
        foreach (var transition in NewTransitions)
        {
            Transitions.Add(transition);
        }
    }
}