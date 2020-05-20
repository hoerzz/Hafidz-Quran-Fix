using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay1 : MonoBehaviour
{
	public string[] soal, jawaban, hint;

	public Text tsoal, tscore, thint, tscoreakhir;

	public InputField input_jawaban;

	public GameObject feed_benar, feed_salah, pause, selesai, bank_soal, bintang1, bintang2, bintang3;

	int urutan_soal=-1, skor=0;
    // Start is called before the first frame update
    void Start()
    {
        tampil_soal();
    }

    void tampil_soal() {
    	urutan_soal++;
    	tsoal.text = soal [urutan_soal];
    }

    public void jawab() {
    	if (urutan_soal < soal.Length - 1) {
    		if (input_jawaban.text == jawaban[urutan_soal]) {
    			feed_benar.SetActive(false);
    			feed_benar.SetActive(true);
    			feed_salah.SetActive(false);
    			skor+=10;
    		} else {
    			feed_benar.SetActive(false);
    			feed_salah.SetActive(false);
    			feed_salah.SetActive(true);
    			if(skor == 0) {
    					skor = 0;
    				} else {
    					skor-=5;		
    				}
    			
    		}
    		tampil_soal();
    		input_jawaban.text = "";
    	} else {
    		selesai.SetActive(true);
    		bank_soal.SetActive(false);
    		if (input_jawaban.text == jawaban[urutan_soal]) {
    			feed_benar.SetActive(false);
    			feed_benar.SetActive(true);
    			feed_salah.SetActive(false);
    			skor+=10;
    		} else {
    			feed_benar.SetActive(false);
    			feed_salah.SetActive(false);
    			feed_salah.SetActive(true);
    			if(skor == 0) {
    					skor = 0;
    				} else {
    					skor-=5;		
    				}
    			
    		}
    	}
    }
    // Update is called once per frame
    void Update()
    {
        tscore.text = skor.ToString();
        tscoreakhir.text = skor.ToString();
        Bintang();
    }

    void Bintang() {
    	if (skor == 0) {
    		bintang1.SetActive(false);
    		bintang2.SetActive(false);
    		bintang3.SetActive(false);
    	} else if (skor >= 5 && skor < 30) {
    		bintang1.SetActive(true);
    		bintang2.SetActive(false);
    		bintang3.SetActive(false);
    	} else if (skor >= 30 && skor < 50) {
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
    	pause.SetActive(false);
    }

    public void Pause() {
    	pause.SetActive(true);
    }
    public void MainMenuSelect() {
        SceneManager.LoadScene ("MainMenu");
        pause.SetActive(false);
    }
    public void StageSelect() {
        SceneManager.LoadScene ("Bermain");
        pause.SetActive(false);
    }
}
