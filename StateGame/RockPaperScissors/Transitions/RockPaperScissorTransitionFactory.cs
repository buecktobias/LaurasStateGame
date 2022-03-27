using Application.GameInformation;
using Application.StateFactory;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.RockPaperScissors;

public class RockPaperScissorTransitionFactory : IRockPaperScissorTransitionFactory
{
    private static RockPaperScissorTransitionFactory? _instance;
    private readonly IRockPaperScissorStateFactory _rockPaperScissorStateFactory;


    private RockPaperScissorTransitionFactory()
    {
        _rockPaperScissorStateFactory = RockPaperScissorStateFactory.GetInstance();
    }

    private ITransition<IRockPaperScissorGameInformation>? GameWonTransition { get; set; }
    private ITransition<IRockPaperScissorGameInformation>? GameDrawTransition { get; set; }
    private ITransition<IRockPaperScissorGameInformation>? GameLostTransition { get; set; }
    private ITransition<IRockPaperScissorGameInformation>? GamePlayTransition { get; set; }
    private ITransition<IRockPaperScissorGameInformation>? QuitTransition { get; set; }
    private ITransition<IRockPaperScissorGameInformation>? WrongInputTransition { get; set; }

    public ITransition<IRockPaperScissorGameInformation> GetNoMatchTransition()
    {
        return GetQuitTransition();
    }


    public ITransition<IRockPaperScissorGameInformation> GetGameWonTransition()
    {
        if (GameWonTransition != null) return GameWonTransition;

        bool MatchFunc(string s, IGameInformation info)
        {
            var gameInformation = (IRockPaperScissorGameInformation) info;
            var gameResult = new GameEngine().GetGameResult(gameInformation.PlayerInformation,
                gameInformation.OpponentInformation);
            return gameResult == GameResult.Won;
        }

        var gameWonTransitionBuilder = new TransitionBuilder();
        gameWonTransitionBuilder.SetMatchFunc(MatchFunc);
        gameWonTransitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
        gameWonTransitionBuilder.SetOutput("Yeah Sie haben gewonnen!");
        GameWonTransition = gameWonTransitionBuilder.GetTransition();
        return GameWonTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGameDrawTransition()
    {
        if (GameDrawTransition != null) return GameDrawTransition;

        bool MatchFunc(string s, IGameInformation info)
        {
            var information = (IRockPaperScissorGameInformation) info;
            return information.OpponentInformation == information.PlayerInformation;
        }

        var transitionBuilder = new TransitionBuilder();
        transitionBuilder.SetMatchFunc(MatchFunc);
        transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetGameStartState());
        transitionBuilder.SetOutput("Unentschieden ! Nächste Runde !");

        GameDrawTransition = transitionBuilder.GetTransition();
        return GameDrawTransition;
    }


    public ITransition<IRockPaperScissorGameInformation> GetGameLostTransition()
    {
        if (GameLostTransition != null) return GameLostTransition;

        bool MatchFunc(string _, IGameInformation info)
        {
            var gameInformation = (IRockPaperScissorGameInformation) info;
            var result = new GameEngine().GetGameResult(gameInformation.PlayerInformation,
                gameInformation.OpponentInformation);
            return result == GameResult.Lost;
        }

        var transitionBuilder = new TransitionBuilder();
        transitionBuilder.SetMatchFunc(MatchFunc);
        transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
        transitionBuilder.SetOutput("Sie haben leider verloren!");
        GameLostTransition = transitionBuilder.GetTransition();
        return GameLostTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGamePlayTransition()
    {
        if (GamePlayTransition != null) return GamePlayTransition;
        var transitionBuilder = new TransitionBuilder();
        transitionBuilder.SetExecuteFunc((s, info) =>
        {
            var information = (IRockPaperScissorGameInformation) info;
            information.PlayerInformation = (GameSymbol) new SymbolInputReader()!.ReadSymbol(s);
            return information;
        });
        transitionBuilder.SetMatchFunc((text, _) => new SymbolInputReader().ReadSymbol(text) != null);
        transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetOpponentsTurnState());
        GamePlayTransition = transitionBuilder.GetTransition();
        return GamePlayTransition;
    }

    public static RockPaperScissorTransitionFactory GetInstance()
    {
        return _instance ??= new RockPaperScissorTransitionFactory();
    }

    public ITransition<IRockPaperScissorGameInformation> GetQuitTransition()
    {
        if (QuitTransition != null) return QuitTransition;
        var transitionBuilder = new TransitionBuilder();
        transitionBuilder.SetMatchFunc((s, information) => s == "quit");
        transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
        QuitTransition = transitionBuilder.GetTransition();
        return QuitTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetWrongInputTransition()
    {
        if (WrongInputTransition != null) return WrongInputTransition;
        var transitionBuilder = new TransitionBuilder();
        transitionBuilder.SetOutput("Sie haben eine falsche Eingabe getätigt!");
        transitionBuilder.SetMatchFunc((s, _) => new SymbolInputReader().ReadSymbol(s) == null);
        transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
        WrongInputTransition = transitionBuilder.GetTransition();

        return WrongInputTransition;
    }
}