using Godot;

public class Player : KinematicBody
{
	[Signal]
	public delegate void StateTransitioned();

	private readonly StateManager _stateManager;

	public PlayerProperties Properties { get; } = PlayerProperties.Instance();

	public Vector3 Velocity = Vector3.Zero;
	public Vector3 SnapTo { get; set; } = Vector3.Down;
	public SpringArm Camera { get; private set; }
	private Spatial _playerModel;

	public Player()
	{
		var idleState = new IdleState(this);
		_stateManager = StateManager.StateManagerBuilder.Instance()
			.SetDefaultState(idleState)
			.AddState(new WalkState(this))
			.AddState(new RunState(this))
			.AddState(new JumpState(this))
			.AddState(new FallState(this))
			.Build();
	}

	public override void _Ready()
	{
		Camera = GetNode<SpringArm>("PlayerCameraSpringArm");
		_playerModel = GetNode<Spatial>("PlayerModel");
	}

	public override void _Process(float delta)
	{
		var translate = Translation;
		translate.y += 2;
		Camera.Translation = translate;
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		_stateManager.Input(@event);
	}

	public override void _Input(InputEvent @event)
	{
		_stateManager.Input(@event);
	}

	public override void _PhysicsProcess(float delta)
	{
		_stateManager.PhysicsProcess(delta);
		HandlePlayerRotation();
	}
	private void HandlePlayerRotation()
	{
		if (Velocity.Length() > 2)
		{
			var lookDirection = new Vector2(Velocity.z, Velocity.x);
			var playerRotation = _playerModel.Rotation;
			playerRotation.y = lookDirection.Angle();
			_playerModel.Rotation = playerRotation;
		}
	}
}
