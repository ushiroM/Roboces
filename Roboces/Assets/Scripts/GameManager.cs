using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public UILabel Countdown;
	public UILabel Victory;

    GameObject player;
    GameObject[] enemies;
    String[] positions;
    IASimple enemyIA;
    PlayerMovement playerMov;
	Animator playerAnim;
	Animator enemyAnim;
	CapsuleCollider playercapsule;
	CapsuleCollider iacapsule;
	AudioSource audio;

    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    public GameObject Pause;
    public GameObject Continuar;
    public GameObject Exit;
    public GameObject Restart;



    void Start () {

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        player = GameObject.FindGameObjectWithTag("Player");
		playerMov = player.GetComponent<PlayerMovement>();
		playerAnim = player.GetComponent<Animator> ();
		playercapsule = player.GetComponent<CapsuleCollider> ();
		audio = player.GetComponent<AudioSource> ();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        positions = new String[5]; 

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());

        yield return StartCoroutine(RoundPlaying());
    }

    private IEnumerator RoundStarting()
    {
        DisableControl();

        Countdown.text = "3";

        yield return new WaitForSeconds(1.5f);

        Countdown.text = "2";

        yield return new WaitForSeconds(1.5f);

        Countdown.text = "1";

        yield return new WaitForSeconds(1.5f);

        Countdown.text = "Ya!";
    }

    private IEnumerator RoundPlaying()
    {
        EnableControl();

        yield return new WaitForSeconds(2);

        Countdown.text = string.Empty;
       
    }

	private IEnumerator EndGame()
	{
		playerMov.enabled = false;
        positions[PositionManager.position] = player.name;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyIA = enemies[i].GetComponent<IASimple>();
            enemyIA.TurnOffIA();
            positions[enemyIA.position] = enemies[i].name;
        }

		if (PositionManager.position == 1) {
			playerAnim.SetBool ("Win", true);

            for(int i =0; i < enemies.Length; i++)
            {
                enemyAnim = enemies[i].GetComponent<Animator>();
                iacapsule = enemies[i].GetComponent<CapsuleCollider>();
                enemyAnim.SetBool("Lose", true);
                iacapsule.direction = 0;
            }

		} else {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemyAnim = enemies[i].GetComponent<Animator>();
				enemyIA = enemies [i].GetComponent<IASimple>();
				if (enemyIA.position == 1) enemyAnim.SetBool("Win", true);
				else enemyAnim.SetBool("Lose", true);
            }
			playerAnim.SetBool ("Lose", true);
			playercapsule.direction = 0;
		}

        Victory.text = "Primero: " + positions[1] + "\nSegundo: " + positions[2] + "\nTercero: " + positions[3] + "\nCuarto: " + positions[4];

        yield return new WaitForSeconds(10f);

		loadScene ();
	}

   
    private void DisableControl()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyIA = enemies[i].GetComponent<IASimple>();
            enemyIA.DisableIA();
        }
        playerMov.enabled = false;
		audio.Stop ();
    }

    private void EnableControl()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyIA = enemies[i].GetComponent<IASimple>();
            enemyIA.EnableIA();
        }
        playerMov.enabled = true;
		audio.Play ();
    }

	void Update(){

		if (MarkCheckpoint.playerLap > MarkCheckpoint.maxlaps) {
			StartCoroutine (EndGame ());
		}
        if (Input.GetKey(KeyCode.Escape))
        {
           ActivePause();
        }
	}


	void loadScene(){
		SceneManager.LoadScene("Menu");
	}

    public void ActivePause()
    {
        Pause.SetActive(true);
        Continuar.SetActive(true);
        Exit.SetActive(true);
        Restart.SetActive(true);
        Time.timeScale = 0;
    }
}
