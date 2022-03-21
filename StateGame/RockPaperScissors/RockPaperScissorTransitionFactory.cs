using Application.GameInformation;
using Application.StateFactory;
using Application.Transitions;

namespace Application.TransitionFactory;

public class RockPaperScissorTransitionFactory : IRockPaperScissorTransitionFactory
{
    private static RockPaperScissorTransitionFactory? _instance;
    private IRockPaperScissorStateFactory _rockPaperScissorStateFactory;


    private RockPaperScissorTransitionFactory()
    {
        _rockPaperScissorStateFactory = StateFactory.RockPaperScissorStateFactory.GetInstance();
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
            Func<string, IRockPaperScissorGameInformation, bool> matchFunc = (s, gameInformation) =>
            {
                var wonWithPaper = gameInformation.PlayerInformation == "Papier" &&
                                   gameInformation.OpponentInformation == "Stein";
                var wonWithStone = gameInformation.PlayerInformation == "Stein" &&
                                   gameInformation.OpponentInformation == "Schere";
                var wonWithScissors = gameInformation.PlayerInformation == "Schere" &&
                                      gameInformation.OpponentInformation == "Papier";
                return wonWithPaper || wonWithStone || wonWithScissors;
            };
            this.GameWonTransition = new SimpleRockPaperScissorTransition(matchFunc, _rockPaperScissorStateFactory.GetQuitState(), "Yeah Sie haben gewonnen!");
        }
        return GameWonTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGameDrawTransition()
    {
        if (this.GameDrawTransition == null)
        {
            Func<string, IRockPaperScissorGameInformation, bool> matchFunc = (s, information) =>
            {
                return information.OpponentInformation == information.PlayerInformation;
            };
            this.GameDrawTransition = new SimpleRockPaperScissorTransition(
                matchFunc, _rockPaperScissorStateFactory.GetGameStartState(),"Unentschieden ! Nächste Runde !");
        }
        return GameDrawTransition;
    }
    

    public ITransition<IRockPaperScissorGameInformation> GetGameLostTransition()
    {
        if (this.GameLostTransition == null)
        {
            Func<string, IRockPaperScissorGameInformation, bool> matchFunc = (s, gameInformation) =>
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
            this.GameLostTransition = new SimpleRockPaperScissorTransition(matchFunc, _rockPaperScissorStateFactory.GetQuitState(), "Sie haben leider verloren!");
        }
        return GameLostTransition;
    }

    public ITransition<IRockPaperScissorGameInformation> GetGamePlayTransition()
    {
        if (this.GamePlayTransition == null)
        {
            this.GamePlayTransition = new SimpleRockPaperScissorTransition(
                ((s, information) => true),
                _rockPaperScissorStateFactory.GetOpponentsTurnState(),
                ((s, information) =>
                {
                    information.PlayerInformation = s;
                    return information;
                })
                );
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
            QuitTransition = new SimpleRockPaperScissorTransition(((s, information) => s== "quit" ), _rockPaperScissorStateFactory.GetQuitState());
        }
        return QuitTransition;
    }
}