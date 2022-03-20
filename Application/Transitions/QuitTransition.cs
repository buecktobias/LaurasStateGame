namespace Application;

public class QuitTransition : AbstractTransition
{
    public override bool Matches(string input)
    {
        return input == "quit";
    }

    public override IState GetTargetState()
    {
        return this.StateFactory.GetQuitState();
    }
}