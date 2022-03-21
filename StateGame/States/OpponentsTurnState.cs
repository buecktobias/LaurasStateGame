using Application.GameInformation;
using Application.TransitionFactory;

namespace Application.States;

public class OpponentsTurnState : AbstractState<IRockPaperScissorGameInformation,
    IRockPaperScissorTransitionFactory>
{
    public override void CreateTransitions()
    {
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameDrawTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameLostTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameWonTransition());
    }

    public override string GetIntroOutput()
    {
        return "Opponents turn";
    }


    public override IRockPaperScissorGameInformation Execute(IRockPaperScissorGameInformation rockPaperScissorGameInformation)
    {
        rockPaperScissorGameInformation.OpponentInformation = GetRandom();
        Console.WriteLine("Der Gegner hat " + rockPaperScissorGameInformation.OpponentInformation + " gewählt.");
        return rockPaperScissorGameInformation;
    }

    private string GetRandom()
    {
        var random = new Random();
        var num = random.Next(0, 3);
        return new List<string> {"Schere", "Stein", "Papier"}[num];
    }

    public OpponentsTurnState() : base(TransitionFactory.RockPaperScissorTransitionFactory.GetInstance())
    {
    }
}