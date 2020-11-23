using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisgustBar : MonoBehaviour
{
    private Transform disgustbar;
    public Text disgusttext = null;

    // Start is called before the first frame update
    void Start()
    {
        disgustbar = transform.Find("DisgustBar");
    }

    public void SetSize(float sizeNormalized)
    {
        disgustbar.localScale = new Vector3(sizeNormalized, 1f);
        disgusttext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
