using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;

    private string _fpsFormat = "FPS : {0}";

    private void Update()
    {
        _text.text = string.Format(_fpsFormat, (int)(1f / Time.deltaTime));
    }
}