namespace Application.GameInformation;

public interface IRockPaperScissorGameInformation : IGameInformation
{
    public string PlayerInformation { get; set; }
    public string OpponentInformation { get; set; }
}