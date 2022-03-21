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

    public ITransition<IRockPaperScissorGameInformation> GetNoMatchTransition()
    {
        return GetQuitTransition();
    }


    public ITransition<IRockPaperScissorGameInformation> GetGameWonTransition()
    {
        if (this.GameWonTransition == null)
        {
            bool MatchFunc(string s, IGameInformation info)
            {
                var gameInformation = (IRockPaperScissorGameInformation) info;
                var gameResult = new GameEngine().GetGameResult(gameInformation.PlayerInformation,
                    gameInformation.OpponentInformation);
                return gameResult == GameResult.Won;
            }

            var transitionBuilder = new TransitionBuilder();
            transitionBuilder.SetMatchFunc(MatchFunc);
            transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
            transitionBuilder.SetOutput("Yeah Sie haben gewonnen!");
            GameWonTransition = transitionBuilder.GetTransition();
        }
        return GameWonTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGameDrawTransition()
    {
        if (this.GameDrawTransition == null)
        {
            TransitionMatchFunc matchFunc = (s, info) =>
            {
                var information = (IRockPaperScissorGameInformation) info;
                return information.OpponentInformation == information.PlayerInformation;
            };
            var transitionBuilder = new TransitionBuilder();
            transitionBuilder.SetMatchFunc(matchFunc);
            transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetGameStartState());
            transitionBuilder.SetOutput("Unentschieden ! Nächste Runde !");

            GameDrawTransition = transitionBuilder.GetTransition();
        }
        return GameDrawTransition;
    }
    

    public ITransition<IRockPaperScissorGameInformation> GetGameLostTransition()
    {
        if (this.GameLostTransition == null)
        {
            TransitionMatchFunc matchFunc = (_, info) =>
            {
                var gameInformation = (IRockPaperScissorGameInformation) info;
                var result =new GameEngine().GetGameResult(gameInformation.PlayerInformation, gameInformation.OpponentInformation);
                return result == GameResult.Lost;
            };
            var transitionBuilder = new TransitionBuilder();
            transitionBuilder.SetMatchFunc(matchFunc);
            transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
            transitionBuilder.SetOutput("Sie haben leider verloren!");
            GameLostTransition = transitionBuilder.GetTransition();
        }
        return GameLostTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGamePlayTransition()
    {
        if (this.GamePlayTransition == null)
        {
            var transitionBuilder = new TransitionBuilder();
            transitionBuilder.SetExecuteFunc(((s, info) =>
            {
                var information = (IRockPaperScissorGameInformation) info;
                information.PlayerInformation = (GameSymbol) new SymbolInputReader().ReadSymbol(s);
                return information;
            }));
            transitionBuilder.SetMatchFunc(((text, _) => (new SymbolInputReader().ReadSymbol(text)) != null));
            transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetOpponentsTurnState());
            GamePlayTransition = transitionBuilder.GetTransition();
        }
        return GamePlayTransition;
        
    }

    public static RockPaperScissorTransitionFactory GetInstance()
    {
        if (_instance == null) _instance = new RockPaperScissorTransitionFactory();

        return _instance;
    }

    public ITransition<IRockPaperScissorGameInformation> GetQuitTransition()
    {
        if (this.QuitTransition == null)
        {
            var transitionBuilder = new TransitionBuilder();
            transitionBuilder.SetMatchFunc((s, information) => s== "quit");
            transitionBuilder.SetTargetState(_rockPaperScissorStateFactory.GetQuitState());
            QuitTransition = transitionBuilder.GetTransition();
        }
        return QuitTransition;
    }
}