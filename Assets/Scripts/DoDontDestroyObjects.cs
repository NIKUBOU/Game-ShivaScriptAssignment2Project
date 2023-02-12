using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDontDestroyObjects : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


}
