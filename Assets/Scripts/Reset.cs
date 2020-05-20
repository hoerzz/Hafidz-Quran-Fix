using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject parent_puzzle, senyum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()
    {
        for (int i = 0; i < 4; i++)
        {
            parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            parent_puzzle.transform.GetChild(i).localScale = parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
        }
        ScoreManagement.score = 0;
        senyum.SetActive(false);
        parent_puzzle.GetComponent<FeedBak>().selesai = false;
    }
}
