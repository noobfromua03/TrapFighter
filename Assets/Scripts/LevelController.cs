using FVN.Helpers;
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
    [SerializeField] private float spawnDelay;
    [SerializeField] private float waves;
    [SerializeField] private GameObject exit;

    public int NotesAmount;

    private List<Enemy> enemies = new List<Enemy>();

    private int diedEnemies = 0;

    public Action OnFinish;

    private bool spawning = false;

    public void Initialize(List<Note> notes)
    {
        StartCoroutine(SpawnAsync(notes));
    }

    private IEnumerator SpawnAsync(List<Note> notes)
    {
        spawning = true;
        notes.Shuffle();
        var notesToSpawn = new List<Note>(notes).GetRange(0, NotesAmount);
        int noteIndex = 0;
        for (int i = 0; i < waves; i++)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                yield return new WaitForSeconds(spawnDelay);

                var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemy.ChangeSpeed(enemySpeed);
                enemy.ChangeHP(enemyHP);
                enemy.OnDie += OnDieEnemy;

                if (UnityEngine.Random.Range(0f, 1f) > 0.75f)
                {
                    if (noteIndex < notesToSpawn.Count)
                    {
                        enemy.AddNote(notesToSpawn[noteIndex]);
                        notes.Remove(notesToSpawn[noteIndex]);
                        noteIndex++;
                    }
                }

                enemies.Add(enemy);
            }
        }
        spawning = false;
    }

    private void OnDieEnemy()
    {
        diedEnemies += 1;

        if (diedEnemies >= enemies.Count && spawning == false)
            exit.SetActive(true);
    }

    public void Finish()
    {
        OnFinish?.Invoke();
    }
}
