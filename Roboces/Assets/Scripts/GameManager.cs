using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public Text m_MessageText;

    GameObject player;
    GameObject enemy;
    IASimple enemyIA;
    PlayerMovement playermov;

    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;

    void Start () {

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyIA = enemy.GetComponent<IASimple>();
        playermov = player.GetComponent<PlayerMovement>();


        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
  
        yield return StartCoroutine(RoundStarting());

       /// Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(RoundPlaying());

      /*// Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
        yield return StartCoroutine(RoundEnding());

        // This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
        if (m_GameWinner != null)
        {
            // If there is a game winner, restart the level.
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            // If there isn't a winner yet, restart this coroutine so the loop continues.
            // Note that this coroutine doesn't yield.  This means that the current version of the GameLoop will end.
            StartCoroutine(GameLoop());
        }*/
    }

    private IEnumerator RoundStarting()
    {
        DisableControl();

        m_MessageText.text = "3";

        yield return new WaitForSeconds(1.5f);

        m_MessageText.text = "2";

        yield return new WaitForSeconds(1.5f);

        m_MessageText.text = "1";

        yield return new WaitForSeconds(1.5f);

        m_MessageText.text = "Ya!";
    }

    private IEnumerator RoundPlaying()
    {
        EnableControl();

        yield return new WaitForSeconds(2);

        m_MessageText.text = string.Empty;
       
    }

   
    private void DisableControl()
    {
        enemyIA.DisableIA();
        playermov.enabled = false;
    }
    private void EnableControl()
    {

        enemyIA.EnableIA();
        playermov.enabled = true;
    }
}
