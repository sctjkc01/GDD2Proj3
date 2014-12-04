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

    public GameObject towerPlaceButton;
    public GameObject waveLaunchButton;

    void Start() {
        if(inst == null) inst = this;
        playing = true;
        level = 0;
    }

    void Update() {
        if(playing && lives < 1) {
            playing = false;
        }

        towerPlaceButton.SetActive(playing && !(enemiesAlive + enemiesLeft > 0));
        waveLaunchButton.SetActive(playing && !(enemiesLeft > 0) && !(towerPlaceButton.GetComponent<TogglePlacement>().toggOn));
    }

}
