using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TempSound : MonoBehaviour
{
    public void Setup(AudioClip clip)
    {
        AudioSource source = GetComponent<AudioSource>();

        float value = 0.5f;

        if (PlayerPrefs.HasKey("Sounds"))
            value = PlayerPrefs.GetFloat("Sounds");
        else
            PlayerPrefs.SetFloat("Sounds", value);

        source.volume = value;

        source.loop = false;
        source.clip = clip;

        source.Play();
    }
}
