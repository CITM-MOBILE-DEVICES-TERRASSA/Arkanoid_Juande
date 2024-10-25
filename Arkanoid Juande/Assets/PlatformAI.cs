using UnityEngine;

public class PlatformAI : MonoBehaviour
{
    public Transform ball;          // Referencia a la bola, asignar desde el inspector
    public SliderMovement platform; // Referencia al script de movimiento manual, asignar desde el inspector
    private bool autoPlayEnabled = false;

    private float minX;
    private float maxX;

    private void Start()
    {
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    private void Update()
    {
        if (autoPlayEnabled && ball != null)
        {
            AutoMovePlatform();
        }
    }

    private void AutoMovePlatform()
    {
        // Calcula la posición en X de la bola y mapea a los límites de la pantalla
        float targetPosX = Mathf.Clamp(ball.position.x, minX, maxX);
        platform.transform.position = new Vector2(targetPosX, platform.transform.position.y);
    }

    public void ToggleAutoPlay()
    {
        autoPlayEnabled = !autoPlayEnabled;
        platform.enabled = !autoPlayEnabled; // Activa/desactiva el control manual
    }
}
