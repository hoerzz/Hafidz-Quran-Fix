using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay2 : MonoBehaviour
{
	public GameObject alif, ba, ta, tsa, jim, alifWhite, baWhite, taWhite, tsaWhite, jimWhite;

	Vector2 alifInitialPos, baInitialPos, taInitialPos, tsaInitialPos, jimInitialPos;

    // Start is called before the first frame update
    void Start()
    {
        alifInitialPos = alif.transform.position;
        baInitialPos = ba.transform.position;
        taInitialPos = ta.transform.position;
        tsaInitialPos = tsa.transform.position;
        jimInitialPos = jim.transform.position;
    }
    
    public void DragAlif() {
    	alif.transform.position = Input.mousePosition;
    }

    public void DragBa() {
    	ba.transform.position = Input.mousePosition;
    }

    public void DragTa() {
    	ta.transform.position = Input.mousePosition;
    }

    public void DragTsa() {
    	tsa.transform.position = Input.mousePosition;
    }

    public void DragJim() {
    	jim.transform.position = Input.mousePosition;
    }

	public void DropAlif() {
    	float Distance = Vector3.Distance(alif.transform.position,alifWhite.transform.position);
    	if(Distance < 50) {
    		alif.transform.position = alifWhite.transform.position;
    	} else {
    		alif.transform.position = alifInitialPos;
    	}
    }

    public void DropBa() {
    	float Distance = Vector3.Distance(ba.transform.position,baWhite.transform.position);
    	if(Distance < 50) {
    		ba.transform.position = baWhite.transform.position;
    	} else {
    		ba.transform.position = baInitialPos;
    	}
    }

    public void DropTa() {
    	float Distance = Vector3.Distance(ta.transform.position,taWhite.transform.position);
    	if(Distance < 50) {
    		ta.transform.position = taWhite.transform.position;
    	} else {
    		ta.transform.position = taInitialPos;
    	}
    }

    public void DropTsa() {
    	float Distance = Vector3.Distance(tsa.transform.position,tsaWhite.transform.position);
    	if(Distance < 50) {
    		tsa.transform.position = tsaWhite.transform.position;
    	} else {
    		tsa.transform.position = tsaInitialPos;
    	}
    }

    public void DropJim() {
    	float Distance = Vector3.Distance(jim.transform.position,jimWhite.transform.position);
    	if(Distance < 50) {
    		jim.transform.position = jimWhite.transform.position;
    	} else {
    		jim.transform.position = jimInitialPos;
    	}
    }
}
