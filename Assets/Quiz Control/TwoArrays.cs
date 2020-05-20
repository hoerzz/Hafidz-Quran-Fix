using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoArrays : MonoBehaviour {


    public string[] array1;

    public string[] array2;

    internal string[] tempArray;

    internal int index;


    public void OnValidate()
    {
        if (array1.Length != array2.Length)
        {
            tempArray = new string[array2.Length];

            //if ( array1.Length < array2.Length ) for (index = 0; index < array1.Length; index++) tempArray[index] = array1[index];
            //else for (index = 0; index < tempArray.Length; index++) tempArray[index] = array1[index];

            for (index = 0; index < tempArray.Length; index++)
            {
                tempArray[index] = array1[Mathf.Clamp(index,0, array1.Length - 1)];
            }

            array1 = tempArray;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
