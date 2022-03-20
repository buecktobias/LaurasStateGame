namespace Application;

public interface ITransitionFactory
{
    ITransition GetTransition(string identifier);
    ITransition GetNoMatchTransition();
    ITransition GetGameWonTransition();
    ITransition GetGameDrawTransition();
    ITransition GetGameLostTransition();
    ITransition GetGamePlayTransition();

}