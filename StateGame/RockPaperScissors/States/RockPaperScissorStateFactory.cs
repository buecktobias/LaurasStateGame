using Application.GameInformation;
using Application.RockPaperScissors.States;
using Application.StateFactory;
using Application.States;
using Application.Transitions;

namespace Application.RockPaperScissors;

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
            var stateBuilder = new SimpleRockPaperScissorBuilder();
            stateBuilder.SetIntroOutput("Das Spiel wurde beendet");
            stateBuilder.SetAsEndState();
            _quitState = stateBuilder.GetState();
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
            var transitions = new List<ITransition<IRockPaperScissorGameInformation>>
            {
                RockPaperScissorTransitionFactory.GetInstance().GetGamePlayTransition(),
                RockPaperScissorTransitionFactory.GetInstance().GetWrongInputTransition()
            };
            var startStateBuilder = new SimpleRockPaperScissorBuilder();
            startStateBuilder.SetIntroOutput(introText);
            startStateBuilder.SetTransitions(transitions);
            _gameStartState = startStateBuilder.GetState();
            _gameStartState.CreateTransitions();
        }

        return _gameStartState;
    }


    public static IRockPaperScissorStateFactory GetInstance()
    {
        if (_instance == null) _instance = new RockPaperScissorStateFactory();

        return _instance;
    }
}