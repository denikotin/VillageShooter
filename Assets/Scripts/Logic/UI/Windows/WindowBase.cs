using UnityEngine;
using UnityEngine.UI;

public abstract class WindowBase : MonoBehaviour
{
    [SerializeField] Button _close;

    protected WindowService _windowService;

    public void Construct(WindowService windowService)
    {
        _windowService = windowService;
        _close.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow() => _windowService.Close(gameObject);
}
