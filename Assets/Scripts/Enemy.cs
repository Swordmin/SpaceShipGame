using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public BaseEnemy _baseEnemy = new BaseEnemy();
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;

    [SerializeField] private GameController _gameController;

    public Image healthBar;

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

    private void Awake()
    {
        GetComponent<Animator>().Play("Begin");
        StartCoroutine(TimerAim());
        _baseEnemy.CreateEnemy();
    }

    private void Start()
    {
        _gameController = GameObject.Find("SceneControll").GetComponent<GameController>();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Debug.Log(_baseEnemy.partHealth[2]);
        }

    }

    private void Fire() 
    {
        GameObject _bullet = Instantiate(bullet, gun.transform.position, gameObject.transform.rotation);
        float сalculation = 50f + _baseEnemy.GetGunnerExp(0);
        _bullet.GetComponent<BulletControll>().сhanceMiss = сalculation - Percent(сalculation, 100 - _baseEnemy.partHealth[2], 0); // Выставляем зависимость общего шанса попасть, от целостности отсека с оружием.
        Debug.Log((50f + _baseEnemy.GetGunnerExp(0)) * (100 - _baseEnemy.partHealth[2])/100);
    }

    
    public void GetDamage(float damage, int id) 
    {
        _baseEnemy.partHealth[id] -= damage;
        _baseEnemy.GetDamage(damage);
        healthBar.fillAmount = _baseEnemy.GetHealth(0)/100;
        if (_baseEnemy.GetHealth(0) <= 0) 
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

    private float Percent(float a, float p, float result) 
    {
        return result = a * (p / 100);
    } //Считаем процент который будем отнимать от шанса попадания 



}
