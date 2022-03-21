using Application.States;
using Application.TransitionFactory;
using Application.Transitions;

namespace Application.StateFactory;

public class RockPaperScissorStateFactory : IRockPaperScissorStateFactory
{
    private static IRockPaperScissorStateFactory? _instance;
    private IState? _gameOpponentTurn;
    private IState? _gameStartState;
    private IState? _quitState;

    private RockPaperScissorStateFactory()
    {
    }

    public IState GetQuitState()
    {
        if (_quitState == null)
        {
            _quitState = new SimpleState("Das Spiel wurde beendet");
            _quitState.CreateTransitions();
        }
        return _quitState;
    }

    public IState GetOpponentsTurnState()
    {
        if (_gameOpponentTurn == null)
        {
            _gameOpponentTurn = new OpponentsTurnState();
            _gameOpponentTurn.CreateTransitions();
        }
        return _gameOpponentTurn;
    }

    public IState GetGameStartState()
    {
        if (_gameStartState == null)
        {
            var introText = "Willkommen bei Schere Stein Papier! \n" +
                            "Gebe entweder Schere, Stein oder Papier ein \n" +
                            "Schere,Stein, Papier!";
            var transitions = new List<ITransition>()
            {
                Application.TransitionFactory.RockPaperScissorTransitionFactory.GetInstance().GetGamePlayTransition()
            };
            _gameStartState = new SimpleState(introText, transitions);
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