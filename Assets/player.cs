using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class player : MonoBehaviour
{
    Vector2 offset;
    public float minAngle = -30f;    // Minimum angle in degrees
    public float maxAngle = 30f;     // Maximum angle in degrees
    public float rotationSpeed = 45f; // Rotation speed in degrees per second

    public float currentAngle = 0f;
    private int direction = 1;
    public bool Stop;
    public float newAngle;
    private void Update()
    {
        if (!Stop)
            transform.position += transform.right * 3 * Time.deltaTime;


        else
        {

            newAngle = currentAngle + (rotationSpeed * direction * Time.deltaTime);
            // If the new angle goes beyond the min or max, reverse direction
            if (newAngle < minAngle || newAngle > maxAngle)
            {
                direction *= -1;
            }
            newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
            transform.rotation = Quaternion.Euler(0f, 0f, newAngle);
            currentAngle = newAngle;
            // Debug.Log(currentAngle);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // transform.rotation = Quaternion.Euler(0f, 0f, currentAngle + 180);
        newAngle = currentAngle + 180;
        // 
        minAngle = newAngle - 45;
        maxAngle = newAngle + 45;
        // Debug.Break();
        Stop = true;
    }


    [ContextMenu("test")]
    public void move()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right, transform.right, 50f);
        Debug.Log(hit.point);
        Vector2 diff = hit.point - (Vector2)transform.position;
        offset = diff.normalized;
        transform.DOMove(hit.point - offset, 1f, false);
    }
}
