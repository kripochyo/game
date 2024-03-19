using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemySpawner : MonoBehaviour
{
    public EnemyIo EnemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;

    public int EnemiesMaxCount = 5;
    public float delay = 5;

    private List<Transform> _SpawnerPoints;
    private List<EnemyIo> _Enemies;

    private float _TimeLastSpawned;

    private void Start()
    {
        _SpawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _Enemies = new List<EnemyIo>();
    }

    private void Update()
    {
        for (var i = 0; i < _Enemies.Count; i++)
        {
            if (_Enemies[i].IsAlive()) continue;
            _Enemies.RemoveAt(i);
            i--;
        }

        if (_Enemies.Count >= EnemiesMaxCount) return;
        if (Time.time - _TimeLastSpawned < delay) return;
     
        CreateEnemy();
    }
         
    private void CreateEnemy()
    {
        var enemy = Instantiate(EnemyPrefab);
        enemy.transform.position = _SpawnerPoints[Random.Range(0, _SpawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _Enemies.Add(enemy);
        _TimeLastSpawned = Time.time;
    }
}