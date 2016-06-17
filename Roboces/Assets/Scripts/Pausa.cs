using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour {

    public GameObject Pause;
    public GameObject Continuar;
    public GameObject Exit;
    public GameObject Restart;
    
    public void restartGame()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene("escena1");
	}
	public void exit()
	{
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
	}

	public void Continue(){
        Pause.SetActive(false);
        Continuar.SetActive(false);
        Exit.SetActive(false);
        Restart.SetActive(false);
        Time.timeScale = 1;
    }

   
}
