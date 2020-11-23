using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    private Transform angerbar;
    public Text angertext = null;

    // Start is called before the first frame update
    void Start()
    {
        angerbar = transform.Find("AngerBar");
    }

    public void SetSize(float sizeNormalized)
    {
        angerbar.localScale = new Vector3(sizeNormalized, 1f);
        angertext.text = (sizeNormalized*100).ToString() + "%";
    }
}
