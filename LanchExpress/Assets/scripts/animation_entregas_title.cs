using UnityEngine;

public class animation_entregas_title : MonoBehaviour
{
    public float floatAmplitude = 5f; // Quanto o texto sobe e desce
    public float floatSpeed = 3f;      // Velocidade da flutuação

    private Vector3 startPos;

    void Start()
    {
        // Salva a posição inicial do objeto
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Calcula a nova posição vertical com base no tempo
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = startPos + new Vector3(0, newY, 0);
    }
}
