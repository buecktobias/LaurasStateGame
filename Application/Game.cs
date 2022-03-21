using Application.Transitions;

namespace Application;
using Application.StateFactory;
public class Game
{
    public Game()
    {
        CurrentState = StateFactory.RockPaperScissorStateFactory.GetInstance().GetGameStartState();
    }

    private IState CurrentState { get; set; }

    public void StartGame()
    {
        GameLoop();
    }

    private void WriteStateIntroOutput()
    {
        Console.WriteLine(CurrentState.GetIntroOutput());

    }

    private IGameInformation ExecuteCurrentState(IGameInformation gameInformation)
    {
        return CurrentState.Execute(gameInformation);
    }

    private string ReadInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    private ITransition GetMatchingTransition(string input, IGameInformation gameInformation)
    {
        return CurrentState.GetMatchingTransitionInput(input, gameInformation);
    }

    private void WriteStateOutroOutput()
    {
        Console.WriteLine(CurrentState.GetOutroOutput());
    }

    private void WriteTransitionOutput(ITransition transition)
    {
        Console.WriteLine(transition.GetOutput());
    }

    private void GameLoop()
    {
        IGameInformation gameInformation = new GameInformation();
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