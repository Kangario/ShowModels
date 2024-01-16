using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] public  GameObject target;
    [SerializeField] private float rotateSpeed;
    public Vector2 direction;
    public bool isControll = true;
    public float directionToObject = 10f;
    void Start()
    {
        Display[] displays = Display.displays;

        // Убеждаемся, что у нас есть по крайней мере два экрана
        if (displays.Length >= 2)
        {
            // Установка разрешения и активации второго экрана
            displays[1].Activate();
           // Screen.SetResolution(1600, 720, false,60);
        }
    }
    void FixedUpdate()
    {
        Vector3 targetPosition = target.transform.position - transform.forward * directionToObject;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
        if (isControll)
        {
            Vector3 rotation = new Vector3(direction.y, -direction.x, 0f) * rotateSpeed;
            float currentXRotation = transform.eulerAngles.x + rotation.x;
            currentXRotation = Mathf.Clamp(currentXRotation, 0f, 90f);
            transform.rotation = Quaternion.Euler(currentXRotation, transform.eulerAngles.y + rotation.y, 0f);
        }
        else
        {
            direction = Vector3.zero;
        }
        Debug.LogWarning(isControll);
    }

    
   
}
