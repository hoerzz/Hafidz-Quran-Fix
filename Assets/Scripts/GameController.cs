using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
   
   [SerializeField]
   private Sprite bgImage;

   private Sprite[] puzzles;

   private List<Sprite> gamePuzzles = new List<Sprite>();

   private List<Button> btns = new List<Button>();

   private bool firstGuess, secondGuess;

   private int countGuesses;
   private int countCorrectGuesses;
   private int gameGuesses;

   private int firstGuessIndex, secondGuessIndex;

   private string firstGuessPuzzle, secondGuessPuzzle;
   
   public Text tscore, tscoreakhir;

   public GameObject pause, selesai, bintang1, bintang2, bintang3;

   int urutan_soal=-1, skor=0;

   void Awake () {
   		puzzles = Resources.LoadAll<Sprite> ("Sprites/Hijaiyah");
   }
   void Start() {
   		GetButtons();
   		AddListeners();
   		AddGamePuzzles();
   		Shuffle (gamePuzzles);
   		gameGuesses = gamePuzzles.Count / 2;
   }
   void GetButtons() {
   		GameObject[] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton");

   		for (int i = 0; i < objects.Length; i++) {
   			btns.Add(objects[i].GetComponent<Button>());
   			btns[i].image.sprite = bgImage;
   		}

   }

   void AddGamePuzzles() {
   		int looper = btns.Count;
   		int index = 0;

   		for (int i = 0; i < looper; i++) {
   			if (index == looper / 2) {
   				index = 0;
   			}
   			gamePuzzles.Add(puzzles[index]);

   			index++;
   		}
   }

   void AddListeners() {
   		foreach (Button btn in btns) {
   			btn.onClick.AddListener(() => PickAPuzzle());
   		}
   }

   public void PickAPuzzle() {
   	// string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		// Debug.Log("You're Click " + name);
		if (!firstGuess) {

			firstGuess = true;
			firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
			btns [firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

		} else if (!secondGuess) {

			secondGuess = true;
			secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
			btns [secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

			countGuesses++;
			
			StartCoroutine(CheckIfThePuzzlesMatch());
			if(firstGuessPuzzle == secondGuessPuzzle) {
				// Debug.Log ("The Puzzles Match");
            skor+=15;
			}
            else
            {
                // Debug.Log ("The Puzzles Dont Match");
                if (skor == 0)
                {
                    skor = 0;
                }
                else
                {
                    skor -= 5;
                }
            }
        }  	
   }

 IEnumerator CheckIfThePuzzlesMatch() {
 	yield return new WaitForSeconds (1f);

 	if(firstGuessPuzzle == secondGuessPuzzle) {
 		yield return new WaitForSeconds (.5f);

 		btns[firstGuessIndex].interactable = false;
 		btns[secondGuessIndex].interactable = false;

 		btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
 		btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

 		CheckIfTheGameIsFinished();
 	} else {
 		btns[firstGuessIndex].image.sprite = bgImage;
 		btns[secondGuessIndex].image.sprite = bgImage;
 	}
 	yield return new WaitForSeconds (.5f);

 	firstGuess = secondGuess = false;
 }

 void CheckIfTheGameIsFinished() {
 	countCorrectGuesses++;

 	if (countCorrectGuesses == gameGuesses) {
 		Debug.Log("Game Finished");
 		Debug.Log("It Took you " + countGuesses + " many guess(es) to finish the game");
      selesai.SetActive(true);
 	}
 }
 	void Shuffle (List<Sprite> list) {
 		for(int i = 0; i < list.Count; i ++) {
 			Sprite temp = list [i];
 			int randomIndex = Random.Range(i, list.Count);
 			list[i] = list[randomIndex]; 
 			list[randomIndex]= temp;
 		}
 	}
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
}
