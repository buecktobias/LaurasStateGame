using Application.StateFactory;
using Application.Transitions;

namespace Application;

public class TransitionFactory : ITransitionFactory
{
    private static ITransitionFactory? _instance;
    private IStateFactory _stateFactory;


    private TransitionFactory()
    {
        _stateFactory = StateFactory.StateFactory.GetInstance();
    }

    private ITransition? GameWonTransition { get; set; }
    private ITransition? GameDrawTransition { get; set; }
    private ITransition? GameLostTransition { get; set; }
    private ITransition? GamePlayTransition { get; set; }
    private ITransition? QuitTransition { get; set; }

    public ITransition GetNoMatchTransition()
    {
        return GetQuitTransition();
    }


    public ITransition GetGameWonTransition()
    {
        if (this.GameWonTransition == null)
        {
            Func<string, IGameInformation, bool> matchFunc = (s, gameInformation) =>
            {
                var wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                                   gameInformation.OpponentInformation == "Stein";
                var wonWithStone = gameInformation.PlayerInformation == "Stein" &&
                                   gameInformation.OpponentInformation == "Schere";
                var wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                                      gameInformation.OpponentInformation == "Papier";
                return wonWithPaper || wonWithStone || wonWithScissors;
            };
            this.GameWonTransition = new SimpleTransition(matchFunc, _stateFactory.GetQuitState(), "Yeah Sie haben gewonnen!");
        }
        return GameWonTransition;
    }

    public ITransition GetGameDrawTransition()
    {
        if (this.GameDrawTransition == null)
        {
            Func<string, IGameInformation, bool> matchFunc = (s, information) =>
            {
                return information.OpponentInformation == information.PlayerInformation;
            };
            this.GameDrawTransition = new SimpleTransition(
                matchFunc, _stateFactory.GetGameStartState(),"Unentschieden ! Nächste Runde !");
        }
        return GameDrawTransition;
    }

    public ITransition GetGameLostTransition()
    {
        if (this.GameLostTransition == null)
        {
            Func<string, IGameInformation, bool> matchFunc = (s, gameInformation) =>
            {
                var wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                                   gameInformation.OpponentInformation == "Stein";
                var wonWithStone = gameInformation.PlayerInformation == "Stein" &&
                                   gameInformation.OpponentInformation == "Schere";
                var wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                                      gameInformation.OpponentInformation == "Papier";
                var isDraw = gameInformation.PlayerInformation == gameInformation.OpponentInformation;
                return !wonWithPaper && !wonWithStone && !wonWithScissors &&
                       !isDraw;
            };
            this.GameLostTransition = new SimpleTransition(matchFunc, _stateFactory.GetQuitState(), "Sie haben leider verloren!");
        }
        return GameLostTransition;
    }

    public ITransition GetGamePlayTransition()
    {
        if (this.GamePlayTransition == null)
        {
            this.GamePlayTransition = new SimpleTransition(
                ((s, information) => true),
                _stateFactory.GetOpponentsTurnState(),
                ((s, information) =>
                {
                    information.PlayerInformation = s;
                    return information;
                })
                );
        }
        return GamePlayTransition;
        
    }

    public ITransition GetTransition(string identifier)
    {
        throw new NotImplementedException();
    }

    public static ITransitionFactory GetInstance()
    {
        if (_instance == null) _instance = new TransitionFactory();

        return _instance;
    }

    public ITransition GetQuitTransition()
    {
        if (this.QuitTransition == null)
        {
            QuitTransition = new SimpleTransition(((s, information) => s== "quit" ), _stateFactory.GetQuitState());
        }
        return QuitTransition;
    }
}