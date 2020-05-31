using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public float speed;
    public GameObject _target;

    public IEnumerator CameraMove(GameObject target)
    {
        GameObject __target;
        __target = _target;
        GetComponent<Animator>().Play("CameraMove");
        while (Vector2.Distance(target.transform.position, transform.position) > 0.1f)
        {
           // if (_target != __target)
             //   yield break;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -20), speed * Time.deltaTime);
            yield return null;
        }
    }
}
