using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;
    [SerializeField] string _tr;

    private void Start()
    {
        Text text = GetComponent<Text>();

        switch (Yandex.instance.Language)
        {
            case "ru":
                text.text = _ru;
                break;
            case "en":
                text.text = _en;
                break;
            case "tr":
                text.text = _tr;
                break;
        }
    }
}
