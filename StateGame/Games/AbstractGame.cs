using Application.GameInformation;
using Application.States;
using Application.Transitions;

namespace Application.Games;

public abstract class AbstractGame <TGameInformation> where TGameInformation : IGameInformation
{
    private readonly TGameInformation _startGameInformation;
    protected AbstractGame(IState<TGameInformation> startState, TGameInformation startGameInformation)
    {
        CurrentState = startState;
        _startGameInformation = startGameInformation;
    }

    private IState<TGameInformation> CurrentState { get; set; }
    
    public void StartGame()
    {
        GameLoop();
    }

    private void WriteStateIntroOutput()
    {
        Console.WriteLine(CurrentState.GetIntroOutput());

    }

    private TGameInformation ExecuteCurrentState(TGameInformation gameInformation)
    {
        return CurrentState.Execute(gameInformation);
    }

    private string ReadInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    private ITransition<TGameInformation> GetMatchingTransition(string input, TGameInformation gameInformation)
    {
        return CurrentState.GetMatchingTransitionInput(input, gameInformation);
    }

    private void WriteStateOutroOutput()
    {
        Console.WriteLine(CurrentState.GetOutroOutput());
    }

    private void WriteTransitionOutput(ITransition<TGameInformation> transition)
    {
        Console.WriteLine(transition.GetOutput());
    }

    private void GameLoop()
    {
        TGameInformation gameInformation = _startGameInformation;
        while (true)
        {
            WriteStateIntroOutput();
            if (CurrentState.IsEndState()) return;
            gameInformation = ExecuteCurrentState(gameInformation);
            var input = ReadInput();
            var transition = GetMatchingTransition(input, gameInformation);
            gameInformation = transition.Execute(input, gameInformation);
            WriteTransitionOutput(transition);
            WriteStateOutroOutput();
            CurrentState = transition.GetTargetState();
        }
    }
}