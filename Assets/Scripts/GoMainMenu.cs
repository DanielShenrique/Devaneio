using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour {


	void Start()
	{
		StartCoroutine(BackMainMenu());		
	}

	IEnumerator BackMainMenu()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene(0);
	}
}
