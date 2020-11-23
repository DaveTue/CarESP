using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camEvents : MonoBehaviour
{
    public Camera[] cams;

    public void camMainMove()
    {
        cams[0].enabled = true;
        cams[1].enabled = false;
        cams[2].enabled = false;
    }

    public void camTopMove()
    {
        cams[0].enabled = false;
        cams[1].enabled = true;
        cams[2].enabled = false;
    }

    public void camSideMove()
    {
        cams[0].enabled = false;
        cams[1].enabled = false;
        cams[2].enabled = true;
    }
}
