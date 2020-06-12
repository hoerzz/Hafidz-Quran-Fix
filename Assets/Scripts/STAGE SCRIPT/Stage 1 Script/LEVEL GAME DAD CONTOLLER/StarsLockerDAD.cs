using UnityEngine;
using System.Collections;

public class StarsLockerDAD : MonoBehaviour {

	// [SerializeField]
	// private PuzzleGameSaver puzzleGameSaver;
	
	[SerializeField]
	private GameObject[] level1Stars, level2Stars, level3Stars, level4Stars, level5Stars, level6Stars, level7Stars, level8Stars, level9Stars, level10Stars;
	
	public int[] candyPuzzleLevelStars;
	public int[] transportPuzzleLevelStars;
	public int[] fruitPuzzleLevelStars;

	void Awake() {

	}

	void Start () {
	
	}

	public void ActivateStars(int level, string selectedPuzzle) {
		// GetStars ();

		int stars;

		switch (selectedPuzzle) {
		
		case "Stage 2":

			stars = candyPuzzleLevelStars[level];
			ActivateLevelStars(level, stars);

			break;

		case "Stage 1":
			
			stars = transportPuzzleLevelStars[level];
			ActivateLevelStars(level, stars);
			
			break;
			
		case "Stage 5":
			
			stars = fruitPuzzleLevelStars[level];
			ActivateLevelStars(level, stars);
			
			break;
			
		}

	}

	void ActivateLevelStars(int level, int looper) {
		switch (level) {

		case 0:

			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level1Stars[i].SetActive(true);
				}
			}

			break;

		case 1:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level2Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 2:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level3Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 3:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level4Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 4:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level5Stars[i].SetActive(true);
				}
			}
			
			break;

		case 5:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level6Stars[i].SetActive(true);
				}
			}
			
			break;

		case 6:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level7Stars[i].SetActive(true);
				}
			}
			
			break;

		case 7:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level8Stars[i].SetActive(true);
				}
			}
			
			break;
		
		case 8:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level9Stars[i].SetActive(true);
				}
			}
			
			break;

		case 9:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level10Stars[i].SetActive(true);
				}
			}
			
			break;
		

		}

	}

	public void DeactivateStars() {
		for(int i = 0; i < level1Stars.Length; i++) {
			level1Stars[i].SetActive(false);
			level2Stars[i].SetActive(false);
			level3Stars[i].SetActive(false);
			level4Stars[i].SetActive(false);
			level5Stars[i].SetActive(false);
		}
	}

	// void GetStars() {
	// 	candyPuzzleLevelStars = puzzleGameSaver.candyPuzzleLevelStars;
	// 	transportPuzzleLevelStars = puzzleGameSaver.transportPuzzleLevelStars;
	// 	fruitPuzzleLevelStars = puzzleGameSaver.fruitPuzzleLevelStars;
	// }


}
