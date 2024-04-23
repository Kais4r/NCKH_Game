using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel, aboutPanel;

    [SerializeField]
    private AudioClip clickSound;

    [SerializeField]
    private AudioSource audioSource;


    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnToggleSettingsPanel()
    {
        AudioManager.Instance.PlaySound(audioSource, clickSound);
        if(settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }
    }

    public void OnToggleAboutPanel()
    {
        AudioManager.Instance.PlaySound(audioSource, clickSound);
        if (aboutPanel != null)
        {
            aboutPanel.SetActive(!aboutPanel.activeSelf);
        }
    }

    public void OnQuitButton()
    {
        AudioManager.Instance.PlaySound(audioSource, clickSound);
        Application.Quit();
    }
}
