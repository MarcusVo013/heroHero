using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    [Header("-------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip fireball;
    public AudioClip explotion;
    public AudioClip swordSound;
    public AudioClip enemyDead;
    public AudioClip spike;
    public AudioClip heal;
    public AudioClip groundGrass;
    public AudioClip groundCave;
    public AudioClip hitenemy;
    public AudioClip playerHit;
    public AudioClip push;
    public AudioClip healUse;
    public AudioClip arrowfire;
    public AudioClip arrowhit;
    public AudioClip ampush;
    public AudioClip BossHit;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
