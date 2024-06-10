using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : ClickableObject
{
    public JWPlayerController jWPlayerController;

    Vector3 startPosition;
    Vector3 middlePosition;
    Vector3 endPosition;

    public float rotationSpeed = 90f;

    private void Awake()
    {
        multipleRenderers = GetComponents<Renderer>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        Vector3 point = (transform.position + jWPlayerController.transform.position) / 2;

        startPosition = transform.position;
        middlePosition = point + new Vector3(0, 2, 0);

        StartCoroutine(MoveAlongBezierCurve());
    }
    private void Update()
    {
        Debug.Log(originalLayer);
        endPosition = jWPlayerController.transform.position;
    }
    public float duration = 2f;

    IEnumerator MoveAlongBezierCurve()
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
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

        // 마지막 위치 설정 (정확한 끝점)
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
}
