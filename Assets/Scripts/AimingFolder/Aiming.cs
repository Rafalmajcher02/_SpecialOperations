using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public float rotationSpeed = 5f; //applies delayed speed of rotation
    public GameObject Player;

    public float AngleF;
    void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //getting mouse input and correcting it by the distance of the camera and saving as vector 2
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //getting tan of y and x from camera and getting some unity manual stuff to calculate tangent by using two sides of triangle calculating an missing angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); //conveting the angle and vector 3 into quaternion so  ican use transform rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime); //rotating object with the speed applied.         

        GameObject Player = GameObject.Find("Player");
        Transform PlayerT = Player.GetComponent<Transform>();
        AngleF = angle;
    }
}
