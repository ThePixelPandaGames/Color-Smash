using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;

public class ColorWheel : MonoBehaviour
{
   
    [SerializeField] float rotSpeed = 1;

    [SerializeField] float minSwipeDistance = 20f;




    void Start()
    {
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
}

