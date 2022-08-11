using Godot;

public class IdleState : State
{
    private readonly Player _player;
    public static readonly string StateName = "idle";

    public IdleState(Player player)
    {
        _player = player;
    }

    public string GetStateName()
    {
        return StateName;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public string PhysicsProcess(float delta)
    {
        _player.Velocity.y += _player.Properties.FallGravity * delta;
        _player.Velocity = _player.MoveAndSlideWithSnap(_player.Velocity, _player.SnapTo, Vector3.Up, true);
        return _player.IsOnFloor() ? StateName : FallState.StateName;
    }

    public string ProcessInput(InputEvent @event)
    {
        var isMoving = Input.IsActionJustPressed("move_left") || Input.IsActionJustPressed("move_right")
                                                              || Input.IsActionJustPressed("move_up")
                                                              || Input.IsActionJustPressed("move_down");
        if (_player.IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            return JumpState.StateName;
        }

        if (isMoving)
        {
            return WalkState.StateName;
        }

        return StateName;
    }
}