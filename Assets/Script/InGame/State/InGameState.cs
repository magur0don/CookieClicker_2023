
public class InGameState 
{
    protected InGameStateMachine stateMachine;

    protected CookieClickerPresenter cookieClickerPresenter;

    public InGameState(InGameStateMachine stateMachine, CookieClickerPresenter cookieClickerPresenter)
    {
        this.stateMachine = stateMachine;
        this.cookieClickerPresenter = cookieClickerPresenter;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
