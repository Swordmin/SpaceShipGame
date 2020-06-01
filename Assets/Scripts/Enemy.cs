using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public BaseEnemy _baseEnemy = new BaseEnemy();

    private void Start()
    {
        _baseEnemy.CreateEnemy();
        _baseEnemy.Atack();
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
        }
    }



}
