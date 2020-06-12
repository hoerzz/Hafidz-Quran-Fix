using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedBackPuzzle : MonoBehaviour
{
    [SerializeField]
    private DragAndDropGameManager dragAndDropGameManager;

    // int level;
    // private string selectedPuzzle;

    public bool selesai = false;

    public GameObject puzzle;


    // public Text tscore, tscoreakhir;
    // int skor = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void cek()
    {
        for (int i = 0; i < 4; i++)
        {
            if (transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel)
            {
                selesai = true;
            }
            else
            {
                selesai = false;
                i = 4;
            }
        }
        if (selesai)
        {
            // menang();
            puzzle.SetActive(false);
            dragAndDropGameManager.ResetGameplay();
            dragAndDropGameManager.CheckHowManyGuesses();

        }


    }
    // Update is called once per frame
    void Update()
    {
        if (!selesai)
        {
            cek();
        }
    }

    // void menang (){
    //     // if (skor == 0){
    //     //         {
    //     //             skor = 0;
    //     //         }
    //     //         else
    //     //         {
    //     //             skor -= 5;
    //     //         }
    //     // }

    //     if (skor >= 5 && skor < 30) {

    //         gameFinished.ShowGameFinishedPanel (1);
    //         puzzleGameSaver.Save(level, selectedPuzzle, 2);
    //     } else if (skor >= 30 && skor < 50) {

    //         gameFinished.ShowGameFinishedPanel (2);
    //         puzzleGameSaver.Save(level, selectedPuzzle, 3);
    //     } else {

    //         gameFinished.ShowGameFinishedPanel (3);
    //         puzzleGameSaver.Save(level, selectedPuzzle, 1);

    //     }

    // }
}
