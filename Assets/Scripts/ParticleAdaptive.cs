using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAdaptive : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Transform target;
    public float stepByDistance;

    public void Initialise()
    {
        particleSystem = GetComponent<ParticleSystem>();

        target = particleSystem.externalForces.GetInfluence(0).transform;
        float c = Vector2.Distance(particleSystem.transform.position, target.position);
        particleSystem.startLifetime = stepByDistance * c;
    }
}
