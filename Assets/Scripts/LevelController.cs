using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float enemyHP;
    [SerializeField] private float enemySpeed;

    private List<Enemy> enemies = new List<Enemy>();

    private int diedEnemies = 0;

    private void Start()
    {
        StartCoroutine(SpawnAsync());
    }

    private IEnumerator SpawnAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.ChangeSpeed(enemySpeed);
                enemy.ChangeHP(enemyHP);
                enemy.OnDie += OnDieEnemy;
                enemies.Add(enemy);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }

    private void OnDieEnemy()
    {
        diedEnemies += 1;

        if (diedEnemies >= enemies.Count)
            Debug.Log("All enemies died!");
    }
}
