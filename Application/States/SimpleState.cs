using Application.Transitions;

namespace Application.States;

public class SimpleState : AbstractState
{
    public string IntroOutput { get; set; }
    public string OutroOutput { get; set; }
    public bool EndState { get; set; }
    
    public IList<ITransition> NewTransitions { get; set; }
    public Func<IGameInformation, IGameInformation> ExecuteFunc { get; set; }

    public SimpleState(
        string introOutput ="",
        IList<ITransition>? transitions = null,
        string outroOutput = "",
        bool isEndState = false,
        Func<IGameInformation, IGameInformation>? executeFunc = null)
    {
        IntroOutput = introOutput;
        OutroOutput = outroOutput;
        EndState = isEndState;
        NewTransitions = transitions ?? new List<ITransition>();
        ExecuteFunc = executeFunc ?? (information => information) ;

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

    protected override void CreateTransitions()
    {
        foreach (var transition in NewTransitions)
        {
            Transitions.Add(transition);
        }
    }
}