using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour
{
    public GameObject openpng;
    public GameObject closepng;
    void Start()
    {
        OpenEye();
    }
    void OpenEye()
    {
        openpng.SetActive(true);
        closepng.SetActive(false);
        Invoke("CloseEye", Random.RandomRange(4,20));
    }
    void CloseEye()
    {
        closepng.SetActive(true);
        openpng.SetActive(false);
        Invoke("OpenEye", 0.2f);
    }
    
}
