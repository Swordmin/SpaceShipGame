﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{

    public float scatter;
    public float damage = 10f;

    [SerializeField] private Rigidbody2D _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        float _scatter = Random.Range(-scatter, scatter);
        _rigidBody.AddForce((Vector2.right * _scatter), ForceMode2D.Impulse);
    }

    private void Awake()
    {
        Destroy(gameObject, 5f);
        //_rigidBody.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

        //_rigidBody.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
        transform.Translate(Vector2.up / 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }
    }

}
