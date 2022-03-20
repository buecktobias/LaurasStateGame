namespace Application;

public class GameInformation : IGameInformation
{
    public GameInformation()
    {
    }

    public string PlayerInformation { get; set; } = "";
    public string OpponentInformation { get; set; } = "";
}