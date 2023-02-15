using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Material mat;
    public float sp = 0.4f;
    public bool reached = false;
    public bool enemyFound = false;
    public AudioClip AC;
    //public Color color;
    // Start is called before the first frame update
    void Start()
    {
        //color = transform. GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" && reached == false) {
            Debug.Log("EnterBase");
            //plane.GetComponent<CreateTerrain>().itemGroup.Remove(this.gameObject);
            this.GetComponent<AudioSource>().PlayOneShot(AC);
            
            mat =  this.GetComponent<MeshRenderer>().material;
            mat.color = Color.white;
            AppManager.scoreNum += 5;
            reached = true;
        } else {
            enemyFound= true;
        }
    }
}
