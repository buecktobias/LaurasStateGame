namespace Application.States;

public class QuitState : AbstractState
{

    public override string GetIntroOutput()
    {
        return "Das Spiel wurde beendet";
    }
    

    public override bool IsEndState()
    {
        return true;
    }
}