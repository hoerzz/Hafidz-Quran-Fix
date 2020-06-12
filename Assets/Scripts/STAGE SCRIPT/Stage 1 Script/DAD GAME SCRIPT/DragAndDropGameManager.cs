using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropGameManager : MonoBehaviour
{
    public GameObject parent_puzzle;
    private List<Animator> puzzleButtonsAnimators; 
    public GameObject detector;
    public Vector3 pos_awal, scale_awal;
    public bool on_pos = false, on_tempel = false;
    // public Text tscore, tscoreakhir;
    // int skor = 0;
    public bool selesai = false;
    public GameObject puzzle;

    int level;
	private string selectedPuzzle;

    // [SerializeField]
	// private PuzzleGameSaver puzzleGameSaver;

	[SerializeField]
	private GameFinished gameFinished;

	public int levelIndex;
	private int countTryGuess;


    public List<Animator> ResetGameplay() {
        for (int i = 0; i < 4; i++)
        {
            parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().pos_awal;
            parent_puzzle.transform.GetChild(i).localScale = parent_puzzle.transform.GetChild(i).GetComponent<Gamplay6Drag>().scale_awal;
        }
        selesai = false;
        countTryGuess = 0;
      return puzzleButtonsAnimators;
	}

    public void CheckHowManyGuesses() {
		int howManyGuesses = 0;

		switch(level) {
			
		case 0:
			howManyGuesses = 5;
			break;
			
		case 1:
			howManyGuesses = 10;
			break;
			
		case 2:
			howManyGuesses = 15;
			break;
			
		case 3:
			howManyGuesses = 20;
			break;
			
		case 4:
			howManyGuesses = 25;
			break;
			
		}

		if (countTryGuess < howManyGuesses) {
			gameFinished.ShowGameFinishedPanel (3);

			PlayerPrefs.SetInt("Lv" + levelIndex, 3);

			// puzzleGameSaver.Save(level, selectedPuzzle, 3);

		} else if (countTryGuess < (howManyGuesses + 5)) {
			gameFinished.ShowGameFinishedPanel (2);

			PlayerPrefs.SetInt("Lv" + levelIndex, 2);

			// puzzleGameSaver.Save(level, selectedPuzzle, 2);

		} else {
			gameFinished.ShowGameFinishedPanel (1);
			PlayerPrefs.SetInt("Lv" + levelIndex, 1);
			// puzzleGameSaver.Save(level, selectedPuzzle, 1);
		}

	}

    public void SetLevel(int level) {
		this.level = level;
	}

    public void SetSelectedPuzzle(string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}
}
