using Application.Transitions;

namespace Application;

public class TransitionFactory : ITransitionFactory
{
    private static ITransitionFactory? _instance;


    private TransitionFactory()
    {
        GameWonTransition = new GameWonTransition();
        GameDrawTransition = new GameDrawTransition();
        GameLostTransition = new GameLostTransition();
        GamePlayTranition = new RockPaperScissorGamePlayTransition();
        QuitTransition = new QuitTransition();
    }

    private ITransition GameWonTransition { get; set; }
    private ITransition GameDrawTransition { get; set; }
    private ITransition GameLostTransition { get; set; }
    private ITransition GamePlayTranition { get; set; }
    private ITransition QuitTransition { get; set; }

    public ITransition GetNoMatchTransition()
    {
        return GetQuitTransition();
    }


    public ITransition GetGameWonTransition()
    {
        return GameWonTransition;
    }

    public ITransition GetGameDrawTransition()
    {
        return GameDrawTransition;
    }

    public ITransition GetGameLostTransition()
    {
        return GameLostTransition;
    }

    public ITransition GetGamePlayTransition()
    {
        return GamePlayTranition;
    }

    public ITransition GetTransition(string identifier)
    {
        throw new NotImplementedException();
    }

    public static ITransitionFactory GetInstance()
    {
        if (_instance == null) _instance = new TransitionFactory();

        return _instance;
    }

    public ITransition GetQuitTransition()
    {
        return QuitTransition;
    }
}