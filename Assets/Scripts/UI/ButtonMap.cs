using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMap : MonoBehaviour
{

    [SerializeField] private bool open;
    [SerializeField] private GameObject map;

    public void OpenMap() 
    {
        if (open)
        {
            map.SetActive(false);
            open = false;
        }
        else 
        {
            map.SetActive(true);
            open = true;
        }
    }

}
