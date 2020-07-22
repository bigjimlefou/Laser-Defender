using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float paddingLeft = 0.5f;
    [SerializeField] private float paddingRight = 0.5f;
    [SerializeField] private float paddingTop = 0.4f;
    [SerializeField] private float paddingBottom = 0.4f;
    [SerializeField] private float laserSpeed = 10f;
    [SerializeField] private float laserFiringPeriod = 0.5f;
    
    [SerializeField] private GameObject laserPrefab;

    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;

    private Coroutine _fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Lasser");
        SetBoundaries();
    }

    private void SetBoundaries()
    {
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            _xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+paddingLeft;
            _xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-paddingRight;
            _yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+paddingBottom;
            _yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-paddingTop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1") && _fireCoroutine == null)
        {
            _fireCoroutine = StartCoroutine(FireContinuously());
        }else if (Input.GetButtonUp("Fire1") && _fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            var laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,laserSpeed);
            yield return new WaitForSeconds(laserFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var position = transform.position;
        var newXPosition = Mathf.Clamp(position.x + deltaX, _xMin, _xMax);
        var newYPosition = Mathf.Clamp(position.y + deltaY, _yMin, _yMax);

        position = new Vector2(newXPosition, newYPosition);
        transform.position = position;
    }
}