using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void loadGame()
    {
        SceneManager.LoadScene("escena1");
    }
	public void exit()
	{
		Application.Quit();
	}

	public void Instrucciones (){
		
	}
}
