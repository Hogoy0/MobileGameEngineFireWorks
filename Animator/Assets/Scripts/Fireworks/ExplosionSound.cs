using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _acExplosion;

    AudioSource _asExplosion;

    private void Awake()
    {
        _asExplosion = gameObject.AddComponent<AudioSource>();
    }

    //private void OnParticleTrigger()
    void OnEnable()
    {
        int index = Random.Range(0, _acExplosion.Length);

        _asExplosion.clip = _acExplosion[index];
        _asExplosion.Play();
    }
}
