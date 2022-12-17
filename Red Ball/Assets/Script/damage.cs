using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    [SerializeField] int enemyPoint = 2;

    Enemy enemy;

    void Awake()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<UI>().AddToScore(enemyPoint);        
        }
    }

}
