using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] AudioClip _buttonSound;

    protected Button _button;
    //private AudioService _audioService;
    protected void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlayButtonSound);
    }
    public void PlayButtonSound()
    {
        //_audioService.PlaySound(_buttonSound);
    }
}
