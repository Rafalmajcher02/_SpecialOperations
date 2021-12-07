using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown res;

    public void loadScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        
        Application.Quit();
#endif
    }
    public void resume()
    {
        Time.timeScale = 1.0f;
    }
    public void loadMM()
    {
        SceneManager.LoadScene(0);
        
    }
    public void Restart()
    {
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
        Time.timeScale = 1.0f;
    }
    public void ResChane()
    {
        if (res.options[res.value].text == "16:9")
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (res.options[res.value].text == "16:10")
        {
            Screen.SetResolution(1280, 800, true);
        }
        if (res.options[res.value].text == "3:2")
        {
            Screen.SetResolution(1024, 768, true);
        }
        if (res.options[res.value].text == "4:3")
        {
            Screen.SetResolution(960, 720, true);
        }
        if (res.options[res.value].text == "5:4")
        {
            Screen.SetResolution(1280, 1024, true);
        }
    }

}
