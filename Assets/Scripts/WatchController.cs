using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchController : MonoBehaviour
{
    private float currentTime = 0f;
    private TextMesh textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        textMesh.text = timeText;
        
    }
}
