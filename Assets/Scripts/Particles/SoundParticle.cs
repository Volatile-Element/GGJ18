using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SoundParticle : MonoBehaviour
{
    private static Vector3 BaseSize = new Vector3(0.075f, 0.5f, 0.1f);

    public static ParticleSystem Create(Vector3 location, float radius, bool loop)
    {
        if (ParticleManager.Instance.SoundParticlePrefab == null)
        {
            Debug.Log("Prefab is null.");
            return null;
        }

        var newGameObject = Instantiate(ParticleManager.Instance.SoundParticlePrefab, location, Quaternion.identity);
        newGameObject.name = $"Sound Particle - Radius: {radius}";

        var particleSystem = newGameObject.GetComponent<ParticleSystem>();
        var shape = particleSystem.shape;
        shape.radius = radius;

        var main = particleSystem.main;
        main.loop = loop;

        main.startSizeX = new MinMaxCurve(BaseSize.x * radius);
        main.startSizeY = new MinMaxCurve(BaseSize.y * radius);
        main.startSizeZ = new MinMaxCurve(BaseSize.z * radius);

        return particleSystem;
    }
}