using Application.States;
using Application.Transitions;

namespace Application.StateFactory;

public class StateFactory : IStateFactory
{
    private static IStateFactory? _instance;
    private ITransitionFactory _transitionFactory;
    private IState? _gameOpponentTurn;
    private IState? _gameStartState;
    private IState? _quitState;

    private StateFactory()
    {
        // _transitionFactory = TransitionFactory.GetInstance();
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
                TransitionFactory.GetInstance().GetGamePlayTransition()
            };
            _gameStartState = new SimpleState(introText, transitions);
            _gameStartState.CreateTransitions();
        }
        return _gameStartState;
    }
    

    public static IStateFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new StateFactory();
            
        }

        return _instance;
    }
}