using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float MaxSize = 40;
    public float Speed = 1;
    public float Damage = 50;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;

        if (transform.localScale.x > MaxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.DealDamage(Damage);
        }

        var EnemyHealth = other.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(Damage);
        }
    }
}
