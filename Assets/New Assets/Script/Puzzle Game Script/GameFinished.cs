using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	[SerializeField]
	private GameObject gameFinishedPanel;

	[SerializeField]
	private GameObject starHolder1, starHolder2, starHolder3;
	
	[SerializeField]
	private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim, textAnimSkor ;

	public void ShowGameFinishedPanel(int stars) {
		StartCoroutine (ShowPanel (stars));
	}
	
	public void HideGameFinishedPanel() {
		if (gameFinishedPanel.activeInHierarchy) {
			StartCoroutine(HidePanel());
		}
	}

	IEnumerator ShowPanel(int stars) {
		gameFinishedPanel.SetActive (true);
		starHolder1.SetActive (true);
		starHolder2.SetActive (true);
		starHolder3.SetActive (true);
		textAnimSkor.Play ("FadeIn");

		gameFinishedAnim.Play ("FadeIn");

		yield return new WaitForSeconds(1.7f);

		switch (stars) {
		case 1:
			
			star1Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.1f);
			
			textAnim.Play ("FadeIn");
			
			break;
			
		case 2:
			
			star1Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.25f);
			
			star2Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.1f);
			
			textAnim.Play ("FadeIn");
			
			break;
			
		case 3:
			
			star1Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.25f);
			
			star2Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.25f);
			
			star3Anim.Play ("FadeIn");
			
			yield return new WaitForSeconds(.1f);
			
			textAnim.Play ("FadeIn");
			
			break;
			
		}

	}

	IEnumerator HidePanel() {

		gameFinishedAnim.Play ("FadeOut");
		starHolder1.SetActive (false);
		starHolder2.SetActive (false);
		starHolder3.SetActive (false);

		star1Anim.Play ("FadeOut");
		star2Anim.Play ("FadeOut");
		star3Anim.Play ("FadeOut");
		textAnim.Play ("FadeOut");
		textAnimSkor.Play ("FadeOut");

		yield return new WaitForSeconds(1.5f);

		gameFinishedPanel.SetActive (false);
		
		

	}


} // GameFinished

















































