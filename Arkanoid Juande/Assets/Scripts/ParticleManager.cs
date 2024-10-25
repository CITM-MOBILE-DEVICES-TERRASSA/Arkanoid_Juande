using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particlePrefab; // Prefab de part�culas

    public void CreateBrickDeathParticle(Vector3 position)
    {

        Instantiate(particlePrefab, position, Quaternion.identity);
    }
}
