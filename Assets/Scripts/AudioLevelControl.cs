using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLevelControl : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public void SetMasterLevel(float MVLevel)
    {
        AudioMixer.SetFloat("MasterVolume", MVLevel);
    }
}
