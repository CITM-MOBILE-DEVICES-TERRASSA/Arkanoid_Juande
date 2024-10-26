using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particlePrefab;          // Prefab de partículas para la muerte del ladrillo
    public GameObject hitParticlePrefab;       // Prefab de partículas para el golpe al ladrillo
    public float particleLifetime = 2f;        // Tiempo en segundos antes de que las partículas se destruyan

    public void CreateBrickDeathParticle(Vector3 position)
    {
        GameObject particle = Instantiate(particlePrefab, position, Quaternion.identity);
        Destroy(particle, particleLifetime); // Destruye la instancia después de 'particleLifetime' segundos
    }

    public void CreateHitParticle(Vector3 position)
    {
        GameObject hitParticle = Instantiate(hitParticlePrefab, position, Quaternion.identity);
        Destroy(hitParticle, particleLifetime); // Destruye la instancia después de 'particleLifetime' segundos
    }
}
