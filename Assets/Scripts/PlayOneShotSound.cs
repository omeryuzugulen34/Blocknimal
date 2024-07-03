using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayOneShotSound : MonoBehaviour
{
    GameObject[] soundObj;
    AudioSource sound;
    public AudioClip ButtonSound;
    public AudioClip WinSound;
    public AudioClip RestartSound;
    void Start()
    {
        soundObj = GameObject.FindGameObjectsWithTag("GameSound");
    }
    public void PlayOneSHOT()
    {
        sound = soundObj[0].GetComponent<AudioSource>();
        sound.PlayOneShot(ButtonSound, sound.volume);
    }
    public void PlayOneShotWin()
    {
        sound = soundObj[0].GetComponent<AudioSource>();
        sound.PlayOneShot(WinSound, sound.volume);
    }
    public void PlayOneShotRestart()
    {
        sound = soundObj[0].GetComponent<AudioSource>();
        sound.PlayOneShot(RestartSound, sound.volume);
    }
}