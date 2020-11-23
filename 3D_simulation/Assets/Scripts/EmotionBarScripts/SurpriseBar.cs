using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurpriseBar : MonoBehaviour
{
    private Transform surprisebar;
    public Text surprisetext = null;

    // Start is called before the first frame update
    void Start()
    {
        surprisebar = transform.Find("SurpriseBar");
    }

    public void SetSize(float sizeNormalized)
    {
        surprisebar.localScale = new Vector3(sizeNormalized, 1f);
        surprisetext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
