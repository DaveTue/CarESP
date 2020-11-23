using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class DataEmitter : MonoBehaviour
{
    public int sim_input;
    public ParticleSystem system;
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
            system.Emit(new ParticleSystem.EmitParams() { position = Random.onUnitSphere, startColor = color1 }, 1);
        }
        if (sim_input == 2)
        {
            system.Emit(new ParticleSystem.EmitParams() { position = Random.onUnitSphere, startColor = color2 }, 1);
        }
        if (sim_input == 3)
        {
            system.Emit(new ParticleSystem.EmitParams() { position = Random.onUnitSphere, startColor = color3 }, 1);
        }
        if (sim_input == 4)
        {
            system.Emit(new ParticleSystem.EmitParams() { position = Random.onUnitSphere, startColor = color4 }, 1);
        }
        if (sim_input == 5)
        {
            system.Emit(new ParticleSystem.EmitParams() { position = Random.onUnitSphere, startColor = color5 }, 1);
        }
    }
}
