using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SadnessBar : MonoBehaviour
{
    private Transform sadnessbar;
    public Text sadnesstext = null;

    // Start is called before the first frame update
    void Start()
    {
        sadnessbar = transform.Find("SadnessBar");
    }

    public void SetSize(float sizeNormalized)
    {
        sadnessbar.localScale = new Vector3(sizeNormalized, 1f);
        sadnesstext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
