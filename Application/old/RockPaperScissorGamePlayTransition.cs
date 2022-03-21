﻿namespace Application.Transitions;

public class RockPaperScissorGamePlayTransition : AbstractTransition
{
    public override bool Matches(string input, IGameInformation gameInformation)
    {
        return true;
    }


    public override IGameInformation Execute(string input, IGameInformation gameInformation)
    {
        gameInformation.PlayerInformation = input;
        return gameInformation;
    }

    public override IState GetTargetState()
    {
        return RockPaperScissorStateFactory.GetOpponentsTurnState();
    }
}