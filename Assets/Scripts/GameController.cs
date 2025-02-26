using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text enemyCountText;

    [Header("Events")]
    public UnityEvent onAllEnemiesDefeated;
    
    private int _totalEnemies;
    private int _defeatedEnemies;
    private bool _levelCompleted = false;
    
    public static GameController instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        CountEnemiesInScene();
        UpdateEnemyCountUI();
    }
    
    private void CountEnemiesInScene()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        _totalEnemies = enemies.Length;
        _defeatedEnemies = 0;
        
        Debug.Log($"{_totalEnemies} enemies found in the scene.");
        
        foreach (Enemy enemy in enemies)
        {
            ModifyEnemyScript(enemy);
        }
    }
    
    private void ModifyEnemyScript(Enemy enemy)
    {
        if (enemy.GetComponent<EnemyNotifier>() == null)
        {
            enemy.gameObject.AddComponent<EnemyNotifier>();
        }
    }
    
    public void EnemyDefeated()
    {
        _defeatedEnemies++;
        UpdateEnemyCountUI();
        
        Debug.Log($"Enemy defeated, {_totalEnemies - _defeatedEnemies} remaining enemies.");
        
        CheckLevelCompletion();
    }
    
    private void UpdateEnemyCountUI()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = $"{_totalEnemies - _defeatedEnemies} / {_totalEnemies}";
        }
    }
    
    
    private void CheckLevelCompletion()
    {
        if (_defeatedEnemies >= _totalEnemies && !_levelCompleted)
        {
            _levelCompleted = true;
            Debug.Log("All enemies defeated");
            
            if (onAllEnemiesDefeated != null)
            {
                onAllEnemiesDefeated.Invoke();
            }
        }
    }
    
    public void ResetEnemyCount()
    {
        CountEnemiesInScene();
        _levelCompleted = false;
    }
    
    public int GetRemainingEnemies()
    {
        return _totalEnemies - _defeatedEnemies;
    }
}

public class EnemyNotifier : MonoBehaviour
{
    private void OnDestroy()
    {
        if (GameController.instance != null && !gameObject.scene.isLoaded)
            return;
            
        if (GameController.instance != null)
        {
            GameController.instance.EnemyDefeated();
        }
    }
}
