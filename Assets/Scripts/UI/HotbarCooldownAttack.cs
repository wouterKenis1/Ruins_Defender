using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarCooldownAttack : HotbarCooldown
{
    Weapon weapon;
    private void Awake()
    {
        weapon = FindObjectOfType<Weapon>();
    }

    public override float GetMaxValue()
    {
        return (1 / weapon.castSpeed);
    }
    public override float GetValue()
    {
        return weapon.castCooldown ;
    }
}
