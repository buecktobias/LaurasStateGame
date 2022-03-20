namespace Application;

public class Game
{
    private IState CurrentState { get; set; }

    public Game()
    {
        CurrentState = new StateFactory().GetStartState();
    }

    public void StartGame()
    {
        this.GameLoop();
    }

    private void GameLoop()
    {
        while (true)
        {
            Console.WriteLine(CurrentState.GetIntroOutput());
            if (CurrentState.IsEndState())
            {
                return;
            }
            var input = Console.ReadLine() ?? string.Empty;
            var transition = CurrentState.GetMatchingTransitionInput(input);
            Console.WriteLine(CurrentState.GetOutroOutput());
            CurrentState = transition.GetTargetState();
        }
    }
}