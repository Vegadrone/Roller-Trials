using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParallaxController : MonoBehaviour
{   
    PlayerController player;
    CinemachineVirtualCamera cam; //MainCamera
    Vector3 camStartPos;
    float distance; //distance between the camera start position and its current position

    GameObject[] backgrounds;
    Material[] materials;
    float[] backgroundsSpeedFloats;
    float farthestBackground;

    [Range(0.01f, 0.05f)]
    [SerializeField] float parallaxSpeed;
    void Start()
    {
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        player = FindObjectOfType<PlayerController>();
        
        camStartPos = cam.transform.position;

        int backgroundsCount = transform.childCount;
        materials = new Material[backgroundsCount];
        backgroundsSpeedFloats = new float[backgroundsCount];
        backgrounds = new GameObject[backgroundsCount];

        for (int i = 0; i < backgroundsCount; i++)
        {
           backgrounds[i] = transform.GetChild(i).gameObject;
           materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackgroundsSpeedCalculate(backgroundsCount);
    }

    void BackgroundsSpeedCalculate(int backgroundsCount)
    {
        for (int i = 0; i < backgroundsCount; i++)// find the farthest background
        {
           if ((backgrounds[i].transform.position.z - cam.transform.position.z) > farthestBackground)
           {
                farthestBackground = backgrounds[i].transform.position.z - cam.transform.position.z;
           } 
        }

        for (int i = 0; i < backgroundsCount; i++)//set the speed of backgrounds
        {
            backgroundsSpeedFloats[i] = 1 - (backgrounds[i].transform.position.z - cam.transform.position.z) / farthestBackground;
        }
    }

    void LateUpdate()
    {
        distance = cam.transform.position.x - camStartPos.x;
        transform.position = new Vector3(player.transform.position.x + 40, player.transform.position.y,0);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backgroundsSpeedFloats[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0)* speed);
        }
    }
}
