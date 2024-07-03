using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCheck : MonoBehaviour
{
    public bool check;
    public GameObject collObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        check = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        check = true;
        collObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        check = false;
    }
}
