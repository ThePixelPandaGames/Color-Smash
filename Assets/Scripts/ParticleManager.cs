using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem fireSpecialEffect;
       

    public void PlayFireParticleEffect()
    {
        fireSpecialEffect.Play();
    }
}
