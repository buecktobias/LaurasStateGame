namespace Application.Transitions;

public class QuitTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return input == "quit";
    }

    public override IState GetTargetState()
    {
        return StateFactory.GetQuitState();
    }

    public override string GetOutput()
    {
        return "Quit";
    }
}