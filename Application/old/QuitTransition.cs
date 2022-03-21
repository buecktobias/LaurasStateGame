using Application.Transitions;

namespace Application.old;

public class QuitTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return input == "quit";
    }

    public override IState GetTargetState()
    {
        return RockPaperScissorStateFactory.GetQuitState();
    }

    public override string GetOutput()
    {
        return "Quit";
    }
}