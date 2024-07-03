using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel", 1));
    }
    public void Levels()
    {
        SceneManager.LoadScene(21);
    }
}
