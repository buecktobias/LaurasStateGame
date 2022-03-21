using Application.GameInformation;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public class SimpleState<TGameInformation, TTransitionFactory> : AbstractState<TGameInformation, TTransitionFactory>
where TGameInformation : IGameInformation
where TTransitionFactory : ITransitionFactory<TGameInformation>
{
    private string IntroOutput { get; set; }
    private string OutroOutput { get; set; }
    private bool EndState { get; set; }

    private IList<ITransition<TGameInformation>> NewTransitions { get; set; }
    private Func<TGameInformation, TGameInformation> ExecuteFunc { get; set; }
    
    public SimpleState(string introOutput, TTransitionFactory transitionFactory):this(introOutput, new List<ITransition<TGameInformation>>(), transitionFactory){}
    public SimpleState(string introOutput, IList<ITransition<TGameInformation>> newTransitions, TTransitionFactory transitionFactory):
        this(introOutput, newTransitions, "", false, transitionFactory)
    {
    }

    public SimpleState(string introOutput, IList<ITransition<TGameInformation>> newTransitions, string outroOutput, bool endState, TTransitionFactory transitionFactory):
        this(introOutput, newTransitions, outroOutput, endState, (information) => information, transitionFactory) { }

    public SimpleState(
        string introOutput,
        IList<ITransition<TGameInformation>> transitions,
        string outroOutput,
        bool isEndState,
        Func<TGameInformation, TGameInformation> executeFunc,
        TTransitionFactory transitionFactory) : base(transitionFactory)
    {
        IntroOutput = introOutput;
        OutroOutput = outroOutput;
        EndState = isEndState;
        NewTransitions = transitions;
        ExecuteFunc = executeFunc;
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
        return ExecuteFunc(rockPaperScissorGameInformation);
    }

    public override void CreateTransitions()
    {
        foreach (var transition in NewTransitions)
        {
            Transitions.Add(transition);
        }
    }
}