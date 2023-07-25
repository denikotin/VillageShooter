using UnityEngine;
using UnityEngine.UI;

public class AnotherGame : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _gameID;

    void Start()
    {
        _button.onClick.AddListener(OpenDeveloperSite);
    }

    private void OpenDeveloperSite()
    {
        Application.OpenURL($"https://yandex.{Yandex.instance.Domain}/games/app/{_gameID}?lang={Yandex.instance.Language}");
    }
}
