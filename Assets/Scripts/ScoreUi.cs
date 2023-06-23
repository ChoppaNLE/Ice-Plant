using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUi : MonoBehaviour
{

    public RowUi rowUi;
    public ScoreManager scoreManager; 

    // Start is called before the first frame update
    void Start()
    {
        var scores = scoreManager.sd.scores.ToArray();
        for (int i = 0; i < scores.Length; i ++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = ( i + 1).ToString();
            row.name.text = scores[i].name;
            row.scores.text = scores[i].score.ToString();
        }
    }

    
}
