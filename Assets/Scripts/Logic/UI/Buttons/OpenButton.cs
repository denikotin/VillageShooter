using System;
using UnityEngine;

namespace Assets.Scripts.Logic.UI.Buttons
{
    public class OpenButton: ButtonBase
    {
        [SerializeField] GameObject _window;

        private WindowService _windowService;

        public void Construct(WindowService windowService) => _windowService = windowService;

        private new void Awake()
        {
            base.Awake();
            _button.onClick.AddListener(Open);
        }

        private void Open() => _windowService.Open(_window);
    }
}
