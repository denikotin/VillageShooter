using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.StaticData;
using Assets.Scripts.Infrastructure.Services.SpawnServiceFolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] EnemyID _enemy;
    private SpawnService _spawnService;
    private LevelStaticData _config;

    public void Construct(SpawnService spawnService, LevelStaticData config)
    {
        _spawnService = spawnService;
        _config = config;
    }

    public List<GameObject> SpawnEnemies()
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < _config.EnemiesCount; i++)
        {
            float rX = Random.Range(-15f, 15f);
            float rZ = Random.Range(-5f, 5f);
            Vector3 pos = new Vector3(transform.position.x + rX, transform.position.y, transform.position.z);
            list.Add(_spawnService.Spawn(_enemy, pos));
        }
        return list;
    }

}

