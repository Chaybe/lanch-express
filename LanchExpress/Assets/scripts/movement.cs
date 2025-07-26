using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f; // graus por segundo
    public float rotationStep = 90f;

    private bool isMoving = false;
    private Vector3 moveDirection;
    private Quaternion targetRotation;

    void Start()
    {
        moveDirection = transform.forward;
        targetRotation = transform.rotation;
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.wKey.wasPressedThisFrame)
        {
            isMoving = true;
        }

        if (keyboard.sKey.wasPressedThisFrame)
        {
            isMoving = false;
        }

        if (keyboard.aKey.wasPressedThisFrame)
        {
            targetRotation *= Quaternion.Euler(0, -rotationStep, 0);
        }

        if (keyboard.dKey.wasPressedThisFrame)
        {
            targetRotation *= Quaternion.Euler(0, rotationStep, 0);
        }

        // Rotação suave
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        moveDirection = transform.forward;

        // Movimento
        if (isMoving)
        {
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
