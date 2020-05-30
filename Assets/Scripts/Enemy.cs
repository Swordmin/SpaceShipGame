using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int onAimId;

    private EnemyStructure _enemyStruct = new EnemyStructure();

    private void Start()
    {
        _enemyStruct.CreateEnemy();
        _enemyStruct.newEnemy.Atack();
    }

    public void GetDamage(float damage) 
    {
        _enemyStruct.partHealth[onAimId + 1] -= damage;
        _enemyStruct.GetDamage(damage);
    }

    public void OnAim(int id) 
    {
        onAimId = id;
    }

}
