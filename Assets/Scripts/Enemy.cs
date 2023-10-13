using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Random r = new Random();
    private Animator _animator;
    private bool _destroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _destroyed = false;
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
        transform.position = new Vector3(r.Next(-8, 8), 8f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 1.0f);
        }
        else if (other.tag.Equals("Laser"))
        {
            Destroy(other.gameObject);
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            Player player = playerObject.gameObject.transform.GetComponent<Player>();

            if (_destroyed ==  false)
            {
                player.AddToScore(10);
            }
            _destroyed = true;
            Destroy(this.gameObject, 1.0f);
            

        }
    }
}
