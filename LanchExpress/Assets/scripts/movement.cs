using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f; // graus por segundo
    public GameObject GUIMenuMissoes;
    private bool isMovingForward = false;
    public int dano = 100;
    private AudioSource motorAudio;

    void Start()
    {
        if (GUIMenuMissoes != null)
            GUIMenuMissoes.SetActive(false);

        motorAudio = GetComponent<AudioSource>();
        if (motorAudio != null)
            motorAudio.Stop();
    }

    void Update()
    {
        var keyboard = Keyboard.current;

        isMovingForward = keyboard.upArrowKey.isPressed;

        bool isTurning = keyboard.leftArrowKey.isPressed || keyboard.rightArrowKey.isPressed;
        bool isReversing = keyboard.downArrowKey.isPressed;

        if ((isMovingForward || isTurning || isReversing) && motorAudio != null && !motorAudio.isPlaying)
        {
            motorAudio.Play();
        }
        else if (!isMovingForward && !isTurning && !isReversing && motorAudio != null && motorAudio.isPlaying)
        {
            motorAudio.Pause();
        }

        if (keyboard.leftArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (keyboard.rightArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (isMovingForward)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (keyboard.downArrowKey.isPressed)
        {
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("missions_base_get"))
        {
            GUIMenuMissoes?.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("city"))
        {
            if(dano <= 0)
            {
                Debug.Log("Game Over");
            }
            else
            {
                dano -= 50;
                Debug.Log("Colisão com a cidade! Dano: " + dano);
            }
        }
    }

    public void FecharMenuMissoes()
    {
        GUIMenuMissoes?.SetActive(false);
    }
}
