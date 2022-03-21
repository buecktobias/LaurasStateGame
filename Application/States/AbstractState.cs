﻿using Application.TransitionFactory;
using Application.Transitions;

namespace Application.States;

public abstract class AbstractState : IState
{
    protected readonly RockPaperScissorTransitionFactory RockPaperScissorTransitionFactory;

    protected AbstractState()
    {
        RockPaperScissorTransitionFactory = Application.TransitionFactory.RockPaperScissorTransitionFactory.GetInstance();
        Transitions = new List<ITransition>();
    }


    protected IList<ITransition> Transitions { get; }

    public virtual string GetIntroOutput()
    {
        return "";
    }

    public ITransition GetMatchingTransitionInput(string input, IGameInformation gameInformation)
    {
        var transitionOrNull = GetMatchedTransitions(input, gameInformation);
        return transitionOrNull ?? RockPaperScissorTransitionFactory.GetNoMatchTransition();
    }

    public virtual string GetOutroOutput()
    {
        return "";
    }

    public virtual bool IsEndState()
    {
        return false;
    }

    public virtual IGameInformation Execute(IGameInformation gameInformation)
    {
        return gameInformation;
    }

    public virtual void CreateTransitions()
    {
    }
    private ITransition? GetMatchedTransitions(string input, IGameInformation gameInformation)
    {
        return Transitions.FirstOrDefault(transition => transition.Matches(input, gameInformation));
    }


}