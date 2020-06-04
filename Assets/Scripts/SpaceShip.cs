using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpaceShip
{

    private float health;

    private float mobility;
    private float gunnerExp;
    private float pilotExp;


    public SpaceShip(float _health, float _fuel, float _shipSpeed, float _aim, float _mobility, float _gunnerExp, float _pilotExp) 
    {
        health = _health;
        mobility = _mobility;
        gunnerExp = _gunnerExp;
        pilotExp = _pilotExp;
    }

    public float GetHealth(float _health) 
    {
        return health;
    }   //Я вкурсе что инкапсуляция это чуть глубже чем просто сокрытие, но на данный момент я ещё этого не просёк(04.06.2020).
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
    public void SetPilotExpx(float _pilotExp)
    {
        pilotExp = _pilotExp;
    }

    public void GetDamage(float damage) 
    {
        health -= damage;
    }

}
