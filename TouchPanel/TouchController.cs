using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TouchController : MonoBehaviour
{
    public RectTransform targetArea;
    private Vector2 touchStartPos;
    [SerializeField] private GameObject cm2;
    private Vector2 direction;
   
    void Start()
    {
        targetArea = gameObject.GetComponent<RectTransform>();
    }
   
 
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 inputPosition = Input.GetMouseButtonDown(0) ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;

            if (IsMouseInTargetArea(inputPosition))
            {
                touchStartPos = inputPosition;
                
                cm2.GetComponent<CameraController>().isControll = true;
            }
        }
        else if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {

            Vector2 inputPosition = Input.GetMouseButton(0) ? (Vector2)Input.mousePosition : Input.GetTouch(0).position;


            if (IsMouseInTargetArea(inputPosition))
            {

                direction = inputPosition - touchStartPos;
                cm2.GetComponent<CameraController>().direction = direction.normalized;
                cm2.GetComponent<CameraController>().isControll = true;
               
               


            }
            else
            {
                // ћышь или палец находитс€ вне зоны панели, обнул€ем direction
                cm2.GetComponent<CameraController>().direction = cm2.GetComponent<CameraController>().direction;

            }

        }
        else {
            cm2.GetComponent<CameraController>().isControll = false;
            cm2.GetComponent<CameraController>().direction = cm2.GetComponent<CameraController>().direction;

        }
            
      
      
      
        
    }
    bool IsMouseInTargetArea(Vector2 mousePosition)
    {
        if (targetArea.rect.size.x  < mousePosition.x && targetArea.rect.size.x*1.9f > mousePosition.x)
        {
            if (targetArea.rect.size.y/4f< mousePosition.y && targetArea.rect.size.y > mousePosition.y)
            {
              
                return true;
            }


        }

        
        return false;


    }
}
