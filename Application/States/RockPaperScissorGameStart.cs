namespace Application;

public class RockPaperScissorGameStart : AbstractState
{
    public override void CreateTransitions()
    {
        this.Transitions.Add(_transitionFactory.GetGamePlayTransition());
    }

    public override string GetIntroOutput()
    {
        return "Willkommen bei Schere Stein Papier! \n" +
               "Gebe entweder Schere, Stein oder Papier ein \n" +
               "Schere,Stein, Papier!";
    }

    public override string GetOutroOutput()
    {
        return "";
    }

    public override bool IsEndState()
    {
        return false;
    }

    public override IGameInformation Execute(IGameInformation gameInformation)
    {
        return gameInformation;
    }
}