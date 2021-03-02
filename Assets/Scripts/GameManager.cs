using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        // reset game
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            ScoreScript.scoreValue = 0;
            InHeli.soldierInHeli = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
