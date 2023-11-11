using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDoubleClick : MonoBehaviour
{

    public float doubleClickTimeThreshold = 0.3f;

    private float lastClickTime = 0f;



    void Update()
    {
        DetectDoubleClicked();
    }

    void DetectDoubleClicked()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                float currentTime = Time.time;

                // Check if the time between two taps is within the threshold
                if (currentTime - lastClickTime < doubleClickTimeThreshold)
                {
                    // Double click detected
                    //Debug.Log("Double Click!");


                    if (GameManager.Instance.availableSpecialEffect != null && !GameManager.Instance.isPaused)
                    {
                        GameManager.Instance.availableSpecialEffect.ActivateSpecialEffect(GameManager.Instance);
                    }

                    // Reset the last click time
                    lastClickTime = 0f;
                }
                else
                {
                    // Record the time of the single click
                    lastClickTime = currentTime;
                }
            }
        }
    }
}
