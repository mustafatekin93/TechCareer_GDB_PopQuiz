using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clickSound;
    public AudioClip[] jumpSound;
    public AudioClip[] walkSound;
    public AudioClip[] trueSound;
    public AudioClip[] falseSound;
    public AudioClip marioDead;

    public void clickSoundPlay()
    {
        audioSource.PlayOneShot(clickSound[Random.Range(0, clickSound.Length)]);
    }

    public void jumpSoundPlay()
    {
        audioSource.PlayOneShot(jumpSound[Random.Range(0, jumpSound.Length)]);
    }

    public void walkSoundPlay()
    {
        audioSource.PlayOneShot(walkSound[Random.Range(0, walkSound.Length)]);
    }

    public void trueSoundPlay()
    {
        audioSource.PlayOneShot(trueSound[Random.Range(0, trueSound.Length)]);
    }

    public void falseSoundPlay()
    {
        audioSource.PlayOneShot(falseSound[Random.Range(0, falseSound.Length)]);
    }

    public void marioDeadPlay()
    {
        audioSource.PlayOneShot(marioDead);
    }
}
