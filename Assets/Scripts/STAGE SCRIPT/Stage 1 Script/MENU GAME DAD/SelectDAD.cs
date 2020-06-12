using UnityEngine;
using System.Collections;

public class SelectDAD : MonoBehaviour {

	[SerializeField]
	private DragAndDropGameManager dragAndDropGameManager;

	[SerializeField]
	private SelectLevelDAD selectLevelDAD;

	[SerializeField]
	private LevelLocker levelLocker;

	[SerializeField]
	private StarsLocker starsLocker;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

	private string selectedPuzzle;

	public void SelectedPuzzle() {

		starsLocker.DeactivateStars ();

		selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		dragAndDropGameManager.SetSelectedPuzzle (selectedPuzzle);

		levelLocker.CheckWhichLevelsAreUnlocked (selectedPuzzle);

		selectLevelDAD.SetSelectedPuzzle (selectedPuzzle);

		StartCoroutine (ShowPuzzleLevelSelectMenu ());

	}

	IEnumerator ShowPuzzleLevelSelectMenu() {
		puzzleLevelSelectPanel.SetActive (true);
		selectPuzzleMenuAnim.Play ("SlideOut");
		puzzleLevelSelectAnim.Play ("SlideIn");
		yield return new WaitForSeconds (1f);
		selectPuzzleMenuPanel.SetActive (false);
	}


} // SelectDAD

















































