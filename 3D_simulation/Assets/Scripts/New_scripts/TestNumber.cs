using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This script enables and dissable objects depending on the presence of the objects is being tested.
 * There are 4 possible events:
 * -Driving alone and the test imply the hit of a pedestrian (event_num=0)
 * -Driving alone and the test imply accelerate alone on a straight line, 
 *  curve handling or lane change (event_num=1)
 * -Driving with another other vehicle 2 possible tests: vehicle following 
 *  or overtake version 1(only one car) (event_num=2)
 * -Driving with 2 other vehicles test is  Overtake with third vehicle comming
 *  in the other lane in opposite direction (event_num=3)
 * 
*/
public class TestNumber : MonoBehaviour
{
    public InputVariables pedestrian;
    public GameObject Kyle;
    public int event_num;

    // Start is called before the first frame update
    void Start()
    {
        if (pedestrian.pedestrian_active == 0)
        { event_num = 1; }
        if (pedestrian.pedestrian_active==1)
        { event_num = 0; }
        if (event_num != 0)
        {
            Kyle.gameObject.GetComponent<Animator>().enabled = false;
            Kyle.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Kyle.gameObject.GetComponent<Transform>().position = new Vector3(866.4879f, 922.862f, 805.3486f);
        }

    }
        // Update is called once per frame
        void Update()
    {
        if (pedestrian.pedestrian_active == 0)
        { event_num = 1; }
        if (pedestrian.pedestrian_active == 1)
        { event_num = 0; }
        if (event_num != 0)
            {
                Kyle.gameObject.GetComponent<Animator>().enabled = false;
                Kyle.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Kyle.gameObject.GetComponent<Transform>().position = new Vector3(866.4879f, 922.862f, 805.3486f);
            }

        }
    }
