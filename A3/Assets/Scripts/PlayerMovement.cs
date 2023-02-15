using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float walkSpeed = 1f;
    public float runSpeed = 4f;

    public Transform point;
    private Rigidbody rig;
    //public float jumpForce = 100f;
    private Quaternion targetRot;

    //Model
    public Transform mesh;

    //Posion Hurt
    int hurt = 1;
    public GameObject Player;
    float attack_time = 0;

    //Run Hurt
    int runHurt = 10;
    float run_time = 0;

    //Add Stamina
    int addStamina = 20;
    float add_time = 0;


    //public Collider myBoxCollider;
    public Terrain terrain;

    void Start() {
        rig = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;

            // run reduce stamina
            if (run_time <= 0) {
                Debug.Log("Running and hurt");
			    Player.SendMessage("TakeRun", runHurt);
			    run_time = 1;
		    } else {
			    run_time -= Time.deltaTime;
		    }

        } else {
            speed = walkSpeed;

            //walk increase stamina
            if (add_time <= 0) {
                Debug.Log("Add");
			    Player.SendMessage("onAddStamina", addStamina);
			    add_time = 1;
		    } else {
			    add_time -= Time.deltaTime;
		    }
        }

        //GetComponentInChildren<Animator>().SetFloat("speed", speed);
        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        //transform.position += dir * Time.deltaTime * speed;
        dir = point.TransformDirection(dir);
        if (!(h == 0 && v == 0)) {
            //mesh.rotation = Quaternion.LookRotation(dir);
            targetRot = Quaternion.LookRotation(dir);
        }

        transform.Translate(dir * Time.deltaTime * speed);
        mesh.rotation = Quaternion.Lerp(mesh.rotation, targetRot, 0.1f);

        //dangerous and take hurt
        foreach (GameObject instance in terrain.dangerousGroup) {
            if (attack_time <= 0 && Exist(instance.GetComponent<BoxCollider>())) {
                Debug.Log("Dangerous");
			    Player.SendMessage("TakeDamage", hurt);
			    attack_time = 20;
		    } else {
			    attack_time -= Time.deltaTime;
		    }
        }

    }

    public bool Exist(Collider myBoxCollider) {
        Vector3 pos = point.position;
        //Debug.Log(pos);
        Bounds bounds = myBoxCollider.bounds;
        bool rendererIsInsideTheBox = bounds.Contains(pos);
        //Debug.Log (bounds);
        return rendererIsInsideTheBox;
    }


} 
