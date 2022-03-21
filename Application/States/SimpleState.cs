using Application.Transitions;

namespace Application.States;

public class SimpleState : AbstractState
{
    private string IntroOutput { get; set; }
    private string OutroOutput { get; set; }
    private bool EndState { get; set; }

    private IList<ITransition> NewTransitions { get; set; }
    private Func<IGameInformation, IGameInformation> ExecuteFunc { get; set; }

    public SimpleState(string introOutput):this(introOutput, new List<ITransition>()){}
    public SimpleState(string introOutput, IList<ITransition> newTransitions):
        this(introOutput, newTransitions, "", false)
    {
    }

    public SimpleState(string introOutput, IList<ITransition> newTransitions, string outroOutput, bool endState):
        this(introOutput, newTransitions, outroOutput, endState, (information) => information) { }

    public SimpleState(
        string introOutput,
        IList<ITransition> transitions,
        string outroOutput,
        bool isEndState,
        Func<IGameInformation, IGameInformation> executeFunc)
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

    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        return ExecuteFunc(gameInformation);
    }

    public override void CreateTransitions()
    {
        foreach (var transition in NewTransitions)
        {
            Transitions.Add(transition);
        }
    }
}