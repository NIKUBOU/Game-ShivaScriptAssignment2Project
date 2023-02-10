using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        tmproText.text = GameManager.Instance.Lives.ToString();
    }
}
