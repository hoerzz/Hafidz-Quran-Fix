using UnityEngine;
using System.Collections;

public class SelectLevelDAD : MonoBehaviour {

	[SerializeField]
	private DragAndDropGameManager dragAndDropGameManager;

	[SerializeField]
	private LevelLocker levelLocker; 

	//[SerializeField]
	//private LoadDragAndDropGame loadDragAndDropGame;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;
	
	[SerializeField]
	private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;
	
	private string selectedPuzzle;

	private bool[] puzzle;

	public void BackToPuzzleSelectMenu() {
		StartCoroutine (ShowPuzzleSelectMenu ());
	}

	public void SelectPuzzleLevel() {

		int level = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
		puzzle = levelLocker.GetPuzzleLevels (selectedPuzzle);

		if (puzzle [level]) {
			dragAndDropGameManager.SetLevel (level);
			//loadDragAndDropGame.LoadPuzzle (level, selectedPuzzle);
		}

	}

	IEnumerator ShowPuzzleSelectMenu() {
		selectPuzzleMenuPanel.SetActive (true);
		selectPuzzleMenuAnim.Play ("SlideIn");
		puzzleLevelSelectAnim.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		puzzleLevelSelectPanel.SetActive (false);
	}

	public void SetSelectedPuzzle(string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}

}