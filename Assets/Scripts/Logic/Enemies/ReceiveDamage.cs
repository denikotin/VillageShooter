using Assets.Scripts.Data.Enums;
using Assets.Scripts.Logic.Enemies.AdventurerFolder;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveDamage : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] Image _healthBar;

    private bool _isHead;
    private bool _isDead;
    private float _hp;

    private void Start()
    {
        _hp = 1f;
    }

    private void Update()
    {
        _healthBar.fillAmount = _hp;
    }

    public void TakeDamage(int value)
    {
        float coeff = _enemyController.GetEnemyType() == EnemyID.Toilet ? 100f : 1000f;
        if (!_isHead)
        {
            if (!_isDead)
            {
                _hp -= value / coeff;
                _enemyController.TakeDamage(value, false);
            }
        }
        else
        {
            if (!_isDead)
            {
                _hp -= value / coeff;
                _enemyController.TakeDamage(value, true);
            }
        }
    }
}
