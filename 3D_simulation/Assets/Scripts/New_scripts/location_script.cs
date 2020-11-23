using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location_script : MonoBehaviour
{

    public GameObject Kyle;
    public GameObject player;
    public float x_player_0;
    public float z_player_0;
    public float x_player;
    public float z_player;
    public float speed;
    public float acceleration;
    public float speed_last=0;
    public float direction_angle_ecar;
   


    // Start is called before the first frame update
    void Start()
    {
        x_player_0 = player.gameObject.transform.position.x;
        z_player_0 = player.gameObject.transform.position.z;
        //Debug.Log("initial location player= (" + x_player_0 + "," + z_player_0 + ")\n");
    }

    // Update is called once per frame
    void Update()
    {

        // how to obtain absolute location of game objects
        //speed = player.gameObject.GetComponent<Rigidbody>().velocity.magnitude*3.6f;
        speed = player.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        acceleration = (speed - speed_last) / Time.fixedDeltaTime;
        direction_angle_ecar = player.transform.rotation.eulerAngles.y;
        x_player = player.gameObject.transform.position.x;
        z_player = player.gameObject.transform.position.z;
        speed_last = speed;
        /*Debug.Log("initial location player= (" + x_player_0 + "," + z_player_0 + ")\n");
        Debug.Log("location player= " + x_player +","+ z_player + "\n");
        Debug.Log("speed= " + speed + "m/s" + "\n");
        Debug.Log("previous speed= " + speed_last + "m/s" + "\n");
        Debug.Log("acceleration= " + acceleration + "m/s^2" + "\n");
        Debug.Log("rotation angle= " + direction_angle_ecar + "degrees" + "\n");
        speed_last = speed;
        */
    }
}
