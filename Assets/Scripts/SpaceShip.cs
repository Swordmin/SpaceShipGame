﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpaceShip 
{

    public float heath;
    public float fuel;

    public float shipSpeed;
    public float aim;
    public float mobility;
    public float gunnerExp;
    public float pilotExp;

    public SpaceShip(float _heath, float _fuel, float _shipSpeed, float _aim, float _mobility, float _gunnerExp, float _pilotExp) 
    {
        heath = _heath;
        fuel = _fuel;
        shipSpeed = _shipSpeed;
        aim = _aim;
        mobility = _mobility;
        gunnerExp = _gunnerExp;
        pilotExp = _pilotExp;
    }

}
