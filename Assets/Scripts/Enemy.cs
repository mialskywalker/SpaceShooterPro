﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Random r = new Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
        if (transform.position.y <= -8f)
        {
            Respawn();
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void Respawn()
    {
        transform.position = new Vector3(r.Next(-10, 10), 8f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
        else if (other.tag.Equals("Laser"))
        {
            Destroy(other);
            Destroy(this.gameObject);
        }
    }
}