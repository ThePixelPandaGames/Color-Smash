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

    private SpecialEffect CreateRainbowEffect()
    {
        effectImage = rainbowImage;
        return new SFX_Rainbow();
    }

    private SpecialEffect CreateDestroyEffect()
    {
        effectImage = rainbowImage;
        return new SFX_Destroy();
    }


    public SpecialEffect CreateRandomEffect()
    {
        int random = Random.Range(0, 3);

        switch(random) {
            case 0: return CreateSlowTimeEffect();
            case 1: return CreateRainbowEffect();   
            case 2: return CreateDestroyEffect();
        }
        return null;
    }



}
