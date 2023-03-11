using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundSFX(SFXType type){
        float _pitch = Random.Range(0.9f,1.1f);
        audioSource.pitch = _pitch;
        audioSource.PlayOneShot(clips[(int)type]);
    }
}

public enum SFXType{
    win,
    lose
}
