using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifettime;
    public float damage = 10;

    void FixedUpdate()
    {
        MoveFixedUpate();
    }

    private void Start()
    {
        Invoke("DestroyFireball", lifettime);
    }

    // Update is called once per frame
    private void MoveFixedUpate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }

    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
}