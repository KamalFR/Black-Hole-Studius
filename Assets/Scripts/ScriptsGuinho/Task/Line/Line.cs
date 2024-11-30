using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string colorTag;

    public RectTransform head;
    public RectTransform foot;
    public RectTransform target;

    public Image lineImage;

    [HideInInspector] public Vector2 _startPosition;
    [HideInInspector] public bool _isConnected;

    private void Start()
    {
        _isConnected = false;
        _startPosition = head.position;
        Cursor.visible = true;
    }

    void Update()
    {
        // Calcula a posição média entre os dois pontos para centralizar a linha
        Vector2 direction = head.position - foot.position;

        // Define o tamanho da linha baseado na distância entre os dois pontos
        float distance = direction.magnitude;

        // Posiciona a linha no meio entre os dois pontos
        lineImage.rectTransform.position = (head.position + foot.position) / 2;

        // Ajusta o tamanho da linha para que ela cubra a distância entre os pontos
        lineImage.rectTransform.sizeDelta = new Vector2(distance, 100f);

        // Rotaciona a linha para que ela se alinhe com a direção entre os pontos
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isConnected)
        {
            Vector3 mousePosition = Input.mousePosition;
            head.position = mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!_isConnected) head.position = _startPosition;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == colorTag)
        {
            _isConnected = true;
            head.position = target.position;
        }
    }
}
