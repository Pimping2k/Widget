using MyPackage.Runtime.ServiceLocator_Core;

namespace Services
{
    public interface IInputService : IService
    {
        InputSystem_Actions.PlayerActions Player { get; }
        InputSystem_Actions.UIActions UI { get; }
        InputSystem_Actions InputActions { get; }
    }
}