using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Delay = 3;
    public GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision coliision)
    {
        Invoke("Explosion", Delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;
    }
}
