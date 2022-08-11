using Godot;

public class RunState: State
{
    private readonly Player _player;
    public static readonly string StateName = "run";
    public RunState(Player player)
    {
        _player = player;
    }

    public string ProcessInput(InputEvent @event)
    {
        throw new System.NotImplementedException();
    }
    

    public string GetStateName()
    {
        return "run";
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public string PhysicsProcess(float delta)
    {
        throw new System.NotImplementedException();
    }
}