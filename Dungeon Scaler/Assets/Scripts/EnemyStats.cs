using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats: MonoBehaviour
{
    //Health and starting damage of enemy
    public int health;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    //Damage taken by enemy
    public void damageTaken(int temp)
    {
        health -= temp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
