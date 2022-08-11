using Godot;

public interface State
{
    string ProcessInput(InputEvent @event);
    string GetStateName();

    void Exit();
    void Enter();
    string PhysicsProcess(float delta);
}