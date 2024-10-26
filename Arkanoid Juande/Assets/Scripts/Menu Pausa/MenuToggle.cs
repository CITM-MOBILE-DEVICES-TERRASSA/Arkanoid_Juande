using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu; // Asigna el GameObject del men� en el Inspector

    private void Update()
    {
        // Verifica si se presiona la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleMenu(); // Llama al m�todo para alternar el men�
        }
    }

    private void ToggleMenu()
    {
        // Alterna la visibilidad del men�
        menu.SetActive(!menu.activeSelf);
    }
}

