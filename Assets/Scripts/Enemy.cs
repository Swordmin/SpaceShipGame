using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EnemyStructure _enemyStruct = new EnemyStructure();

    public void Start()
    {
        _enemyStruct.CreateEnemy();
        _enemyStruct.newEnemy.Atack();
    }

    public void GetDamage(float damage) 
    {
        _enemyStruct.newEnemy.GetDamage(damage);
        if (!_enemyStruct.newEnemy.enemyLife)
            Destroy(gameObject);
    }
    

}
