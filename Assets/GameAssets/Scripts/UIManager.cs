using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GaneObjectSwitchButton(GameObject uiObject)
    {
        if(uiObject.gameObject.activeSelf == false)
        {
            uiObject.gameObject.SetActive(true);
        }
        else
        {
            uiObject.gameObject.SetActive(false);
        }
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("LevelSelection");
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

    public void OnBackToMenuButton()
    {
        AudioManager.Instance.PlaySound(audioSource, clickSound);
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitButton()
    {
        AudioManager.Instance.PlaySound(audioSource, clickSound);
        Application.Quit();
    }
}
