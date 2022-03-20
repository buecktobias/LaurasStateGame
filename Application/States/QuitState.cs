namespace Application;

public class QuitState : AbstractState
{
    public override void CreateTransitions()
    {
    }

    public override string GetIntroOutput()
    {
        return "Das Spiel wurde beendet";
    }

    public override string GetOutroOutput()
    {
        return "";
    }

    public override bool IsEndState()
    {
        return true;
    }

    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        return gameInformation;
    }
}