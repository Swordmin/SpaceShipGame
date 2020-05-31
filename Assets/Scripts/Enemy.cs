using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private EnemyStructure _enemyStruct = new EnemyStructure();

    private void Start()
    {
        _enemyStruct.CreateEnemy();
        _enemyStruct.newEnemy.Atack();
    }

    public void GetDamage(float damage, int id) 
    {
        _enemyStruct.partHealth[id + 1] -= damage;
        Debug.Log(_enemyStruct.partHealth[id + 1].ToString());
        _enemyStruct.GetDamage(damage);
    }



}
