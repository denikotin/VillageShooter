using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.UI.LoadingScreenFolder
{
    public class LoadingScreen:MonoBehaviour
    {
        [SerializeField] GameObject _screen;

        public CanvasGroup Curtain;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Show()
        {
            _screen.SetActive(true);  
        }

        public void Hide()
        {
            StartCoroutine(HideRoutine());  
        }

        public IEnumerator HideRoutine()
        {

            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.1f;
                yield return new WaitForSeconds(0.01f);
            }

            _screen.SetActive(false);
            Curtain.alpha = 1;

        }
    }
}
