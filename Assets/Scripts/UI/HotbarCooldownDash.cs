using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarCooldownDash : HotbarCooldown
{
    PlayerInput playerInput;
    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public override float GetValue()
    {
        //return playerInput.DashCooldown    
        return 0f;
    }
}
