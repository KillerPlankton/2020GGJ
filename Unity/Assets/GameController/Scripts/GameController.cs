using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private int numberOfOutposts;

    [SerializeField]
    private GameObject MenuBackground, WinMessage, LoseMessage;

    private int numberOfRepairedOutposts = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        this.MenuBackground.SetActive(true);
        this.LoseMessage.SetActive(false);
        this.WinMessage.SetActive(false);
        Cursor.visible = true;
    }

    void OutpostRepaired() {
        // This function is called by sendMessage in outpost script.
        numberOfRepairedOutposts++;
        if (numberOfRepairedOutposts >= numberOfOutposts) {
            WinMessage.SetActive(true);
            Cursor.visible = true;
            Invoke("RestartScene", 5.0f);
        }
    }

    public void StartGame() {
        Time.timeScale = 1.0f;
        this.MenuBackground.SetActive(false);
        this.LoseMessage.SetActive(false);
        this.WinMessage.SetActive(false);
        Cursor.visible = false;
        GameObject.FindGameObjectWithTag("Player").SetActive(true);
    }

    public void Die() {
        Time.timeScale = 0.0f;
        this.MenuBackground.SetActive(true);
        this.LoseMessage.SetActive(true);
        this.WinMessage.SetActive(false);
        Invoke("RestartScene", 5.0f);
        Cursor.visible = true;
    }

    private void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
