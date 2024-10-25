using UnityEngine;

public class GameData : MonoBehaviour
{
    private const string LivesKey = "Lives";
    private const string PointsKey = "Points";

    // M�todo para guardar las vidas y los puntos en PlayerPrefs
    public static void SaveData(int lives, int points)
    {
        PlayerPrefs.SetInt(LivesKey, lives);
        PlayerPrefs.SetInt(PointsKey, points);
        PlayerPrefs.Save(); // Guarda los datos en disco
    }

    // M�todo para cargar las vidas guardadas; si no existe el dato, devuelve un valor predeterminado
    public static int LoadLives(int defaultLives = 3)
    {
        return PlayerPrefs.GetInt(LivesKey, defaultLives);
    }

    // M�todo para cargar los puntos guardados; si no existe el dato, devuelve 0
    public static int LoadPoints(int defaultPoints = 0)
    {
        return PlayerPrefs.GetInt(PointsKey, defaultPoints);
    }

    // M�todo para borrar los datos guardados (opcional, �til para "Nueva Partida")
    public static void ResetData()
    {
        PlayerPrefs.DeleteKey(LivesKey);
        PlayerPrefs.DeleteKey(PointsKey);
        PlayerPrefs.Save();
    }
}
