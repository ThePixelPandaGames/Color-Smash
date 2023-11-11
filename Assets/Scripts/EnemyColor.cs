using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        ColorWheel colorWheel = GameObject.Find("Color Wheel").GetComponent<ColorWheel>();

        spriteRenderer.color = colorWheel.GetRandomColorFromWheel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
