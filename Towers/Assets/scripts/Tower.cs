using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class Tower : MonoBehaviour {

    /// <summary>
    /// The _mods only GameObject for now
    /// </summary>
    public FusedModule[] attrMods = new FusedModule[3];
    public FusedModule elementMod = null;
    /// <summary>
    /// Attributes for this tower. Multiplied off of our Modules.
    /// </summary>
    public TowerAttributes attribs;
    public List<Enemy> enemies = new List<Enemy>();

    private SphereCollider colider;
    private float _timer = 0;

    public ParticleSystem ps;



    void OnTriggerEnter(Collider obj) {
        if(obj.tag == "Enemy") {
            Debug.Log("boop");
            enemies.Add(obj.gameObject.GetComponent<Enemy>());
        }

        Debug.Log("boop");

    }


    void OnTriggerExit(Collider obj) {
        if(obj.tag == "Enemy") {
            enemies.Remove(obj.gameObject.GetComponent<Enemy>());
        }
    }

    void Fire(Enemy e) {

        ps.Play();

        e.takeDamage(attribs.Damage);

        _timer = attribs.FireRate;

    }

    void StartRound() {
        colider.enabled = true;
    }

    void EndRound() {
        colider.enabled = false;
    }


    // Use this for initialization
    void Start() {
        ps = this.GetComponentInChildren<ParticleSystem>();
        colider = this.gameObject.GetComponent<SphereCollider>();
        attribs = new TowerAttributes();
        attribs.FireRate = 0.5f;
        //if (mods[0] == null)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        mods[i] = ScriptableObject.CreateInstance<BaseModule>();
        //    }
        //}
        for(int i = 0; i < 3; i++) {
            attrMods[i] = null;
        }
    }

    // Update is called once per frame
    void Update() {
        _timer -= Time.deltaTime;

        if(_timer <= 0 && enemies.Count != 0) {
            if(enemies[0] == null) { enemies.RemoveAt(0); } else {
                Fire(enemies[0]);
            }
        }

        colider.enabled = (GameManager.inst.enemiesAlive > 0);

    }

    public void InstallModule(FusedModule m) {
        if(attrMods[0] == null) {
            attrMods[0] = m;
        } else if(attrMods[1] == null) {
            attrMods[1] = m;
        } else if(attrMods[2] == null) {
            attrMods[2] = m;
        } else throw new System.Exception("Tower has no space for mods!");

        DisplayNextModule();
        attribs = new TowerAttributes();
        for(int i = 0; i < 3; i++) {
            if(attrMods[i] != null) {
                if(attrMods[i].level == 1) {
                    attribs += attrMods[i].attribs * 0.5f;
                } else {
                    attribs += attrMods[i].attribs;
                }
            }
        }
    }

    public void RemoveModule(FusedModule m) {
        if(attrMods[0] == m) {
            attrMods[0] = null;
        } else if(attrMods[1] == m) {
            attrMods[1] = null;
        } else if(attrMods[2] == m) {
            attrMods[2] = null;
        } else throw new System.Exception("Tower doesn't have that mod!");

        HidePreviousModule();
        attribs = new TowerAttributes();
        for(int i = 0; i < 3; i++) {
            if(attrMods[i] != null) {
                if(attrMods[i].level == 1) {
                    attribs += attrMods[i].attribs * 0.5f;
                } else {
                    attribs += attrMods[i].attribs;
                }
            }
        }
    }

    void DisplayNextModule() {
        MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        for(int i = 0; i < renderers.Length; i++) {
            if(!renderers[i].enabled) {
                renderers[i].enabled = true;
                break;
            }
        }
    }

    void HidePreviousModule() {
        MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        for(int i = renderers.Length - 1; i-- > 0; ) {
            if(renderers[i].enabled) {
                renderers[i].enabled = false;
                break;
            }
        }
    }
}
