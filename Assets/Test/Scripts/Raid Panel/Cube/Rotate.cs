using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3[] cubeNumber;
    public float rotationtime;
    private float timer;
    private int _edge;
    private bool _isActive;
    public float rotateSpeed;
    public float endRotateSpeed;
    private int randomEdge;
    public AnimationCurve curve;
    private float qwe;
    [SerializeField] private Raid_control raid_Control;


    private void FixedUpdate()
    {
        Rotation();
    }
    private void Rotation()
    {
        if (_isActive)
        {
            qwe = timer / rotationtime;
            if (timer <= rotationtime)
            {
                /*transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(cubeNumber[randomEdge]), curve.Evaluate(qwe) * rotateSpeed);
                if (transform.rotation == Quaternion.Euler(cubeNumber[randomEdge]))
                {
                    randomEdge = Random.Range(0, cubeNumber.Length);
                }*/

                transform.rotation = Quaternion.Euler(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
                timer += Time.fixedDeltaTime;
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(cubeNumber[_edge]), endRotateSpeed);
                if (transform.rotation == Quaternion.Euler(cubeNumber[_edge]))
                {
                    _isActive = false;
                    raid_Control.RotateComplete();
                }
            }
        }
    }
    public void StartRotate(int _edge)
    {
        timer = 0;
        this._edge = _edge;
        _isActive = true;
    }
    public void StopRotate()
    {
        timer = 0;
        _isActive = false;
        transform.rotation = Quaternion.Euler(cubeNumber[0]);
    }

}
 