using UnityEngine;

public class GameData : MonoBehaviour
{
    private const string LivesKey = "Lives";
    private const string PointsKey = "Points";
    private const string HighScoreKey = "HighScore";
    private const string CurrentSceneIndexKey = "CurrentSceneIndex"; // Clave para el �ndice de la escena actual

    // M�todo para guardar las vidas, puntos y el �ndice de la escena actual
    public static void SaveData(int lives, int points, int currentSceneIndex)
    {
        PlayerPrefs.SetInt(LivesKey, lives);
        PlayerPrefs.SetInt(PointsKey, points);
        PlayerPrefs.SetInt(CurrentSceneIndexKey, currentSceneIndex); // Guarda el �ndice de la escena actual
        PlayerPrefs.Save(); // Guarda los datos en disco
    }

    // M�todo para cargar el �ndice de la escena guardada
    public static int LoadCurrentSceneIndex()
    {
        return PlayerPrefs.GetInt(CurrentSceneIndexKey, 0); // Devuelve 0 si no existe
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

    // M�todo para cargar la puntuaci�n m�xima; si no existe, devuelve 0
    public static int LoadHighScore(int defaultHighScore = 0)
    {
        return PlayerPrefs.GetInt(HighScoreKey, defaultHighScore);
    }

    // M�todo para guardar la puntuaci�n m�xima
    public static void SaveHighScore(int highScore)
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save(); // Guarda los datos en disco
    }

    // M�todo para borrar los datos guardados (opcional, �til para "Nueva Partida")
    public static void ResetData()
    {
        PlayerPrefs.DeleteKey(LivesKey);
        PlayerPrefs.DeleteKey(PointsKey);
        PlayerPrefs.DeleteKey(CurrentSceneIndexKey); // Borrar el �ndice de la escena
        PlayerPrefs.Save();
    }
}
