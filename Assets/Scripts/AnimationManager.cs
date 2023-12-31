using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator centerSpinAnimator;
    public Animator effectImageAnimator;
    public Animator levelUpAnim;


    public void StartCenterSpinAnim()
    {
        centerSpinAnimator.SetTrigger("startSpin");
    }

    public void StopCenterSpin()
    {
        centerSpinAnimator.SetTrigger("stopSpin");

    }

    public void StartPulseAnim()
    {
        effectImageAnimator.SetTrigger("startPulse");
    }

    public void StopPulseAnim()
    {
        effectImageAnimator.SetTrigger("stopPulse");

    }

    public void StartLevelUpAnim()
    {
        levelUpAnim.SetTrigger("levelUp");

    }

    public void StartEffectAnim()
    {
        effectImageAnimator.SetTrigger("activate");

    }

    public void StopEffectAnim()
    {
        effectImageAnimator.SetTrigger("stopActivation");

    }
}
