using Application.GameInformation;
using Application.RockPaperScissors;
using Application.TransitionFactory;

namespace Application.States;

public class OpponentsTurnState : AbstractState<IRockPaperScissorGameInformation,
    IRockPaperScissorTransitionFactory>
{
    private readonly Random _randomNumberGenerator;

    public OpponentsTurnState() : base(RockPaperScissors.RockPaperScissorTransitionFactory.GetInstance())
    {
        _randomNumberGenerator = new Random();
    }

    public override void CreateTransitions()
    {
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameDrawTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameLostTransition());
        Transitions.Add(RockPaperScissorTransitionFactory.GetGameWonTransition());
    }

    public override bool NeedsUserInput()
    {
        return false;
    }

    public override string GetIntroOutput()
    {
        return "Opponents turn";
    }


    public override IRockPaperScissorGameInformation Execute(
        IRockPaperScissorGameInformation rockPaperScissorGameInformation)
    {
        rockPaperScissorGameInformation.OpponentInformation = GetRandom();
        Console.WriteLine("Der Gegner hat " + rockPaperScissorGameInformation.OpponentInformation + " gewählt.");
        return rockPaperScissorGameInformation;
    }

    private GameSymbol GetRandom()
    {
        var num = _randomNumberGenerator.Next(0, 3);
        return new List<GameSymbol> {GameSymbol.Stone, GameSymbol.Stone, GameSymbol.Paper}[num];
    }
}