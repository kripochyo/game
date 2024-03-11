using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform ValueRectTransform;
    public float HealAmount = 50;

    public GameObject GameplayUI;
    public GameObject GameOverScreen;
    public Animator animator;

    private float _maxValue;

    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
   
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlyerIsDead();
        }

        DrawHealthBar();
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }

    private void PlyerIsDead()
    {
        GameplayUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("Death");
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }

}
