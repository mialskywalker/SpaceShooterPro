using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerupID;
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
            Destroy(this.gameObject);
        }
    }
    
    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
              
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        Debug.Log("triple shot");
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        Debug.Log("speed boost");
                        break;
                    case 2:
                        Debug.Log("shield boost");
                        break;
                }
            }
            Destroy(this.gameObject);

        }
    }
}
