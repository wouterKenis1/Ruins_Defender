using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaves : MonoBehaviour
{
    
      public Renderer renderer;
      MaterialPropertyBlock block;

      public Vector2 amplitude = new Vector2(0.4f, 0.5f);
      public Vector2 speed = new Vector2(0.4f, 0.6f);
      public Vector2 startPos = new Vector2();

      private Vector2 offset = new Vector2();


      private void Awake()
      {
          block = new MaterialPropertyBlock();
      }

      public void Update()
      {
          offset.x = startPos.x + Mathf.Sin(Time.time * speed.x) * amplitude.x;
          offset.y = startPos.y + Mathf.Cos(Time.time * speed.y) * amplitude.y;

          renderer.material.SetTextureOffset("_MainTex", offset);
      }
    
}
