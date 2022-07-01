using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCheckingMatches : MonoBehaviour
{
    [SerializeField] private RectTransform firslLineStart;
    [SerializeField] private RectTransform secondLineStart;
    [SerializeField] private RectTransform thirdLineStart;

    [SerializeField] private RectTransform firslLineStart_vertical;
    [SerializeField] private RectTransform secondLineStart_vertical;
    [SerializeField] private RectTransform thirdLineStart_vertical;

    [SerializeField] private RectTransform diagonallyUpperLineStart;
    [SerializeField] private RectTransform diagonallyDownLineStart;
    [SerializeField] private LayerMask layer;
    private Vector3 _lineDirection;
    private Vector3 _lineDirection_vertical;
    private Vector3 _diagonallyDirectionToDown;
    private Vector3 _diagonallyDirectionToUp;

    [SerializeField] private GameObject Line_1_horizontal_panel;
    [SerializeField] private GameObject Line_2_horizontal_panel;
    [SerializeField] private GameObject Line_3_horizontal_panel;
    [SerializeField] private GameObject Line_1_vertical_panel;
    [SerializeField] private GameObject Line_2_vertical_panel;
    [SerializeField] private GameObject Line_3_vertical_panel;
    [SerializeField] private GameObject Line_down_diagonaly_panel;
    [SerializeField] private GameObject Line_upper_diagonaly_panel;

    [SerializeField] private List<GameObject> comboText;
    private bool IsCombo = false;
    private float _timer;
    void Start()
    {
        _lineDirection = transform.TransformDirection(Vector3.right);
        _lineDirection_vertical = transform.TransformDirection(Vector3.down);
        _diagonallyDirectionToUp = transform.TransformDirection(Vector3.right + Vector3.up);
        _diagonallyDirectionToDown = transform.TransformDirection(Vector3.right + Vector3.down);
    }

    private void Update()
    {
        if (IsCombo)
        {
            _timer += Time.deltaTime;
            if(_timer >= 3)
            {
                IsCombo = false;
                CloseCombo();
            }
        }
    }
    public void CheckingMatches(int activeSlotsCount)
    {
        if (activeSlotsCount >= 3 && activeSlotsCount < 6)
        {
            FirstlLineCheckMatch();
        }
        else if (activeSlotsCount >= 6 && activeSlotsCount < 7)
        {
            FirstlLineCheckMatch();
            SecondLineCheckMatch();
        }
        else if (activeSlotsCount >= 7 && activeSlotsCount < 8)
        {
            FirstlLineCheckMatch();
            SecondLineCheckMatch();
            FirstlLineCheckMatch_vertical();
            UpperDiagonallyCheckMatch();
        }
        else if (activeSlotsCount  >= 8 && activeSlotsCount < 9)
        {
            FirstlLineCheckMatch();
            SecondLineCheckMatch();
            FirstlLineCheckMatch_vertical();
            SecondLineCheckMatch_vertical();
            UpperDiagonallyCheckMatch();

        }
        else if (activeSlotsCount == 9)
        {
            FirstlLineCheckMatch();
            SecondLineCheckMatch();
            ThirdLineCheckMatch();

            FirstlLineCheckMatch_vertical();
            SecondLineCheckMatch_vertical();
            ThirdLineCheckMatch_vertical();

            UpperDiagonallyCheckMatch();
            DownDiagonallyCheckMatch();
        }
    }

    public bool FirstlLineCheckMatch()
    {

            RaycastHit2D[] hit;
            hit = Physics2D.RaycastAll(firslLineStart.transform.position, _lineDirection, 7, layer);
            if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
                hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
                hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
            {
                Debug.Log("First line Match 3");
                Line_1_horizontal_panel.SetActive(true);
            OpenComboTExt();
                return true;
            }
            else
            {
                Debug.Log("NOT Match");
                return false;
            }
        
    }
    public bool SecondLineCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(secondLineStart.transform.position, _lineDirection, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line Match 3");
            Line_2_horizontal_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }
    public bool ThirdLineCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(thirdLineStart.transform.position, _lineDirection, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line Match 3");
            Line_3_horizontal_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }

    }
    public bool FirstlLineCheckMatch_vertical()
    {

        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(firslLineStart_vertical.transform.position, _lineDirection_vertical, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line vertical Match 3");
            Line_1_vertical_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }

    }
    public bool SecondLineCheckMatch_vertical()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(secondLineStart_vertical.transform.position, _lineDirection_vertical, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line vertical Match 3");
            Line_2_vertical_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }
    public bool ThirdLineCheckMatch_vertical()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(thirdLineStart_vertical.transform.position, _lineDirection_vertical, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line vertical Match 3");
            Line_3_vertical_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }

    }
    public bool UpperDiagonallyCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(diagonallyUpperLineStart.transform.position, _diagonallyDirectionToDown, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line Match 3");
            Line_upper_diagonaly_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }
    public bool DownDiagonallyCheckMatch()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(diagonallyDownLineStart.transform.position, _diagonallyDirectionToUp, 7, layer);
        if (hit[0].collider.GetComponent<Prize>()._Type == hit[1].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[1].collider.GetComponent<Prize>()._ElementType &&
            hit[0].collider.GetComponent<Prize>()._Type == hit[2].collider.GetComponent<Prize>()._Type &&
            hit[0].collider.GetComponent<Prize>()._ElementType == hit[2].collider.GetComponent<Prize>()._ElementType &&
                hit[0].collider.GetComponent<Prize>()._Type != Type.death)
        {
            Debug.Log("First line Match 3");
            Line_down_diagonaly_panel.SetActive(true);
            OpenComboTExt();
            return true;
        }
        else
        {
            Debug.Log("NOT Match");
            return false;
        }
    }

    public void CloseComboTExt()
    {
        foreach (var item in comboText)
        {
            item.SetActive(false);
        }
    }
    private void OpenComboTExt()
    {
        IsCombo = true;
        _timer = 0;
        foreach (var item in comboText)
        {
            item.SetActive(true);
        }
    }
    public void CloseCombo()
    {
        Line_1_horizontal_panel.SetActive(false);
        Line_2_horizontal_panel.SetActive(false);
        Line_3_horizontal_panel.SetActive(false);
        Line_1_vertical_panel.SetActive(false);
        Line_2_vertical_panel.SetActive(false);
        Line_3_vertical_panel.SetActive(false);
        Line_3_vertical_panel.SetActive(false);
        Line_down_diagonaly_panel.SetActive(false);
        Line_upper_diagonaly_panel.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        _lineDirection = transform.TransformDirection(Vector3.right) * 7;
        _lineDirection_vertical = transform.TransformDirection(Vector3.down) * 7;
        _diagonallyDirectionToUp = transform.TransformDirection(Vector3.right + Vector3.up) * 7;
        _diagonallyDirectionToDown = transform.TransformDirection(Vector3.right + Vector3.down) * 7;
        Gizmos.DrawRay(firslLineStart.transform.position, _lineDirection);
        Gizmos.DrawRay(secondLineStart.transform.position, _lineDirection);
        Gizmos.DrawRay(thirdLineStart.transform.position, _lineDirection);

        Gizmos.DrawRay(firslLineStart_vertical.transform.position, _lineDirection_vertical);
        Gizmos.DrawRay(secondLineStart_vertical.transform.position, _lineDirection_vertical);
        Gizmos.DrawRay(thirdLineStart_vertical.transform.position, _lineDirection_vertical);

        Gizmos.DrawRay(diagonallyUpperLineStart.transform.position, _diagonallyDirectionToDown);
        Gizmos.DrawRay(diagonallyDownLineStart.transform.position, _diagonallyDirectionToUp);
    
    }
}
