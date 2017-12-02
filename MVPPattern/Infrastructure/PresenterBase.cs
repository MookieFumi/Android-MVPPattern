using MVPPattern.Features.Todos;

namespace MVPPattern.Infrastructure
{
    public abstract class PresenterBase
    {
        abstract public void SaveState(StateManager stateManager);
        abstract public void RestoreState(StateManager stateManager);
    }
}
