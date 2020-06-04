using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpaceShip
{

    public float health;
    public float fuel;

    public float shipSpeed;
    public float aim;
    public float mobility;
    public float gunnerExp;
    public float pilotExp;


    public SpaceShip(float _health, float _fuel, float _shipSpeed, float _aim, float _mobility, float _gunnerExp, float _pilotExp) 
    {
        health = _health;
        fuel = _fuel;
        shipSpeed = _shipSpeed;
        aim = _aim;
        mobility = _mobility;
        gunnerExp = _gunnerExp;
        pilotExp = _pilotExp;
    }

    public void GetDamage(float damage) 
    {
        health -= damage;
    }

}
