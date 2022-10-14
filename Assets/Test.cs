using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private Transform target;
    public float stepByDistance;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        target = particleSystem.externalForces.GetInfluence(0).transform;
        float c = Vector2.Distance(particleSystem.transform.position, target.position);
        particleSystem.startLifetime = stepByDistance * c;
    }
}
