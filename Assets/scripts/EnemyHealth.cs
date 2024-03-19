using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public PlayerProgress PlayerProgress;


    private void Start()
    {
        PlayerProgress = FindObjectOfType<PlayerProgress>();
    }

    public bool IsAlive()
    {
        return value > 0;
    }

    public void DealDamage(float damage)
    {
        PlayerProgress.AddExperience(damage);

        value -= damage;
        if(value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
