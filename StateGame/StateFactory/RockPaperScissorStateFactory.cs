using Application.GameInformation;
using Application.States;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.StateFactory;

public class RockPaperScissorStateFactory : IRockPaperScissorStateFactory
{
    private static IRockPaperScissorStateFactory? _instance;
    private IState<IRockPaperScissorGameInformation>? _gameOpponentTurn;
    private IState<IRockPaperScissorGameInformation>? _gameStartState;
    private IState<IRockPaperScissorGameInformation>? _quitState;

    private RockPaperScissorStateFactory()
    {
    }

    public IState<IRockPaperScissorGameInformation> GetQuitState()
    {
        if (_quitState == null)
        {
            _quitState = new SimpleRockPaperScissorState("Das Spiel wurde beendet");
            _quitState.CreateTransitions();
        }
        return _quitState;
    }

    public IState<IRockPaperScissorGameInformation> GetOpponentsTurnState()
    {
        if (_gameOpponentTurn == null)
        {
            _gameOpponentTurn = new OpponentsTurnState();
            _gameOpponentTurn.CreateTransitions();
        }
        return _gameOpponentTurn;
    }

    public IState<IRockPaperScissorGameInformation> GetGameStartState()
    {
        if (_gameStartState == null)
        {
            var introText = "Willkommen bei Schere Stein Papier! \n" +
                            "Gebe entweder Schere, Stein oder Papier ein \n" +
                            "Schere,Stein, Papier!";
            var transitions = new List<ITransition<IRockPaperScissorGameInformation>>()
            {
                RockPaperScissorTransitionFactory.GetInstance().GetGamePlayTransition()
            };
            _gameStartState = new SimpleRockPaperScissorState(introText, transitions);
            _gameStartState.CreateTransitions();
        }
        return _gameStartState;
    }
    

    public static IRockPaperScissorStateFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new RockPaperScissorStateFactory();
            
        }

        return _instance;
    }
}