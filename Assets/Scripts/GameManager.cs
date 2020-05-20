using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private GameObject Selesai, Pause, bintang1, bintang2, bintang3;

	public Text Tscore, Tscoreakhir;

	int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Win();
       //Bintang();
       Tscore.text = score.ToString();
       //Tscoreakhir.text = score.ToString(); 
    }

    void Win () {
    	if(Alif.locked && Ba.locked && Ta.locked && Tsa.locked && Jim.locked) {
        	Selesai.SetActive(true);
        }
    }

    void Bintang() {
    	if (score == 0) {
    		bintang1.SetActive(false);
    		bintang2.SetActive(false);
    		bintang3.SetActive(false);
    	} else if (score >= 5 && score< 30) {
    		bintang1.SetActive(true);
    		bintang2.SetActive(false);
    		bintang3.SetActive(false);
    	} else if (score >= 30 && score < 50) {
    		bintang1.SetActive(true);
    		bintang2.SetActive(true);
    		bintang3.SetActive(false);
    	} else {
    		bintang1.SetActive(true);
    		bintang2.SetActive(true);
    		bintang3.SetActive(true);
    	}
    }
    public void Resume() {
    	Pause.SetActive(false);
    }

    public void PausePanel() {
    	Pause.SetActive(true);
    }
    public void MainMenuSelect() {
        SceneManager.LoadScene ("MainMenu");
        Pause.SetActive(false);
    }
    public void StageSelect() {
        SceneManager.LoadScene ("Bermain");
        Pause.SetActive(false);
    }
}
