using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PrefabInitialise : MonoBehaviour
{
    public GameObject prefab;
    public int objectsCount;
    public Transform parent;
    public float distanceBetweenGameObjects = 0;
    public bool initialisePrefab = false; // initialize prefab
    void Start()
    {

    }

    void Update()
    {
        if (initialisePrefab)
        {
            initialisePrefab = false;
            float currentY = 0;
            for (int i = 0; i < objectsCount; i++)
            {

                RectTransform go = Instantiate(prefab, parent).GetComponent<RectTransform>();
                go.transform.localPosition = new Vector3(0, currentY, 0);

                var r = (byte)Random.Range(1, 255);
                var g = (byte)Random.Range(1, 255);
                var b = (byte)Random.Range(1, 255);
                go.gameObject.GetComponent<Image>().color = new Color32(r, g, b, 255);
                currentY += distanceBetweenGameObjects;
            }
        }
    }
}
