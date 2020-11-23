using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.GlobalIllumination;

//[ExecuteInEditMode]
public class LightEmitter : MonoBehaviour
{
    public int sim_input;
    public Light point;
    //new Color(233f/255f, 79f/255f, 55f/255f);
    Color color5 = new Color(100f / 255f, 221f / 255f, 22f / 255f); //bright green
    Color color4 = new Color(48f / 255f, 79f / 255f, 255f / 255f);  //dark blue
    Color color3 = new Color(255f / 255f, 252f / 255f, 7f / 255f);  //bright yellow
    Color color2 = new Color(255f / 255f, 109f / 255f, 0f / 255f);  //dark orange
    Color color1 = new Color(214f / 255f, 0f / 255f, 0f / 255f);    //dark red
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sim_input == 1)
        {
            point.color = color1;
        }
        if (sim_input == 2)
        {
            point.color = color2;
        }
        if (sim_input == 3)
        {
            point.color = color3;
        }
        if (sim_input == 4)
        {
            point.color = color4; ;
        }
        if (sim_input == 5)
        {
            point.color = color5;
        }
    }
}
