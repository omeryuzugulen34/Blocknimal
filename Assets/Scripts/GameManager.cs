using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<bool> IsMovings;

    public List<GameObject> Blocks;

    public bool Move;

    public GameObject particle;

    public GameObject NextLevelPanel;

    private void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Doggy").Length; i++)
        {
            Blocks.Add(GameObject.FindGameObjectsWithTag("Doggy")[i]);
            IsMovings.Add(false);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Kitty").Length; i++)
        {
            Blocks.Add(GameObject.FindGameObjectsWithTag("Kitty")[i]);
            IsMovings.Add(false);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Coala").Length; i++)
        {
            Blocks.Add(GameObject.FindGameObjectsWithTag("Coala")[i]);
            IsMovings.Add(false);
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Penguin").Length; i++)
        {
            Blocks.Add(GameObject.FindGameObjectsWithTag("Penguin")[i]);
            IsMovings.Add(false);
        }

       
    }
    bool AllFalse;
    private void Update()
    {
        for (int i = 0; i < Blocks.Count; i++)
        {
            if (Blocks[i] != null)
            {
                IsMovings[i] = Blocks[i].gameObject.GetComponent<Block>().RealMoving;
            }
            else
            {
                IsMovings[i] = false;
            }
        }


        bool AllFalse = false;
        foreach (bool b in IsMovings)
        {
            if (b)
            {
                AllFalse = true;
                break;
            }
           
        }

        Move = AllFalse;

        if (Blocks.Count == 0)
        {
            Invoke("NextLevelPanelVoid", 0.3f);
        }

    }

    private void NextLevelPanelVoid()
    {
        NextLevelPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Levels()
    {
        SceneManager.LoadScene(21);
    }
    public void NextLevel()
    {
        PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}