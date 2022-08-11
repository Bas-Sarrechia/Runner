using Godot;

public class PlayerProperties
{
    private static PlayerProperties _instance;

    [Export] public float JumpTimeToPeak = 0.4f;
    [Export] public float JumpPeak = 2.5f;
    [Export] public float JumpTimeToDescent = 0.3f;

    [Export] public float Speed = 7;
    
    [Export] public int DashSpeed = 14;

    public float JumpVelocity { get; private set; }
    public float JumpGravity { get; private set; }
    public float FallGravity { get; private set; }

    private PlayerProperties()
    {
        Init();
    }

    public  static PlayerProperties Instance()
    {
        return _instance ?? (_instance = new PlayerProperties());
    }

    private void Init()
    {
        JumpVelocity = (2.0f * JumpPeak) / JumpTimeToPeak;
        JumpGravity = (-2.0f * JumpPeak) / (JumpTimeToPeak * JumpTimeToPeak);
        FallGravity = (-2.0f * JumpPeak) / (JumpTimeToDescent * JumpTimeToDescent);
    }
}