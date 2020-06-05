using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyType
    {

        asteroid,
        baseEnemy,
        
    }

public class EnemyStructure
{
    private float _health;
    private float health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0)
                EnemyDestroy();
        }
    }
    public float reload;

    private float mobility;
    private float gunnerExp;
    private float pilotExp;

    public float[] partHealth = new float[3] { 100f, 100f, 100f};// 0 - Engine. 1 - Cabine. 2 - Weapon.

    private EnemyType _enemyType;
    public EnemyStructure newEnemy;

    public float GetHealth(float _health) 
    {
        return health;
    }
    public void SetHealth(float _health) 
    {
        health = _health;
    }

    public float GetMobility(float _mobility)
    {
        return mobility;
    }
    public void SetMobility(float _mobility)
    {
        mobility = _mobility;
    }

    public float GetGunnerExp(float _gunnerExp)
    {
        return _gunnerExp;
    }
    public void SetGunnerExp(float _gunnerExp)
    {
        gunnerExp = _gunnerExp;
    }

    public float GetPilotExp(float _pilotExp)
    {
        return _pilotExp;
    }
    public void SetPilotExp(float _pilotExp)
    {
        pilotExp = _pilotExp;
    }

    public void CreateEnemy() 
    {
        _enemyType = (EnemyType)Random.Range(0, System.Enum.GetValues(typeof(EnemyType)).Length); //Выбираем рандомный тип врага 
        InitializationEnemy();
    }

    public virtual void InitializationEnemy() 
    {
        switch (_enemyType) 
        {
            case EnemyType.asteroid:             ///
                newEnemy = new AsteroidEnemy();   //
                newEnemy.InitializationEnemy();   //
                break;                            //Ещё не понял как вынести это в отдельную функцию
            case EnemyType.baseEnemy:             //
                newEnemy = new BaseEnemy();       //
                newEnemy.InitializationEnemy();  ///
                break;
        }
    }

    public void GetDamage(float damage) 
    {
        health -= damage;
    }

    public virtual void Atack()
    {
        Debug.Log("Shoot");
    }

    public virtual void EnemyDestroy() 
    {
    }

}

public class BaseEnemy : EnemyStructure
{
    public override void InitializationEnemy()
    {
        SetHealth(30);
        SetGunnerExp(1);
    }
    public override void Atack()
    {
        base.Atack();
    }
}

public class AsteroidEnemy : EnemyStructure 
{
    public override void InitializationEnemy() 
    {
        SetHealth(30);
    }
    public override void Atack() 
    { 

        base.Atack();
    }
}
