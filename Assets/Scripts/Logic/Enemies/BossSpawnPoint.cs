
using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.StaticData;
using Assets.Scripts.Infrastructure.Services.SpawnServiceFolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPoint : MonoBehaviour
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
        for (int i = 0; i < _config.BossCount; i++)
        {
            float rX = Random.Range(-2f, 2f);
            float rZ = Random.Range(-2f, 2f);
            Vector3 pos = new Vector3(transform.position.x + rX, transform.position.y, transform.position.z);
            list.Add(_spawnService.Spawn(_enemy, pos));
        }
        return list;
    }

}