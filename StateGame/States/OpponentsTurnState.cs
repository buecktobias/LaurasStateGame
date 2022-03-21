using Application.GameInformation;
using Application.TransitionFactory;

namespace Application.States;

public class OpponentsTurnState : AbstractState<IRockPaperScissorGameInformation,
    IRockPaperScissorTransitionFactory>
{
    private readonly Random _randomNumberGenerator;
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
        var num = _randomNumberGenerator.Next(0, 3);
        return new List<string> {"Schere", "Stein", "Papier"}[num];
    }

    public OpponentsTurnState() : base(RockPaperScissors.RockPaperScissorTransitionFactory.GetInstance())
    {
        _randomNumberGenerator = new Random();
    }
}