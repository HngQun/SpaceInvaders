using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float healpoint = 5f;
    private float currentHealth;
    public GameManeger gameManeger;
    void Start()
    {
        gameManeger = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManeger>();
        currentHealth = healpoint;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (currentHealth <= 0)
            {
                gameManeger.addScore();
                Destroy(this.gameObject);
            }
            else
            {
                currentHealth--;
            }
        }
    }

}

