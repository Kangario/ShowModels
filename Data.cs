using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int id;
    [SerializeField] ButtonsController butCon;


   public void GetId()
    {
        butCon.id = gameObject.GetComponent<Data>().id;
    }

  


}
