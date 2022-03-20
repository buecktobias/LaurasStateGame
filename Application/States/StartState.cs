namespace Application.States;

public class StartState : AbstractState
{
    public override string GetIntroOutput()
    {
        return "Game Has Started";
    }
}