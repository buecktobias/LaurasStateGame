using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public class SimpleState<TGameInformation, TTransitionFactory> : AbstractState<TGameInformation, TTransitionFactory>
    where TGameInformation : IGameInformation
    where TTransitionFactory : ITransitionFactory<TGameInformation>
{
    public SimpleState(TTransitionFactory transitionFactory) : base(transitionFactory)
    {
        IntroOutput = "";
        OutroOutput = "";
        EndState = false;
        NewTransitions = new List<ITransition<TGameInformation>>();
        ExecuteFunc = _ => _;
        NeedsInput = true;
    }

    public string IntroOutput { get; set; }
    public string OutroOutput { get; set; }
    public bool EndState { get; set; }
    public bool NeedsInput { get; set; }

    public IList<ITransition<TGameInformation>> NewTransitions { get; set; }
    public ExecutionFunction ExecuteFunc { get; set; }


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
        foreach (var transition in NewTransitions) Transitions.Add(transition);
    }

    public override bool NeedsUserInput()
    {
        return NeedsInput;
    }
}