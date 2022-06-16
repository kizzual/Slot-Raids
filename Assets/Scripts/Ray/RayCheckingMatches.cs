using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheckingMatches : MonoBehaviour
{
    [SerializeField] private RectTransform firslLineStart;
    [SerializeField] private RectTransform secondLineStart;
    [SerializeField] private RectTransform thirdLineStart;
    [SerializeField] private RectTransform diagonallyUpperLineStart;
    [SerializeField] private RectTransform diagonallyDownLineStart;
    [SerializeField] private LayerMask layer;
    private Vector3 _lineDirection;
    private Vector3 _diagonallyDirectionToDown;
    private Vector3 _diagonallyDirectionToUp;


    void Start()
    {
        _lineDirection = transform.TransformDirection(Vector3.right);
        _diagonallyDirectionToUp = transform.TransformDirection(Vector3.right + Vector3.up);
        _diagonallyDirectionToDown = transform.TransformDirection(Vector3.right + Vector3.down);
    }


    void Update()
    {
        
    }

    public void CheckingMatches(int activeSlotsCount)
    {
        if (activeSlotsCount == 2)
        {
            FirstlLineCheckMatch();
        }
        else if (activeSlotsCount >= 3 && activeSlotsCount < 6)
        {
            FirstlLineCheckMatch(true);
        }
        else if (activeSlotsCount >= 6 && activeSlotsCount < 9)
        {
            FirstlLineCheckMatch(true);
            SecondLineCheckMatch();
        }
        else if (activeSlotsCount == 9)
        {
            FirstlLineCheckMatch(true);
            SecondLineCheckMatch();
            ThirdLineCheckMatch();
            UpperDiagonallyCheckMatch();
            DownDiagonallyCheckMatch();
        }
    }

    private bool FirstlLineCheckMatch(bool FullLineOpened = false)
    {
        if(!FullLineOpened)
        {
            RaycastHit2D[] hit;
            hit = Physics2D.RaycastAll(firslLineStart.transform.position, _lineDirection, 7, layer);
            Debug.Log(hit.Length);
            if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
               hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType)
            {
                Debug.Log("First line Match 2");
                return true;
            }
            else
            {
                Debug.Log("NOT Match");
                return false;
            }

        }
        else
        {
            RaycastHit2D[] hit;
            hit = Physics2D.RaycastAll(firslLineStart.transform.position, _lineDirection, 7, layer);
            if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
                hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
                hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType)
            {
                Debug.Log("First line Match 3");
                return true;
            }
            else
            {
                Debug.Log("NOT Match");
                return false;
            }
        }
    }
    private bool SecondLineCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(secondLineStart.transform.position, _lineDirection, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType)
        {
            Debug.Log("First line Match 3");
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }
    private bool ThirdLineCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(thirdLineStart.transform.position, _lineDirection, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType)
        {
            Debug.Log("First line Match 3");
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }

    }
    private bool UpperDiagonallyCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(diagonallyUpperLineStart.transform.position, _diagonallyDirectionToDown, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType)
        {
            Debug.Log("First line Match 3");
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }
    private bool DownDiagonallyCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(diagonallyDownLineStart.transform.position, _diagonallyDirectionToUp, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType)
        {
            Debug.Log("First line Match 3");
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        _lineDirection = transform.TransformDirection(Vector3.right) * 7;
        _diagonallyDirectionToUp = transform.TransformDirection(Vector3.right + Vector3.up) * 7;
        _diagonallyDirectionToDown = transform.TransformDirection(Vector3.right + Vector3.down) * 7;
        Gizmos.DrawRay(firslLineStart.transform.position, _lineDirection);
        Gizmos.DrawRay(secondLineStart.transform.position, _lineDirection);
        Gizmos.DrawRay(thirdLineStart.transform.position, _lineDirection);
        Gizmos.DrawRay(diagonallyUpperLineStart.transform.position, _diagonallyDirectionToDown);
        Gizmos.DrawRay(diagonallyDownLineStart.transform.position, _diagonallyDirectionToUp);
    
    }
}
