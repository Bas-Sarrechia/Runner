public interface StateManagerBuilderStateModifier
{
    StateManagerBuilderStateModifier AddState(State state);
    StateManager Build();
}