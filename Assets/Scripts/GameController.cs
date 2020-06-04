using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;
    [SerializeField] float waveCount;

    public Image healthBar;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy() 
    {
        if (waveCount > 0)
        {
            GameObject enemyObj = Instantiate(enemy, spawnPos.position, enemy.transform.rotation);
            Enemy _enemy = enemyObj.GetComponent<Enemy>();
            _enemy.healthBar = healthBar;
            _enemy.healthBar.fillAmount = _enemy._baseEnemy.GetHealth(0)/100;
            waveCount -= 1;
        }
    }

}
