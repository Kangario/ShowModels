using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject[] builds;
    [SerializeField] private GameObject display2;
    public int id = 0;
    private void Start()
    {
        BackToScene();
    }
    public void Update()
    {
        
       for(int i=0; i < builds.Length; i++)
        {
            if (id == builds[i].GetComponent<Data>().id)
            {
                display2.GetComponent<CameraController>().target = builds[i];
                display2.GetComponent<CameraController>().directionToObject = 2f;
                return;
            }
        }
    }


    public void BackToScene()
    {
        display2.GetComponent<CameraController>().target = GameObject.Find("SceneBuilds");
        display2.GetComponent<CameraController>().directionToObject = 10f;
        id = 0;
    }



}
