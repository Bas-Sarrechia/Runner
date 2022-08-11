using Godot;

public class Main : Node
{
#pragma warning disable 649
	// We assign this in the editor, so we don't need the warning about not being assigned.
	[Export] public PackedScene MobScene;
#pragma warning restore 649
	public override void _Ready()
	{
		GD.Randomize();
	}

	private void onMobTimerTimeout()
	{
		Vector3 playerPosition = GetNode<Player>("Player").Transform.origin;
	}
}
