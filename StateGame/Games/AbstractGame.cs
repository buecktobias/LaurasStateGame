using Application.GameInformation;
using Application.States;
using Application.Transitions;

namespace Application.Games;

public abstract class AbstractGame<TGameInformation> where TGameInformation : IGameInformation
{
    private TGameInformation CurrentGameInformation;

    protected AbstractGame(IState<TGameInformation> startState, TGameInformation startGameInformation)
    {
        CurrentState = startState;
        CurrentGameInformation = startGameInformation;
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
        
        CurrentGameInformation = CurrentState.Execute(CurrentGameInformation);
    }

    private string GetUserInputIfNeeded()
    {
        if (CurrentState.NeedsUserInput())
        {
            return Console.ReadLine() ?? string.Empty;
        }

        return string.Empty;
    }

    private ITransition<TGameInformation> GetMatchingTransition(string input)
    {
        return CurrentState.GetMatchingTransitionInput(input, (TGameInformation)CurrentGameInformation.GetCopy());
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
            var input = GetUserInputIfNeeded();
            var transition = GetMatchingTransition(input);
            CurrentGameInformation = transition.Execute(input, CurrentGameInformation);
            WriteTransitionOutput(transition);
            WriteStateOutroOutput();
            CurrentState = transition.GetTargetState();
        }
    }
}