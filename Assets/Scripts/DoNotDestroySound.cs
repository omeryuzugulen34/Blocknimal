using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroySound : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameSound");
        if(musicObj.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
  
    }
}
