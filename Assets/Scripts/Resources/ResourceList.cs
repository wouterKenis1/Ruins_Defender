using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceList", menuName = "ScriptableObjects/ResourceList", order = 1)]
public class ResourceList : ScriptableObject
{
    public int crystal_red = 0;
    public int crystal_green = 0;
    public int crystal_blue = 0;

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
