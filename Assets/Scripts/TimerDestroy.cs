using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    [SerializeField] float timerDestroy;

    private void Start()
    {
        StartCoroutine(DestroyObj(timerDestroy));
    }

    IEnumerator DestroyObj(float Timer) 
    {
        yield return new WaitForSeconds(Timer);
        Destroy(gameObject);
    }
}
