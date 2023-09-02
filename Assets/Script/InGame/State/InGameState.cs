
public class InGameState 
{
    protected InGameStateMachine stateMachine;

    public InGameState(InGameStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
