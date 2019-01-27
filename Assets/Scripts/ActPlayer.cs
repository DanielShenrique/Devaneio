using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActPlayer : MonoBehaviour {

	public float speed;
	
	public Rigidbody2D rb;
	
    public GameObject b;

    public Text text;

    public GameObject oTexto;
	
	Camera cameraz;
	
	// Use this for initialization
	void Start () {
		 cameraz = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveH = Input.GetAxisRaw("Horizontal");
		float moveV = Input.GetAxisRaw("Vertical");
		
		rb.velocity = new Vector2(moveH * speed, moveV * speed);
	}

	
	void OnTriggerEnter2D(Collider2D cool)
	{
			if(cool.gameObject.CompareTag("Final"))
			{
				StartCoroutine(Zoom());			
			}
	}
    void OnTriggerStay2D(Collider2D cool)
    {
        if (cool.gameObject.CompareTag("Aviso"))
        {
            text.GetComponent<Alerta>().Foi = true;
            oTexto.SetActive(true);
        }
    }
	void OnTriggerExit2D(Collider2D cool)
	{
		if(cool.gameObject.CompareTag("Aviso"))
		{
			text.GetComponent<Alerta>().Foi = false;
            oTexto.SetActive(false);
		}
	}
	
	IEnumerator Zoom()
	{
		for (float z = 5f; z<10f; z+=0.05f) {
			cameraz.orthographicSize = z;
			yield return null;
		}
		for (float z = 10f; z >0f; z-=0.05f) {
			cameraz.orthographicSize = z;
			yield return null;	
		}
		SceneManager.LoadScene(2);
	}
}