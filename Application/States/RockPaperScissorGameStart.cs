namespace Application.States;

public class RockPaperScissorGameStart : AbstractState
{
    public override void CreateTransitions()
    {
        Transitions.Add(TransitionFactory.GetGamePlayTransition());
    }

    public override string GetIntroOutput()
    {
        return "Willkommen bei Schere Stein Papier! \n" +
               "Gebe entweder Schere, Stein oder Papier ein \n" +
               "Schere,Stein, Papier!";
    }
}