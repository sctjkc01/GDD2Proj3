using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager inst;
    // How much cash does the player have?
    public int cash;
    // How many enemies are there left to spawn?
    public int enemiesLeft;
    // How many enemies are still alive?
    public int enemiesAlive;
    // How many enemies are we spawning this level?
    public int enemiesToSpawn;
    // Which level is the player on?
    public int level;
    // How many lives does the player have left?
    public int lives;
    // Is the game still live?
    public bool playing;

    private int typing;

    public GameObject towerPlaceButton;
    public GameObject waveLaunchButton;

    public GameObject gameOverPanel;

    void Start() {
        if(inst == null) inst = this;
        playing = true;
        level = 0;
        typing = 0;
    }

    void Update() {
        if(playing && lives < 1) {
            playing = false;
        }

        gameOverPanel.SetActive(!playing);

        towerPlaceButton.SetActive(playing && !(enemiesAlive + enemiesLeft > 0));
        waveLaunchButton.SetActive(playing && !(enemiesLeft > 0) && !(towerPlaceButton.GetComponent<TogglePlacement>().toggOn));

        // Quick end-the-game
        switch (typing){
            case 0:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.G)) { typing++; } else { typing = 0; } } break;
            case 1:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.A)) { typing++; } else { typing = 0; } } break;
            case 2:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.M)) { typing++; } else { typing = 0; } } break;
            case 3:
            case 6:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.E)) { typing++; } else { typing = 0; } } break;
            case 4:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.O)) { typing++; } else { typing = 0; } } break;
            case 5:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.V)) { typing++; } else { typing = 0; } } break;
            case 7:
                if(Input.anyKeyDown) { if(Input.GetKeyDown(KeyCode.R)) { typing++; } else { typing = 0; } } break;
            case 8:
                lives = 0; playing = false; break;
        }
    }

}
