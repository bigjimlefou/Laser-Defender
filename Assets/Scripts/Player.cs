using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float paddingLeft = 0.5f;
    [SerializeField] private float paddingRight = 0.5f;
    [SerializeField] private float paddingTop = 0.4f;
    [SerializeField] private float paddingBottom = 0.4f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+paddingLeft;
            xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-paddingRight;
            yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+paddingBottom;
            yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-paddingTop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var position = transform.position;
        var newXPosition = Mathf.Clamp(position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(position.y + deltaY, yMin, yMax);

        position = new Vector2(newXPosition, newYPosition);
        transform.position = position;
    }
}