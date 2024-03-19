using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float Damage = 10;
    
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var Fireball = Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            Fireball.damage = Damage;
        }
        
    }
}
