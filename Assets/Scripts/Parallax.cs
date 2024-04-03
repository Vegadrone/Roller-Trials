using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0, 0.5f)]
    [SerializeField] float speed = 0.2f;
    void Start()
    {
       mat = GetComponent<Renderer>().material; 
    }


    void Update()
    {
        distance += Time.fixedDeltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
