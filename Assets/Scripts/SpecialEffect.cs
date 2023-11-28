using System;
using UnityEngine;

[Serializable]
public abstract class SpecialEffect
{
    public Sprite image;

    [HideInInspector]public const int COOLDOWN_SECONDS = 10;
    [HideInInspector]public int cooldown = 10;


    public abstract void ActivateSpecialEffect(GameManager gameManager);

}
