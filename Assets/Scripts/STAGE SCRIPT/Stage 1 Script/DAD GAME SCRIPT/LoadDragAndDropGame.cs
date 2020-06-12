using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDragAndDropGame : MonoBehaviour
{
    [SerializeField]
	private DragAndDropGameManager dragAndDropGameManager;

	//[SerializeField]
	//private LevelLocker levelLocker; 

	// [SerializeField]
	// private LayoutPuzzleButtons layoutPuzzleButtons;

	[SerializeField]
	private GameObject puzzleLevelSelectPanel;

	[SerializeField]
	private Animator puzzleLevelSelectAnim;

	[SerializeField]
	private GameObject[] puzzleGamePanel;
	
	[SerializeField]
	private Animator[] puzzleGamePanelAnim;

	public GameObject gameSelesai;

	private int puzzleLevel;
	
	private string selectedPuzzle;	

	private List<Animator> anims;

	public void LoadPuzzle() {
		//this.puzzleLevel = level;
		//this.selectedPuzzle = puzzle;

		// layoutPuzzleButtons.LayoutButtons (level, selectedPuzzle);

		switch (puzzleLevel) {

		case 0:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[0], puzzleGamePanelAnim[0]));
			break;
		case 1:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[1], puzzleGamePanelAnim[1]));
			break;
		case 2:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[2], puzzleGamePanelAnim[2]));
			break;
		case 3:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[3], puzzleGamePanelAnim[3]));
			break;
		case 4:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[4], puzzleGamePanelAnim[4]));
			break;
		case 5:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[5], puzzleGamePanelAnim[5]));
			break;
		case 6:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[6], puzzleGamePanelAnim[6]));
			break;
		case 7:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[7], puzzleGamePanelAnim[7]));
			break;
		case 8:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[8], puzzleGamePanelAnim[8]));
			break;
		case 9:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[9], puzzleGamePanelAnim[9]));
			break;
		case 10:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[10], puzzleGamePanelAnim[10]));
			break;
		// case 11:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[11], puzzleGamePanelAnim[11]));
		// 	break;
		// case 12:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[12], puzzleGamePanelAnim[12]));
		// 	break;
		// case 13:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[13], puzzleGamePanelAnim[13]));
		// 	break;
		// case 14:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[14], puzzleGamePanelAnim[14]));
		// 	break;
		// case 15:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[15], puzzleGamePanelAnim[15]));
		// 	break;
		// case 16:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[16], puzzleGamePanelAnim[16]));
		// 	break;
		// case 17:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[17], puzzleGamePanelAnim[17]));
		// 	break;
		// case 18:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[18], puzzleGamePanelAnim[18]));
		// 	break;
		// case 19:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[19], puzzleGamePanelAnim[19]));
		// 	break;
		// case 20:
		// 	StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel[20], puzzleGamePanelAnim[20]));
		// 	break;

		}
	


	}

	public void BackToPuzzleLevelSelectMenu() {
		anims = dragAndDropGameManager.ResetGameplay ();
		gameSelesai.SetActive(false);

		//levelLocker.CheckWhichLevelsAreUnlocked (selectedPuzzle);

		switch (puzzleLevel) {
		case 0:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel[0], puzzleGamePanelAnim[0]));
			break;
		case 1:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel[1], puzzleGamePanelAnim[1]));
			break;
		case 2:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel[2], puzzleGamePanelAnim[2]));
			break;
		case 3:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel[3], puzzleGamePanelAnim[3]));
			break;
		case 4:
			StartCoroutine (LoadPuzzleLevelSelectMenu (puzzleGamePanel[4], puzzleGamePanelAnim[4]));
			break;
		case 5:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[5], puzzleGamePanelAnim[5]));
			break;
		case 6:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[6], puzzleGamePanelAnim[6]));
			break;
		case 7:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[7], puzzleGamePanelAnim[7]));
			break;
		case 8:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[8], puzzleGamePanelAnim[8]));
			break;
		case 9:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[9], puzzleGamePanelAnim[9]));
			break;
		case 10:
			StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[10], puzzleGamePanelAnim[10]));
			break;
		// case 11:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[11], puzzleGamePanelAnim[11]));
		// 	break;
		// case 12:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[12], puzzleGamePanelAnim[12]));
		// 	break;
		// case 13:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[13], puzzleGamePanelAnim[13]));
		// 	break;
		// case 14:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[14], puzzleGamePanelAnim[14]));
		// 	break;
		// case 15:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[15], puzzleGamePanelAnim[15]));
		// 	break;
		// case 16:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[16], puzzleGamePanelAnim[16]));
		// 	break;
		// case 17:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[17], puzzleGamePanelAnim[17]));
		// 	break;
		// case 18:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[18], puzzleGamePanelAnim[18]));
		// 	break;
		// case 19:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[19], puzzleGamePanelAnim[19]));
		// 	break;
		// case 20:
		// 	StartCoroutine(LoadPuzzleLevelSelectMenu (puzzleGamePanel[20], puzzleGamePanelAnim[20]));
		// 	break;
		}

	}

	IEnumerator LoadPuzzleLevelSelectMenu(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim) {
		puzzleLevelSelectPanel.SetActive (true);
		puzzleLevelSelectAnim.Play ("SlideIn");
		puzzleGamePanelAnim.Play ("SlideOut");

		yield return new WaitForSeconds (-0.3f);

		//foreach (Animator anim in anims) {
		//	anim.Play("Idle");
		//}

		yield return new WaitForSeconds (.5f);

		puzzleGamePanel.SetActive (false);
	}
	
	IEnumerator LoadPuzzleGamePanel(GameObject puzzleGamePanel, Animator puzzleGamePanelAnim) {
		puzzleGamePanel.SetActive (true);
		puzzleGamePanelAnim.Play ("SlideIn");
		puzzleLevelSelectAnim.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		puzzleLevelSelectPanel.SetActive (false);
	}

}
