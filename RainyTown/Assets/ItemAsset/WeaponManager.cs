﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponType
    {

        StoneSword,
        GoldSword,
        Excalibur,
    }

    [SerializeField]
    private int attackPower;

    [SerializeField]
    private WeaponType weaponType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetAttackPower()
    {
        return attackPower;
    }

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }
}
