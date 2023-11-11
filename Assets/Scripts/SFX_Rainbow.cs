using UnityEngine;

public class SFX_Rainbow: SpecialEffect
{
    public override void ActivateSpecialEffect(GameManager gameManager)
    {
        Debug.Log("Activating Effect");
        cooldown = COOLDOWN_SECONDS;

        // slow down clock timer -> time manager
        gameManager.ActivateRainbow(cooldown);
      
    }

 

}
