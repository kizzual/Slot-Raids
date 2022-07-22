using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_ui : MonoBehaviour
{
    [SerializeField] private GameObject grey;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    public void MakeGrey()
    {
        grey.SetActive(true);
        red.SetActive(false);
        green.SetActive(false);
    }
    public void MakeGreen()
    {
        grey.SetActive(false);
        red.SetActive(false);
        green.SetActive(true);
    }
    public void MakeRed()
    {
        grey.SetActive(false);
        red.SetActive(true);
        green.SetActive(false);
    }
}
