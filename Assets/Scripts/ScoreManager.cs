using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreData sd;

    // Start is called before the first frame update
    void Awake()
    {
        sd = new ScoreData();
    }


    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }
}
