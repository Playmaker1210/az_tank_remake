using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMainVolume(float mainVolume) {
        mixer.SetFloat("mainVolume", mainVolume);
    }
    public void SetMusicVolume(float musicVolume) {
        mixer.SetFloat("musicVolume", musicVolume);
    }
    public void SetSfxVolume(float sfxVolume) {
        mixer.SetFloat("sfxVolume", sfxVolume);
    }
}
