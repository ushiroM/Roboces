using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public UILabel Countdown;
	public UILabel Victory;

    GameObject player;
    GameObject[] enemies;
    IASimple enemyIA;
    PlayerMovement playerMov;
	Animator playerAnim;
	Animator enemyAnim;
	CapsuleCollider playercapsule;
	CapsuleCollider iacapsule;
	AudioSource audio;

    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    void Start () {

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        player = GameObject.FindGameObjectWithTag("Player");
		playerMov = player.GetComponent<PlayerMovement>();
		playerAnim = player.GetComponent<Animator> ();
		playercapsule = player.GetComponent<CapsuleCollider> ();
		audio = player.GetComponent<AudioSource> ();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

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
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyIA = enemies[i].GetComponent<IASimple>();
            enemyIA.TurnOffIA();
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
			
			Victory.text = "¡Felicidades! \n \n" + "Has acabado primero";

		} else {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemyAnim = enemies[i].GetComponent<Animator>();
                enemyAnim.SetBool("Win", true);
            }
			playerAnim.SetBool ("Lose", true);
			playercapsule.direction = 0;
			Victory.text = "Lástima... \n \n" + "Has acabado segundo";
		}

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
	}

	void loadScene(){
		SceneManager.LoadScene("Menu");
	}
}
