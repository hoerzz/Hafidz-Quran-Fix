using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamplay6Drag : MonoBehaviour
{
    public GameObject detector;
    public Vector3 pos_awal, scale_awal;
    public bool on_pos = false, on_tempel = false;


    //Music
    private AudioSource source;
    public AudioClip benar, salah;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        pos_awal = transform.position;
        scale_awal = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, -1f);
        transform.localScale = new Vector2(1.5f, 1.09f);
    }
    void OnMouseUp()
    {
        if (on_pos)
        {
            ScoreManagement.score +=10;
            transform.position = detector.transform.position;
            transform.localScale = new Vector2(1.5f, 1.09f);
            on_tempel = true;
            source.clip = benar;
            source.Play();
        }
        else
        {
            ScoreManagement.score -=5;
            transform.position = pos_awal;
            transform.localScale = scale_awal;
            on_tempel = false;
            source.clip = salah;
            source.Play();

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == detector)
        {
            on_pos = true;
            
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == detector)
        {
            on_pos = false;
        }
    }
}
