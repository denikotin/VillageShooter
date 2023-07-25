
using UnityEngine;

namespace Assets.Scripts.Logic.UI.Buttons
{
    public class ContinueGameButton:ButtonBase
    {
        private HUDController _hudController;

        private new void Awake()
        {
            base.Awake();
            _button.onClick.AddListener(ContinueGame);
        }

        public void Construct(HUDController hudController) => _hudController = hudController;
        private void ContinueGame() => _hudController.ContinueGame();
    }
}
