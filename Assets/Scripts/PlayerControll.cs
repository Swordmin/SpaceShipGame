using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControll : MonoBehaviour
{

    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject gun;

    public GameObject targetEnemy;
    public Rigidbody2D _rigidbody;

    SpaceShip ship = new SpaceShip(100, 10, 0, 1, 2);

    public float testSpeed;

    public Vector3 worldPos;

    public bool autoAim;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(testSpeed,0);
    }

    private void Update()
    {

        if(targetEnemy != null)
        {
            worldPos = Input.mousePosition;
            worldPos = targetEnemy.transform.position;
        }
        float dx = transform.position.x - worldPos.x;
        float dy = transform.position.y - worldPos.y;
        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        transform.rotation = rot;
    }

    public void Move(float speed) 
    {
        testSpeed = speed;
    }

    public void Fire() 
    {
        GameObject bullet = Instantiate(bulletPref, gun.transform.position, gameObject.transform.rotation);
        bullet.GetComponent<BulletControll>().scatter = 3;
    }

    public void AutoAimEnable() 
    {
        if (autoAim)
            autoAim = false;
        else
            autoAim = true;
    }

}
