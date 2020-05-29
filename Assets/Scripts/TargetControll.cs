using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControll : MonoBehaviour
{

    public PlayerControll PC;

    public void SetTarget() 
    {
        PC.targetEnemy = gameObject;
    }

}
