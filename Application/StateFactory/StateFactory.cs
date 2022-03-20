namespace Application;

public class StateFactory : IStateFactory
{
    private static IStateFactory? _instance;

    public static IStateFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new StateFactory();
        }

        return _instance;

    }
    
    private  IState? _startState;
    private  IState? _gameStartState;
    private  IState? _gameOpponentTurn;
    private  IState? _quitState;
    private StateFactory()
    {
    }

    public IState GetQuitState()
    {
        if (_quitState == null)
        {
            _quitState = new QuitState();
        }
        return _quitState;
    }

    public IState GetStartState()
    {
        if (_startState == null)
        {
            _startState = new RockPaperScissorGameStart();
        }
        return this._startState;
    }
    public IState GetOpponentsTurnState()
    {
        if (this._gameOpponentTurn == null)
        {
            this._gameOpponentTurn = new OponentsTurnState();
        }
        return this._gameOpponentTurn;
    }

    public IState GetGameStartState()
    {
        if (this._gameStartState == null)
        {
            this._gameStartState = new RockPaperScissorGameStart();
        }
        return this._gameStartState;
    }

    public IState GetState(string stateIdentifier)
    {
        throw new NotImplementedException();
    }
}