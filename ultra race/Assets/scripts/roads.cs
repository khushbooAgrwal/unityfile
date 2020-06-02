using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roads : MonoBehaviour
{
    public GameObject plane;
    private Renderer planeMaterial;

    public float speed = 1f;
     
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
         planeMaterial = plane.GetComponent<Renderer> (); 
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += -speed * Time.deltaTime;
        planeMaterial.material.SetTextureOffset ("_MainTex", offset );
    }
}
