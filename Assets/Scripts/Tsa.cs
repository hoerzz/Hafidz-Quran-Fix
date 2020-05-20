using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tsa : MonoBehaviour
{
	[SerializeField]
	private Transform tsaPlace;

	private Vector2 initialPosition;

	private Vector2 mousePosition;

	private float deltaX, deltaY;

	public static bool locked;

	public Text tscore;

    int skor=0;	
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown() {
    	if(!locked) {
    		deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
    		deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    	}
    }

    private void OnMouseDrag() {
    	if(!locked) {
    		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    		transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    	}
    }

    private void OnMouseUp() {
    	if (Mathf.Abs(transform.position.x - tsaPlace.position.x) <= 0.5f &&
    		Mathf.Abs(transform.position.y - tsaPlace.position.y) <= 0.5f) {
    		transform.position = new Vector2(tsaPlace.position.x, tsaPlace.position.y);
    		locked = true;
            skor+=10;
    	} else {
    		transform.position = new Vector2(initialPosition.x, initialPosition.y);
            // if(skor == 0) {
            //             skor = 0;
            //         } else {
            //             skor-=5;        
            //         }
    	}
    }
    // Update is called once per frame
    void Update()
    {
      tscore.text = skor.ToString();  
    }
}
