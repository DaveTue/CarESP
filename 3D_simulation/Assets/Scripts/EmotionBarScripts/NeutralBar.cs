using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeutralBar : MonoBehaviour
{
    private Transform neutralbar;
    public Text neutraltext = null;

    // Start is called before the first frame update
    void Start()
    {
        neutralbar = transform.Find("NeutralBar");
    }

    public void SetSize(float sizeNormalized)
    {
        neutralbar.localScale = new Vector3(sizeNormalized, 1f);
        neutraltext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
