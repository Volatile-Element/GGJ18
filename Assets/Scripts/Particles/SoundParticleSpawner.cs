using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParticleSpawner : MonoBehaviour
{
    public Vector3 Offset = Vector3.zero;

    public float Radius = 1f;

    public ParticleSystem particles;

    public void StopParticles()
    {
        if (particles != null)
        {
            particles.Stop();
        }
    }

    public void StartParticles()
    {
        if (particles != null)
        {
            particles.Play();
        }
        else
        {
            particles = SoundParticle.Create(transform.position + Offset, Radius, true);
        }
    }

    private void Start()
    {
        particles = SoundParticle.Create(transform.position + Offset, Radius, true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Offset, 0.2f);
    }
}