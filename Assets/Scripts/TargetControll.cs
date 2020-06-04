using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetControll : MonoBehaviour
{

    public PlayerControll _pC;
    public Image healthIndex;

    [SerializeField] private GameObject camera;
    [SerializeField] private CameraControll _cameraControll;

    private void Start()
    {
        camera = GameObject.Find("FightModeCamera");
        _cameraControll = GameObject.Find("FightModeCamera").GetComponent<CameraControll>();
        _pC = GameObject.Find("Player").GetComponent<PlayerControll>();
        healthIndex = GameObject.Find("IndexHealth").GetComponent<Image>();
        healthIndex.fillAmount = GetComponent<Enemy>()._baseEnemy.Health / 100;

    }

    public void SetTarget()
    {
        _pC.targetEnemy = gameObject;
        _cameraControll.StartCoroutine("CameraMove", gameObject);
        _cameraControll._target = gameObject;
        healthIndex.fillAmount = GetComponent<Enemy>()._baseEnemy.Health / 100;
    }

}