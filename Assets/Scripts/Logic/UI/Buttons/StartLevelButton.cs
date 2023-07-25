using Assets.Scripts.Infrastructure.Services.LevelServiceFolder;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : ButtonBase
{
    [SerializeField] int _levelNumber;
    [SerializeField] Sprite _closedIcon;
    [SerializeField] Sprite _openedIcon;
    [SerializeField] Sprite _completedIcon;

    private Image _icon;
    private LevelService _levelService;

    private new void Awake()
    {
        base.Awake();
        _button.onClick.AddListener(StartLevel);
        _icon = GetComponent<Image>();
    }

    public void Construct(LevelService levelService)
    {
        _levelService = levelService;
    }

    public void Initialize()
    {
        CheckLevelOpen();
        CheckLevelCompleted();
    }

    private void StartLevel() => _levelService.StartLevel(_levelNumber);

    private void CheckLevelOpen()
    {
        if (_levelService.IsLevelOpen(_levelNumber))
        {
            _icon.sprite = _openedIcon;
            _button.enabled = true;
        }
        else
        {
            _icon.sprite = _closedIcon;
            _button.enabled = false;
        }
        
    }

    private void CheckLevelCompleted()
    {
        if(_levelService.IsLevelCompleted(_levelNumber))
        {
            _icon.sprite = _completedIcon;
        }
    }
}
