using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBar : MonoBehaviour
{
    private Transform fearbar;
    public Text feartext = null;

    // Start is called before the first frame update
    void Start()
    {
        fearbar = transform.Find("FearBar");
    }

    public void SetSize(float sizeNormalized)
    {
        fearbar.localScale = new Vector3(sizeNormalized, 1f);
        feartext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
