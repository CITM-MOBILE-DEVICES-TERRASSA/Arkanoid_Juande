using UnityEngine;
using UnityEngine.UI;

public class SliderMovement : MonoBehaviour
{
    public Slider movementSlider;  // Asigna el slider desde el inspector
    private float minX;
    private float maxX;


    void Start()
    {
        // Calcula los límites de la pantalla en unidades del mundo
        minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        ResetPlayer();
    }

    void Update()
    {
        // Mapea el valor del slider (0-1) a la posición X del cuadrado dentro de los límites de la pantalla
        float xPos = Mathf.Lerp(minX, maxX, movementSlider.value);

        // Mueve el cuadrado a la posición calculada
        transform.position = new Vector2(xPos, transform.position.y);
    }

    public void ResetPlayer()
    {
        movementSlider.value = 0.5f;
    }




}
