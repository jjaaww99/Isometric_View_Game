using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : PointableObject
{
    public JWPlayerController player;

    Vector3 startPosition;
    Vector3 middlePosition;
    Vector3 endPosition;

    public float rotationSpeed = 90f;

    public int coinValue;

    private Vector3 originalPosition;
    private float jumpHeight = 2.0f;
    protected override void OnEnable()
    {
        base.OnEnable();

        coinValue = Random.Range(2, 10);

        multipleRenderers = GetComponentsInChildren<Renderer>();

        jWPlayerController = FindAnyObjectByType<JWPlayerController>();

        originalPosition = transform.position;

        StartCoroutine(JumpAndResetCoroutine());
    
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {

    }

    IEnumerator JumpAndResetCoroutine()
    {
        Vector3 jumpPosition = originalPosition + Vector3.up * jumpHeight;

        Vector3 rotationAxis = Vector3.left;
        float angle = rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

        float Duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < Duration)
        {
            //선형보간기능
            transform.position = Vector3.Lerp(originalPosition, jumpPosition, elapsedTime / Duration);
            elapsedTime += Time.deltaTime;

            //회전 기능
            transform.rotation = rotation * transform.rotation;

            yield return null;
        }

        elapsedTime = 0f;

        while (elapsedTime < Duration)
        {
            //선형보간기능
            transform.position = Vector3.Lerp(jumpPosition, originalPosition, elapsedTime / Duration);
            elapsedTime += Time.deltaTime;

            //회전기능
            transform.rotation = rotation * transform.rotation;

            yield return null;
        }

        // 마지막에 원상태로 복귀하게
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;
    }


    public float duration = 1f;

    public IEnumerator GetCoin()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            startPosition = GetComponentInParent<Transform>().position;

            Vector3 point = (transform.position + player.transform.position) / 2;

            middlePosition = point + new Vector3(0, 2, 0);

            endPosition = player.transform.position;

            elapsedTime += Time.deltaTime;

            float t = elapsedTime / duration;

            Vector3 newPosition = CalculateBezierPoint(t, startPosition, middlePosition, endPosition);

            transform.position = newPosition;

            Vector3 rotationAxis = Vector3.left;

            float angle = rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

            transform.rotation = rotation * transform.rotation;

            yield return null;
        }

        transform.position = endPosition;
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0; // (1-t)^2 * p0
        p += 2 * u * t * p1; // 2(1-t)t * p1
        p += tt * p2; // t^2 * p2

        return p;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}