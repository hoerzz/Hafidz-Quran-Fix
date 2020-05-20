using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public static int score = 0;
    Text skor;
    // Start is called before the first frame update
    void Start()
    {
        skor = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        skor.text = score.ToString();
    }
}
