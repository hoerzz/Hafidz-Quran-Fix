using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject parent;
    public GameObject[] child_puzzle, win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int urutan = 0;

    void aktif(int a)
    {
        urutan += a;
        if (urutan < 0)
        {
            urutan = parent.transform.childCount - 1;
        }
        else if(urutan > parent.transform.childCount - 1)
        {
            urutan = 0;
        }
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
            
        }
        
        parent.transform.GetChild(urutan).gameObject.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            child_puzzle[0].transform.GetChild(i).position = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            child_puzzle[0].transform.GetChild(i).localScale = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
            child_puzzle[1].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            child_puzzle[1].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            child_puzzle[1].transform.GetChild(i).position = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            child_puzzle[1].transform.GetChild(i).localScale = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
            child_puzzle[2].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            child_puzzle[2].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            child_puzzle[2].transform.GetChild(i).position = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            child_puzzle[2].transform.GetChild(i).localScale = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
            child_puzzle[3].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            child_puzzle[3].transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            child_puzzle[3].transform.GetChild(i).position = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            child_puzzle[3].transform.GetChild(i).localScale = child_puzzle[0].transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
        }
        win[0].SetActive(false);
        child_puzzle[0].GetComponent<FeedBak>().selesai = false;
        win[1].SetActive(false);
        child_puzzle[1].GetComponent<FeedBak>().selesai = false;
        win[2].SetActive(false);
        child_puzzle[2].GetComponent<FeedBak>().selesai = false;
        win[3].SetActive(false);
        child_puzzle[3].GetComponent<FeedBak>().selesai = false;
    }

    private void OnMouseUp()
    {
        if (gameObject.name == "Next")
        {
            aktif(1);
            ScoreManagement.score =0;
        }
        else
        {
            aktif(-1);
            ScoreManagement.score =0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
