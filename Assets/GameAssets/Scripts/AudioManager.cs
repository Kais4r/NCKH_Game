using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    Slider masterSlider;

    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider effectSlider;

    bool isEffectMuted = false;
    bool isMusicMuted = false;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    Debug.LogError("No AudioManager found in scene. Creating instance.");
                    instance = new AudioManager();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            DestroyImmediate(gameObject); // Destroy duplicate if it exists
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        UpdateVolumeSlider();
    }

    void UpdateVolumeSlider()
    {
        float masterVolume;
        bool masterResult = audioMixer.GetFloat("MasterVolume", out masterVolume);

        float musicVolume;
        bool musicResult = audioMixer.GetFloat("MusicVolume", out musicVolume);

        float effectVolume;
        bool effectResult = audioMixer.GetFloat("EffectVolume", out effectVolume);

        if(masterResult && masterSlider != null)
        {
            masterSlider.value = masterVolume;
        }

        if (musicResult && musicSlider != null)
        {
            musicSlider.value = musicVolume;
        }

        if (effectResult && effectSlider != null)
        {
            effectSlider.value = effectVolume;
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        if(isMusicMuted == false)
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
    }

    public void SetEffectVolume(float volume)
    {
        if(isEffectMuted == false)
        {
            audioMixer.SetFloat("EffectVolume", volume);
        }
    }

    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void ToggleMusic(bool value)
    {
        if(value)
        {
            audioMixer.SetFloat("MusicVolume", -80);
            isMusicMuted = true;
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", 0);
            isMusicMuted = false;
        }
    }

    public void ToggleEffect(bool value)
    {
        if (value)
        {
            audioMixer.SetFloat("EffectVolume", -80);
            isEffectMuted = true;
        }
        else
        {
            audioMixer.SetFloat("EffectVolume", 0);
            isEffectMuted = false;
        }
    }
}
