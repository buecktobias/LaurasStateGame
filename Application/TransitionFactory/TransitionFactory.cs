using Application.StateFactory;
using Application.Transitions;

namespace Application;

public class TransitionFactory : ITransitionFactory
{
    private static ITransitionFactory? _instance;
    private IStateFactory _stateFactory;


    private TransitionFactory()
    {
        _stateFactory = StateFactory.StateFactory.GetInstance();
        GameWonTransition = new GameWonTransition();
        GameDrawTransition = new GameDrawTransition();
        GameLostTransition = new GameLostTransition();
        GamePlayTranition = new RockPaperScissorGamePlayTransition();
    }

    private ITransition? GameWonTransition { get; set; }
    private ITransition? GameDrawTransition { get; set; }
    private ITransition? GameLostTransition { get; set; }
    private ITransition? GamePlayTranition { get; set; }
    private ITransition? QuitTransition { get; set; }

    public ITransition GetNoMatchTransition()
    {
        if (this.QuitTransition == null)
        {
            QuitTransition = new SimpleTransition(((s, information) => s== "quit" ), _stateFactory.GetQuitState());
        }
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