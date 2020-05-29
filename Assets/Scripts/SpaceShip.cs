using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpaceShip 
{

    public float heath;
    public float fuel;

    public float shipSpeed;
    public float aim;
    public float mobility;

    public SpaceShip(float _heath, float _fuel, float _shipSpeed, float _aim, float _mobility) 
    {
        heath = _heath;
        fuel = _fuel;
        shipSpeed = _shipSpeed;
        aim = _aim;
        mobility = _mobility;
    }

}
