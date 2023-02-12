using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeheTriggerBox : MonoBehaviour
{
    [SerializeField] GameObject heheSaw;

    private bool heheWorked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!heheWorked)
        {
            heheSaw.SetActive(true);
            heheWorked = true;
        }
        else
        {
            heheSaw.SetActive(false);
        }
    }


}
