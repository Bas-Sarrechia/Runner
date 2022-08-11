using Godot;

public class FallState : State
{
    private readonly Player _player;
    public static readonly string StateName = "fall";
    private readonly Moveable _moveable = new Moveable();
    public FallState(Player player)
    {
        _player = player;
    }

    public string ProcessInput(InputEvent @event)
    {
        return StateName;
    }

    public string GetStateName()
    {
        return StateName;
    }

    public void Exit()
    {
    }

    public void Enter()
    {
    }

    public string PhysicsProcess(float delta)
    {
        _player.Velocity.y += _player.Properties.FallGravity * delta;
        _moveable.Move(_player);
        if (_player.IsOnFloor())
        {
            return IdleState.StateName;
        }
        return StateName;
    }
}