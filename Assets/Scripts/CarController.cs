using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Splines;

public class CarController : MonoBehaviour
{
    // Reference to the Spline Animate component
    public SplineAnimate splineAnimate;
    // Movement speed
    public float moveSpeed = 2.0f;
    // Minimum and maximum offset values in the X-axis
    public float minXOffset = -5.0f;
    public float maxXOffset = 5.0f;
    // Current offset value
    private Vector3 offset = Vector3.zero;

    private void Start()
    {
        // Get the SplineAnimate component
        splineAnimate = GetComponent<SplineAnimate>();
    }

    private void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the additional movement vector
        Vector3 additionalMovement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Update the offset and check the limits
        float newOffsetX = Mathf.Clamp(offset.x + additionalMovement.x, minXOffset, maxXOffset);
        offset = new Vector3(newOffsetX, 0, 0);

        // Get the rotation from the Spline Animate
        Quaternion splineRotation = splineAnimate.transform.rotation;
        // Calculate the new position
        Vector3 newPosition = splineAnimate.transform.position + splineRotation * offset;

        // Update the object's position and rotation
        transform.position = newPosition;
        transform.rotation = splineRotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Time.timeScale = 0;
            GameManager.Instance.endGameUI.SetActive(true);
        }

    }
}



