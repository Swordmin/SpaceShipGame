using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{

    public float scatter;
    public float damage = 10f;
    public int onAimId;

    public float сhanceMiss;

    [SerializeField] private GameObject missImage;
    [SerializeField] private GameObject damageImage;


    [SerializeField] private Rigidbody2D _rigidBody;
    public PlayerControll _pC;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        float _scatter = Random.Range(-scatter, scatter);                     //Толкаем пулю в лево или право для создания разброса                  
        _rigidBody.AddForce((Vector2.right * _scatter), ForceMode2D.Impulse); //
    }

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up / 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float _chanceMiss = 100 - сhanceMiss;
        float i = Random.Range(0f, 100f);
        Debug.Log(_chanceMiss.ToString() + "  " + i.ToString());
        if (collision.GetComponent<Enemy>() && i < _chanceMiss)
        {

            collision.GetComponent<Enemy>().GetDamage(damage, onAimId);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            _pC.ship.SetGunnerExp(_pC.ship.GetGunnerExp(0) + 1);
            Instantiate(damageImage, new Vector2(transform.position.x, transform.position.y + Random.Range(0.5f, 1.5f)), Quaternion.identity);

        }
        else if(i > _chanceMiss && collision.GetComponent<Enemy>())
        {
            Instantiate(missImage, new Vector2(transform.position.x, transform.position.y + Random.Range(0.5f, 1.5f)), Quaternion.identity);
        }

        if (collision.GetComponent<PlayerControll>() && i < _chanceMiss) 
        {
            collision.GetComponent<PlayerControll>().GetDamage(damage);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            Instantiate(damageImage, new Vector2(transform.position.x, transform.position.y + Random.Range(0.5f, 1.5f)), Quaternion.identity);
        }
        else if(i > _chanceMiss && collision.GetComponent<PlayerControll>())
        {
            Instantiate(missImage, new Vector2(transform.position.x,transform.position.y + Random.Range(0.5f,1.5f)), Quaternion.identity);
        }
    }

}
