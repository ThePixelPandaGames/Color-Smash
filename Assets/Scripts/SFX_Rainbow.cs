public class SFX_Rainbow: SpecialEffect
{
    public override void ActivateSpecialEffect(GameManager gameManager)
    {
        cooldown = COOLDOWN_SECONDS;

        // slow down clock timer -> time manager
        gameManager.ActivateRainbow(cooldown);
      
    }

 

}
