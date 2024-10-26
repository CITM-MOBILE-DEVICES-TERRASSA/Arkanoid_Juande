using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menu; // Asigna el GameObject del menú en el Inspector

    private void Update()
    {
        // Verifica si se presiona la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleMenu(); // Llama al método para alternar el menú
        }
    }

    private void ToggleMenu()
    {
        // Alterna la visibilidad del menú
        menu.SetActive(!menu.activeSelf);
    }
}

