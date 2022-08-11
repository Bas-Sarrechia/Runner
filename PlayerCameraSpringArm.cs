using Godot;

public class PlayerCameraSpringArm : SpringArm
{
	[Export] public float MouseSensitivity = 0.5f;

	public override void _Ready()
	{
		SetAsToplevel(true); 
		Input.SetMouseMode(Input.MouseMode.Captured);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseMotion motion)
		{
			float xRotation = RotationDegrees.x;
			xRotation -= motion.Relative.y * MouseSensitivity;
			xRotation = Mathf.Clamp(xRotation, -90f, 30f);
			
			float yRotation = RotationDegrees.y;
			yRotation -= motion.Relative.x * MouseSensitivity;
			yRotation = Mathf.Wrap(yRotation, 0f, 360f);

			RotationDegrees = new Vector3(xRotation, yRotation, RotationDegrees.z);
		}	
	}
}
