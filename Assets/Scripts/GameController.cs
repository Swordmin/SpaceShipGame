using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;
    [SerializeField] float waveCount;


    public void SpawnEnemy() 
    {
        if (waveCount > 0)
        {
            GameObject enemyObj = Instantiate(enemy, spawnPos.position, enemy.transform.rotation);
            waveCount -= 1;
        }
    }

}
