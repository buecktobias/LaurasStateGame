namespace Application;

public interface ITransition
{
    public bool Matches(string input, IGameInformation gameInformation);
    public IGameInformation Execute(string input, IGameInformation gameInformation);
    public IState GetTargetState();
    public string GetOutput();
}