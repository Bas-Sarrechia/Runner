using System;
using Godot;

public class JumpState : State
{
    private readonly Player _player;
    public static readonly string StateName = "jump";
    private readonly Moveable _moveable = new Moveable();

    public JumpState(Player player)
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
        _player.Velocity.y = _player.Properties.JumpVelocity;
        _player.SnapTo = Vector3.Zero;
        _player.Velocity = _player.MoveAndSlideWithSnap(_player.Velocity, _player.SnapTo, Vector3.Up, true);
    }

    public string PhysicsProcess(float delta)
    {
        _player.Velocity.y += _player.Properties.JumpGravity * delta;
        _moveable.Move(_player);
        if (_player.Velocity.y < 0)
        {
            return FallState.StateName;
        }

        return StateName;
    }
}