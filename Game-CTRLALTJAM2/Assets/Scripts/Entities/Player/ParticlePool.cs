using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ParticlePool : MonoBehaviour
{
    private ObjectPool<ParticlePool> _pool;
    private ParticleSystem _particleSystem;



    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        var main = _particleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;

        Debug.LogWarning("PARTICLE POOL START");
    }



    private void OnParticleSystemStopped()
    {
        _pool.Release(this);
    }

    public void SetPool(ObjectPool<ParticlePool> pool)
    {
        _pool = pool;
    }
}
