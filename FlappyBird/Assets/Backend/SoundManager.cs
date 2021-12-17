using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{

    public enum Sound
    {
        BirdJump,
        BirdDie,
        Start,
        BirdHit,
        Point,
        CountdownSound,
    }

    private static GameObject gameObject;

    public static void PlaySound(Sound sound)
    {
        if (gameObject == null)
        gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
        if (sound == Sound.Point)
            audioSource.volume = 0.5f;
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.GetInstance().soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError($"Sound {sound} not found!");
        return null;
    }
}
