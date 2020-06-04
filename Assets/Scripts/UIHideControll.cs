using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHideControll : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(MoveUP());
    }

    IEnumerator MoveUP() 
    {
        while (true) 
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
            yield return null;
        }
    }

}
