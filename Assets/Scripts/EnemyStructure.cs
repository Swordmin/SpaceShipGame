using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
    {

        asteroid,
        baseEnemy,
        
    }

public class EnemyStructure
{
    private float _health;
    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0)
                EnemyDestroy();
        }
    }
    public bool enemyLife = true;
    private EnemyType _enemyType;
    public EnemyStructure newEnemy;

    public void CreateEnemy() 
    {
        _enemyType = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length); //Выбираем рандомный тип врага 
        InitializationEnemy();
    }

    public virtual void InitializationEnemy() 
    {
        switch (_enemyType) 
        {
            case EnemyType.asteroid:
                newEnemy = new AsteroidEnemy();
                newEnemy.InitializationEnemy();
                break;
            case EnemyType.baseEnemy:
                newEnemy = new BaseEnemy();
                newEnemy.InitializationEnemy();
                break;
        }
    }

    public void GetDamage(float damage) 
    {
        Health -= damage;
    }

    public virtual void Atack()
    {
        Debug.Log("Shoot");
    }

    public virtual void EnemyDestroy() 
    {
        enemyLife = false;
    }

}

public class BaseEnemy : EnemyStructure
{
    public override void InitializationEnemy()
    {
        Health = 30;
    }
    public override void Atack()
    {
        Debug.Log("Find");
        base.Atack();
    }
}

public class AsteroidEnemy : EnemyStructure 
{
    public override void InitializationEnemy() 
    {
        Health = 30;
    }
    public override void Atack()
    {
        Debug.Log("NoActive");
        base.Atack();
    }
}
