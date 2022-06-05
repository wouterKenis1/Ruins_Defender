using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectBuild : ClickableObject
{
    public StringIntDict cost;
    public GameObject obelisk;

    public override void Click()
    {
        if(Player.Instance.HasResources(cost))
        {
            Player.Instance.RemoveItems(cost);
            obelisk.SetActive(true);
            Destroy(this);
        }
    }

}
