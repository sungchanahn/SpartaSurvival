using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : UtilObject
{
    public Transform start;
    public Transform arrival;

    public float speed;
    public float waitSecond;

    public override void OnInteract()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (Vector3.Distance(transform.position, arrival.position) > 0.1f)
        {
            yield return null;
            MoveStartToArrival();
        }
        yield return new WaitForSeconds(waitSecond);

        while (Vector3.Distance(transform.position, start.position) > 0.1f)
        {
            yield return null;
            MoveArrivalToStart();
        }
    }

    private Vector3 SetDirection(Vector3 startPosition, Vector3 arrivalPosition)
    {
        return (arrivalPosition - startPosition).normalized;
    }

    private void MoveStartToArrival()
    {
        Vector3 direction = SetDirection(start.position, arrival.position);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void MoveArrivalToStart()
    {
        Vector3 direction = SetDirection(arrival.position, start.position);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
