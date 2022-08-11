using Godot;

public class Moveable
{
    public void Move(Player player)
    {
        var direction = Vector3.Zero;
        direction.x = Input.GetActionRawStrength("move_right") - Input.GetActionRawStrength("move_left");
        direction.z = Input.GetActionRawStrength("move_down") - Input.GetActionRawStrength("move_up");
        direction = direction.Rotated(Vector3.Up, player.Camera.Rotation.y).Normalized();
        player.Velocity.x = direction.x * player.Properties.Speed;
        player.Velocity.z = direction.z * player.Properties.Speed;
        player.Velocity = player.MoveAndSlideWithSnap(player.Velocity, player.SnapTo, Vector3.Up, true);
    }
}