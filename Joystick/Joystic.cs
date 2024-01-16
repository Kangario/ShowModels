using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystic : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image joystickBackground;
    [SerializeField] private Image touch_Element;
    [SerializeField] private GameObject cm2;
    public Vector2 inputDirection = Vector2.zero;
    public bool isJosticControll;
    private float originalImageWidth = 750f;
    private float originalImageHeight = 750f;
    private void Update()
    {
        UpdateImageSize();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
       
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        touch_Element.rectTransform.anchoredPosition = Vector2.zero;
        cm2.GetComponent<CameraController>().isControll = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground.rectTransform,
            eventData.position + new Vector2(joystickBackground.rectTransform.sizeDelta.x/2, joystickBackground.rectTransform.sizeDelta.y/2),
            eventData.pressEventCamera,
            out position))
        {
            Debug.LogWarning(joystickBackground.rectTransform.sizeDelta.x +"|" + joystickBackground.rectTransform.sizeDelta.y);
            position.x = (position.x / joystickBackground.rectTransform.sizeDelta.x);
            position.y = (position.y / joystickBackground.rectTransform.sizeDelta.y);

            inputDirection = new Vector2(position.x *2 , position.y *2);
            inputDirection = (inputDirection.magnitude > 1.0f) ? inputDirection.normalized : inputDirection;

            touch_Element.rectTransform.anchoredPosition =
                new Vector2(inputDirection.x * (joystickBackground.rectTransform.sizeDelta.x / 3),
                            inputDirection.y  * (joystickBackground.rectTransform.sizeDelta.y / 3)) ;
        }
        cm2.GetComponent<CameraController>().direction = inputDirection;
        cm2.GetComponent<CameraController>().isControll = true;
    }
    void UpdateImageSize()
    {
        // Получение текущих размеров экрана
        float currentScreenWidth = Screen.width;
        float currentScreenHeight = Screen.height;

        // Рассчитываем коэффициент изменения размера по ширине и высоте
        float widthScale = currentScreenWidth / 3840;
        float heightScale = currentScreenHeight / 2160;

        // Масштабирование изображения
        float newWidth = originalImageWidth * widthScale;
        float newHeight = originalImageHeight * heightScale;

        // Применение новых размеров к изображению
        joystickBackground.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        
        // Обновление исходных размеров экрана
        
}
    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
  
}
