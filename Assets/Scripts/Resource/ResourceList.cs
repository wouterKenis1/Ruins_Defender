using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ResourceList", menuName = "ScriptableObjects/ResourceList", order = 1)]
public class ResourceList : ScriptableObject
{
    [SerializeField] public int crystal_red = 0;
    [SerializeField] public int crystal_green = 0;
    [SerializeField] public int crystal_blue = 0;

    
    public void ClearResources()
    {
        crystal_red = 0;
        crystal_green = 0;
         crystal_blue = 0;
    }
    public void AddRecource(Resource resource)
    {
        switch(resource)
        {
            case Resource.Crystal_R:
                crystal_red++;
                break;
            case Resource.Crystal_G:
                crystal_green++;
                break;
            case Resource.Crystal_B:
                crystal_blue++;
                break;
        }
    }
}


