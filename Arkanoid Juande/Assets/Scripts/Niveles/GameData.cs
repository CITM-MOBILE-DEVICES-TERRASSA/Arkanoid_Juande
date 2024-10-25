using UnityEngine;

public class GameData : MonoBehaviour
{
    private const string LivesKey = "Lives";
    private const string PointsKey = "Points";

    // Método para guardar las vidas y los puntos en PlayerPrefs
    public static void SaveData(int lives, int points)
    {
        PlayerPrefs.SetInt(LivesKey, lives);
        PlayerPrefs.SetInt(PointsKey, points);
        PlayerPrefs.Save(); // Guarda los datos en disco
    }

    // Método para cargar las vidas guardadas; si no existe el dato, devuelve un valor predeterminado
    public static int LoadLives(int defaultLives = 3)
    {
        return PlayerPrefs.GetInt(LivesKey, defaultLives);
    }

    // Método para cargar los puntos guardados; si no existe el dato, devuelve 0
    public static int LoadPoints(int defaultPoints = 0)
    {
        return PlayerPrefs.GetInt(PointsKey, defaultPoints);
    }

    // Método para borrar los datos guardados (opcional, útil para "Nueva Partida")
    public static void ResetData()
    {
        PlayerPrefs.DeleteKey(LivesKey);
        PlayerPrefs.DeleteKey(PointsKey);
        PlayerPrefs.Save();
    }
}
