
public class CloseButton : ButtonBase
{
    private new void Awake()
    {
        base.Awake();
        _button.onClick.AddListener(Yandex.instance.ShowAdv);
    }
}
