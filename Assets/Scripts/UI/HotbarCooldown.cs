using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarCooldown : MonoBehaviour
{
    public MaskableGraphic img;
    public TMP_Text text;

    public bool use_text;
    public bool use_img;

    // value [0;1]
    private float value;

    private void OnEnable()
    {
        if(text != null)
        {
            text.gameObject.SetActive(use_text);
        }
        else
        {
            use_text = false;
        }
        if (img != null)
        {
            img.gameObject.SetActive(use_img);
        }
        else
        {
            use_img = false;
        }

    }
    public void Update()
    {
        value = Mathf.Clamp01(GetValue());
        if(use_text)
        {
            text.gameObject.SetActive(value > 0f);
            text.text = value.ToString("F1");
        }
        if(use_img )
        {
            img.gameObject.SetActive(value > 0f);
            img.transform.localScale = new Vector3(value, 1, 1);
        }
    }

    public virtual float GetValue()
    {
        return 0f;
    }
}
