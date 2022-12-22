using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAdaptive : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public ParticleSystem.MainModule _particleSystemModule;
    public Transform target;
    public float stepByDistance;

    public void Initialise()
    {
        _particleSystemModule = _particleSystem.main;
        target = _particleSystem.externalForces.GetInfluence(0).transform;
        float c = Vector2.Distance(_particleSystem.transform.position, target.position);
        _particleSystemModule.startLifetime = stepByDistance * c;
    }
}
