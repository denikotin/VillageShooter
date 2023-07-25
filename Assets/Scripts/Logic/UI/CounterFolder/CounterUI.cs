using Assets.Scripts.Logic.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Logic.UI.CounterFolder
{
    public class CounterUI:MonoBehaviour
    {
        [SerializeField] Text _text;
        private EnemyCounter _enemyCounter;

        public void Construct(EnemyCounter enemyCounter)
        {
            _enemyCounter = enemyCounter;
            _enemyCounter.OnEnemyDieEvent += UpdateText;
            UpdateText(_enemyCounter.GetStartEnemyCount());
        }


        private void UpdateText(int value)
        {
            _text.text = $"{value} / {_enemyCounter.GetStartEnemyCount()}";
        }
    }
}
