namespace Application;

public class TransitionFactory : ITransitionFactory
{
    private static ITransitionFactory? _instance;
    public static ITransitionFactory GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TransitionFactory();
        }

        return _instance;

    }

    public ITransition GameWonTransition { get; set; }
    public ITransition GameDrawTransition { get; set; }
    public ITransition GameLostTransition   { get; set; }
    public ITransition GamePlayTranition   { get; set; }
    public ITransition QuitTransition   { get; set; }

    
    private TransitionFactory()
    {
        GameWonTransition = new GameWonTransition();
        GameDrawTransition = new GameDrawTransition();
        GameLostTransition = new GameLostTransition();
        GamePlayTranition = new RockPaperScissorGamePlayTransition();
        QuitTransition = new QuitTransition();
    }

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

    public ITransition GetQuitTransition()
    {
        return QuitTransition;
    }
    public ITransition GetTransition(string identifier)
    {
        throw new NotImplementedException();
    }
}