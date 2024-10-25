using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab de partículas

    public void CreateBrickDeathParticle(Vector3 position)
    {

        Instantiate(particlePrefab, position, Quaternion.identity);
    }
}
