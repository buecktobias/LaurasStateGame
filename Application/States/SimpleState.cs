using Application.Transitions;

namespace Application.States;

public class SimpleState : AbstractState
{
    public string IntroOutput { get; set; }
    public string OutroOutput { get; set; }
    public bool EndState { get; set; }
    
    
    public SimpleState(
        string introOutput ="",
        List<ITransition>? transitions = null,
        string outroOutput = "",
        bool isEndState = false,
        Func<IGameInformation, IGameInformation>? executeFunc = null)
    {
        IntroOutput = introOutput;
        OutroOutput = outroOutput;
        EndState = isEndState;

    }
    
    public override string GetIntroOutput()
    {
        return base.GetIntroOutput();
    }

    public override string GetOutroOutput()
    {
        return base.GetOutroOutput();
    }

    public override bool IsEndState()
    {
        return base.IsEndState();
    }

    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        return base.Execute(gameInformation);
    }

    protected override void CreateTransitions()
    {
        base.CreateTransitions();
    }
}