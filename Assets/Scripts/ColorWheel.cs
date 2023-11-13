using UnityEngine;

public class ColorWheel : MonoBehaviour
{
   
    [SerializeField] float rotSpeed = 1;

    [SerializeField] float minSwipeDistance = 20f;

    public GameObject[] wheelBubbles;

    [HideInInspector] public float rotSpeedMultiplier = 1f;


    // should maybe be part of Game manager
    [SerializeField] Color[] Colors;

    public Color GetRandomColorFromWheel()
    {
        return Colors[Random.Range(0, Colors.Length - 1)];    
    }

  


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
                float rotateAmount = swipeDirection * rotSpeed *rotSpeedMultiplier;
                RotateWheel(rotateAmount);
            }
        }
    }

    void RotateWheel(float rotateAmount)
    {
        // Rotate the wheel around the Z-axis
        Quaternion targetRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + rotateAmount);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * rotSpeedMultiplier * Time.deltaTime);
    }

    public void InitializeColorsOnWheels()
    {
        if (wheelBubbles.Length == 0)
        {
            wheelBubbles = GameObject.FindGameObjectsWithTag("Wheel Bubble");
        }

        if(wheelBubbles.Length != Colors.Length)
        {
            throw new System.Exception("You need to have the same amount of colors and wheel bubbles");
        }

        for(int i = 0; i < Colors.Length; i++) {

            wheelBubbles[i].GetComponent<SpriteRenderer>().color = Colors[i];
        }
       
    }
}

