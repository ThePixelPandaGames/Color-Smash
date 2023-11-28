public class SFX_SlowTime : SpecialEffect
{
    public override void ActivateSpecialEffect(GameManager gameManager)
    {
        cooldown = COOLDOWN_SECONDS;

        // slow down clock timer -> time manager
        gameManager.HalfClockTime(cooldown);


        // slow down enemy move speed -> game manager
        gameManager.HalfEnemySpeed(cooldown);

      
    }

 

}
