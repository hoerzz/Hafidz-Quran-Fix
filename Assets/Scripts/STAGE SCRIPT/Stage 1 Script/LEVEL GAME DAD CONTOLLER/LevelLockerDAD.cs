using UnityEngine;
using System.Collections;

public class LevelLockerDAD : MonoBehaviour {

	// [SerializeField]
	// private PuzzleGameSaver puzzleGameSaver;

	[SerializeField]
	private StarsLockerDAD starsLockerDAD;
	
	[SerializeField]
	private GameObject[] levelStarsHolders;
	
	[SerializeField]
	private GameObject[] levelsPadlocks;
	
	private bool[] candyPuzzleLevels;
	private bool[] transportPuzzleLevels;
	private bool[] fruitPuzzleLevels;

	void Awake() {
		DeactivatePadlocksAndStarHolders ();
	}
	
	void Start () {
		// GetLevels ();
	}

	public void CheckWhichLevelsAreUnlocked(string selectedPuzzle) {

		DeactivatePadlocksAndStarHolders ();
		// GetLevels ();

		switch (selectedPuzzle) {

		case "Stage 2":

			for(int i = 0; i < candyPuzzleLevels.Length; i++) {
				if(candyPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLockerDAD.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}

			break;

		case "Stage 1":
			
			for(int i = 0; i < transportPuzzleLevels.Length; i++) {
				if(transportPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLockerDAD.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;
			
		case "Stage 5":
			
			for(int i = 0; i < fruitPuzzleLevels.Length; i++) {
				if(fruitPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLockerDAD.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;

		
		}

	}

	void DeactivatePadlocksAndStarHolders() {
		for(int i = 0; i < levelStarsHolders.Length; i++) {
			levelStarsHolders[i].SetActive(false);
			levelsPadlocks[i].SetActive(false);
		}
	}

	// void GetLevels() {
	// 	candyPuzzleLevels = puzzleGameSaver.candyPuzzleLevels;
	// 	transportPuzzleLevels = puzzleGameSaver.transportPuzzleLevels;
	// 	fruitPuzzleLevels = puzzleGameSaver.fruitPuzzleLevels;
	// }

	public bool[] GetDragDropLevels(string selectedPuzzle) {

		switch (selectedPuzzle) {

		case "Stage 2":
			return this.candyPuzzleLevels;
			break;

		case "Stage 1":
			return this.transportPuzzleLevels;
			break;

		case "Stage 5":
			return this.fruitPuzzleLevels;
			break;

		default:
			return null;
			break;

		}

	}

}