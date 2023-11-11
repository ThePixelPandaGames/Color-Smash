using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectFactory : MonoBehaviour 
{
    public Sprite slowDownTimeImage, rainbowImage, destroyImage;
    public Sprite effectImage;


    private SpecialEffect CreateSlowTimeEffect()
    {
        effectImage = slowDownTimeImage;
        return new SFX_SlowTime();
    }


    public SpecialEffect CreateRandomEffect()
    {
        return CreateSlowTimeEffect();
    }

}
