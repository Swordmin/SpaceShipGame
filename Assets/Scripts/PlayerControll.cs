using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControll : MonoBehaviour
{

    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject groupAtack;
    [SerializeField] private GameObject cameraAtack;
    [SerializeField] private Image IndexAim;

    [SerializeField] private float scatter;

    public GameObject targetEnemy;
    public Rigidbody2D _rigidbody;

    SpaceShip ship = new SpaceShip(100, 10, 0, 1, 2);

    public float testSpeed;

    public Vector3 worldPos;

    public bool autoAim;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(TimerAim());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(testSpeed,0);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.J)) 
        {
            groupAtack.SetActive(true);
            cameraAtack.SetActive(true);
        }

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
        bullet.GetComponent<BulletControll>().scatter = scatter;
    }

    private void AtackStart() 
    {
        groupAtack.SetActive(true);
    }


    IEnumerator TimerAim() 
    {
        while (true) 
        {
            IndexAim.fillAmount += 0.01f;
            scatter -= 0.01f;
            yield return new WaitForSeconds(0.5f);
            if (IndexAim.fillAmount >= 1)
                break;
        }
    }

}