using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeheTriggerBox : MonoBehaviour
{
    [SerializeField] GameObject heheSaw;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        heheSaw.SetActive(true);
    }
}
