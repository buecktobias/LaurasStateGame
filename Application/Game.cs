namespace Application;

public class Game
{
    private IState CurrentState { get; set; }

    public Game()
    {
        CurrentState = StateFactory.GetInstance().GetGameStartState();
    }

    public void StartGame()
    {
        this.GameLoop();
    }

    private void GameLoop()
    {
        IGameInformation gameInformation = new GameInformation();
        while (true)
        {
            Console.WriteLine(CurrentState.GetIntroOutput());
            gameInformation = CurrentState.Execute(gameInformation);
            if (CurrentState.IsEndState())
            {
                return;
            }
            var input = Console.ReadLine() ?? string.Empty;
            var transition = CurrentState.GetMatchingTransitionInput(input, gameInformation);
            gameInformation = transition.Execute(input, gameInformation);
            Console.WriteLine(transition.GetOutput());
            Console.WriteLine(CurrentState.GetOutroOutput());
            CurrentState = transition.GetTargetState();
        }
    }
}