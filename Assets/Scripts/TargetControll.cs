using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControll : MonoBehaviour
{

    public PlayerControll _pC;

    [SerializeField] private GameObject camera;
    [SerializeField] private CameraControll _cameraControll;
    public void SetTarget() 
    {
        _pC.targetEnemy = gameObject;
        _cameraControll.StartCoroutine("CameraMove", gameObject);
        _cameraControll._target = gameObject;
    }

}
