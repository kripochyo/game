using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> Levls;
    
    public RectTransform experianceValueRectTransform;
    public TextMeshProUGUI levlValueTMP;

    private int _LevelValue = 1;

    private float _ExperienceCurrentValue = 0;
    private float _ExperienceTargetValue = 100;

   
    private void start()
    {
        SetLevl(_LevelValue);
        DrawUI();
    }


    public void AddExperience(float value)
    {
        _ExperienceCurrentValue += value;
        if(_ExperienceCurrentValue >= _ExperienceTargetValue)
        {
            SetLevl(_LevelValue + 1);
            _ExperienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevl(int value)
    {
        _LevelValue = value;

        var CurrentLevl = Levls[_LevelValue - 1];
        _ExperienceTargetValue = CurrentLevl.ExperienceForTheNextLevl;
        GetComponent<FireballCaster>().Damage = CurrentLevl.FireballDamage;
        GetComponent<GrenadeCaster>().Damage = CurrentLevl.GrenadeDamage;

        var GrenadeCaster = GetComponent<GrenadeCaster>();
        GrenadeCaster.Damage = CurrentLevl.GrenadeDamage;

        if (CurrentLevl.GrenadeDamage < 0)
            GrenadeCaster.enabled = false;
        else
            GrenadeCaster.enabled = true;
    }


    private void DrawUI()
    {
        experianceValueRectTransform.anchorMax = new Vector2(_ExperienceCurrentValue / _ExperienceTargetValue, 1);
        levlValueTMP.text = _LevelValue.ToString();
    }
}
