using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public GameObject playerBody;
    public Material mat;
    public float timer = 10f;
    public static bool skilled = false;
    public Material newMat;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GameObject.Find("PlayerBody");
        mat = playerBody.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (skilled == true && timer > 0) {
            timer -= Time.deltaTime;
        } else if  (timer <= 0) {
            ChangeShader();
            timer = 10f;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Base") {
            ChangeShaderTwo();
            //timer += 10f; //every time enter base add another 3 seconds for superpower
        }
    }
    public void ChangeShader() {
        playerBody.GetComponent<MeshRenderer>().material = mat;
        skilled = false;
    }

    public void ChangeShaderTwo() {
        // Material material = new Material(Shader.Find("Legacy Shaders/Transparent/Diffuse"));
        // material.color = new Color(0.5f, 0.5f, 0.5f, 0.8f);
        
        //Material newMat = mat;
        //newMat.color = new Color(1f, 1f, 1f, 0.8f);
        playerBody.GetComponent<MeshRenderer>().material = newMat;
        skilled = true;
    }
}
