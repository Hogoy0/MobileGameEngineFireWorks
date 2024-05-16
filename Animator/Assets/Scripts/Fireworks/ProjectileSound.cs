using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _acFire;

    [SerializeField]
    Transform _tAudioRoot;

    ParticleSystem _particleSystem;
    ParticleSystem.Particle[] _particles;

    void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }

    private void OnParticleTrigger()
    {
        int index = Random.Range(0, _acFire.Length);
        AudioClip clipToPlay = _acFire[index];

        _particleSystem.GetParticles(_particles);

        if (_particleSystem.GetParticles(_particles) > 0)
        {
            Vector3 particlePosition = _particles[0].position;
            StartCoroutine(Play3DSound(particlePosition, clipToPlay, clipToPlay.length));
        }
    }

    IEnumerator Play3DSound(Vector3 position, AudioClip clip, float time)
    {
        GameObject soundObject = new GameObject("ProjectileSound");
        soundObject.transform.SetParent(_tAudioRoot);
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();

        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.spatialBlend = 1;
        audioSource.minDistance = 1;
        audioSource.maxDistance = 250;

        audioSource.clip = clip;
        soundObject.transform.position = position;
        audioSource.Play();

        yield return new WaitForSeconds(time);

        Destroy(soundObject);
    }
}
