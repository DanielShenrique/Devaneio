using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour {

	public void GoToTheMain(){
	 SceneManager.LoadScene(1);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
