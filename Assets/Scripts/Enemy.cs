using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public BaseEnemy _baseEnemy = new BaseEnemy();
    public GameObject player;
    public GameObject bullet;
    public GameObject gun;

    public GameController _gameController;

    private float _reload;
    [SerializeField] private float reload 
    {
        get { return _reload; }
        set
        {

            _reload = value;
            if (_reload >= 1) 
            {
                if (GetComponent<SpriteRenderer>())
                {
                    Fire();
                    _reload = 0;
                }
            }

        }
    }

    private void Start()
    {
        _gameController = GameObject.Find("SceneControll").GetComponent<GameController>();
    }

    public void Update()
    {
    }

    private void Fire() 
    {
        GameObject _bullet = Instantiate(bullet, gun.transform.position, gameObject.transform.rotation);
        _bullet.GetComponent<BulletControll>().сhanceMiss = 50f + _baseEnemy.gunnerExp; 
    }

    private void Awake()
    {
        GetComponent<Animator>().Play("Begin");
        StartCoroutine(TimerAim());
        _baseEnemy.CreateEnemy();
    }

    

    public void GetDamage(float damage, int id) 
    {
        _baseEnemy.partHealth[id + 1] -= damage;
        _baseEnemy.GetDamage(damage);
        GetComponent<TargetControll>().healthIndex.fillAmount = _baseEnemy.Health/100;
        if (_baseEnemy.Health <= 0) 
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInChildren<ParticleSystem>().Play();
            GetComponent<BoxCollider2D>().enabled = false;
            _gameController.SpawnEnemy();
            GetComponent<Enemy>().enabled = false;
        }
    }

    private IEnumerator TimerAim()
    {
        while (true)
        {
            reload += Random.Range(0.05f, 0.2f);
            yield return new WaitForSeconds(0.5f);
        }
    }



}
