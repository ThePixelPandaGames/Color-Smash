using UnityEngine;

public class ColorWheel : MonoBehaviour
{
   
    [SerializeField] float rotSpeed = 1;

    [SerializeField] float minSwipeDistance = 20f;


    // should maybe be part of Game manager
    [SerializeField] Color[] hexCodeColors;



    void Start()
    {
        InitializeColorsOnWheels();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved && Mathf.Abs(touch.deltaPosition.y) >= minSwipeDistance)
            {
                float swipeDirection = Mathf.Sign(touch.deltaPosition.y);
                float rotateAmount = swipeDirection * rotSpeed;
                RotateWheel(rotateAmount);
            }
        }
    }

    void RotateWheel(float rotateAmount)
    {
        // Rotate the wheel around the Z-axis
        Quaternion targetRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + rotateAmount);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }

    void InitializeColorsOnWheels()
    {
        GameObject[] wheelBubbles = GameObject.FindGameObjectsWithTag("Wheel Bubble");

        if(wheelBubbles.Length != hexCodeColors.Length)
        {
            throw new System.Exception("You need to have the same amount of colors and wheel bubbles");
        }

        for(int i = 0; i < hexCodeColors.Length; i++) {

            wheelBubbles[i].GetComponent<SpriteRenderer>().color = hexCodeColors[i];
        }
       
    }
}

