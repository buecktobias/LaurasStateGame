using Application.GameInformation;
using Application.States;
using Application.Transitions;

namespace Application.Games;

public abstract class AbstractGame<TGameInformation> where TGameInformation : IGameInformation
{
    private TGameInformation _currentGameInformation;
    private ITransition<TGameInformation>? _currentTransition;

    protected AbstractGame(IState<TGameInformation> startState, TGameInformation startGameInformation)
    {
        CurrentState = startState;
        _currentGameInformation = startGameInformation;
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

    private void ExecuteCurrentState()
    {
        _currentGameInformation = CurrentState.Execute(_currentGameInformation);
        var input = GetUserInputIfNeeded();
        _currentTransition = GetMatchingTransition(input);
        _currentGameInformation = _currentTransition.Execute(input, _currentGameInformation);
        WriteTransitionOutput(_currentTransition);
    }

    private string GetUserInputIfNeeded()
    {
        if (CurrentState.NeedsUserInput()) return Console.ReadLine() ?? string.Empty;

        return string.Empty;
    }

    private ITransition<TGameInformation> GetMatchingTransition(string input)
    {
        return CurrentState.GetMatchingTransitionInput(input, (TGameInformation) _currentGameInformation.GetCopy());
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
        while (true)
        {
            WriteStateIntroOutput();
            if (CurrentState.IsEndState()) return;
            ExecuteCurrentState();
            WriteStateOutroOutput();
            CurrentState = _currentTransition!.GetTargetState();
        }
    }
}