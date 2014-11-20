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

    void Start() {
        if(inst == null) inst = this;
    }

}
