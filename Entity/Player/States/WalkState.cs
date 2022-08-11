using Godot;

public class WalkState : State
{
    private readonly Player _player;
    public static readonly string StateName = "walk";
    private readonly Moveable _moveable = new Moveable();
    public WalkState(Player player)
    {
        _player = player;
    }

    public string ProcessInput(InputEvent @event)
    {
        if (_player.IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            return JumpState.StateName;
        }

        return StateName;
    }

    public string PhysicsProcess(float delta)
    {
        if (!_player.IsOnFloor())
        {
            return FallState.StateName;
        }

        _player.Velocity.y += _player.Properties.FallGravity * delta;
        _moveable.Move(_player);
        
        if(_player.Velocity.x == 0 && _player.Velocity.y == 0)
        {
            return IdleState.StateName;
        }
        
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
}