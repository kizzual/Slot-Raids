using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingObjects : MonoBehaviour
{
     public bool isActive;

    [Header("Scroll settings")]
    [SerializeField] private float scrollingDuration = 3f;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private List<Prize> prizeList;
    [SerializeField] private LayerMask layer;
   
    [HideInInspector] public bool _scrollingIsActive = false;
    [HideInInspector] public Prize winPrize;
    private RectTransform _point;
    private float _elapsedTime; 
    private float _percentageComplete;
    private int _indexCurrentObject = 0;
    private int randomIndex;

    void Start()
    {
        _point = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        Scrolling();
    }
    public void StartScrolling()
    {
        if(_indexCurrentObject == 0)
        {
            _elapsedTime = 0;
            randomIndex = Random.Range(40, 80);
            prizeList[randomIndex].gameObject.layer = 6;
            _scrollingIsActive = true;
        }
        else
        {
            SwapPositionAndShuffle();
            _elapsedTime = 0;
            randomIndex = Random.Range(40, 80);
            prizeList[randomIndex].gameObject.layer = 6;
            _scrollingIsActive = true;
        }
    }
    private void Scrolling()
    {
        if (_scrollingIsActive)
        {
            _elapsedTime += Time.fixedDeltaTime;
            _percentageComplete = _elapsedTime / scrollingDuration;
             
            _point.transform.localPosition = Vector3.Slerp(Vector3.zero, new Vector3(0, -prizeList[randomIndex].transform.localPosition.y, 0), curve.Evaluate(_percentageComplete));

            if (_percentageComplete > 1)
            {
                _scrollingIsActive = false;
                _point.transform.localPosition = new Vector3(0, -prizeList[randomIndex].transform.localPosition.y, 0);
                _indexCurrentObject = randomIndex;
            }
        }
    }
    private void ShuffleFullList(List<Prize> list)
    {
        System.Random rand = new System.Random();
        for (int i = list.Count - 1; i > 3; i--)
        {
            int j = Random.Range(2, list.Count - 1);

            Prize tmp = list[j];
            list[j] = list[i];
            list[i] = tmp;

            SwapPosition(list[i], list[j]);
        }
    }
    private void SwapPosition(Prize obj_1, Prize obj_2)
    {
        Vector3 tmp = obj_1.transform.localPosition;

        obj_1.SwitchPosition(obj_2.transform.localPosition);
        obj_2.SwitchPosition(tmp);
    }
    private void SwapPositionAndShuffle()
    {
        _point.transform.localPosition = Vector3.zero;
        SwapPosition(prizeList[0], prizeList[randomIndex]);
       
        Prize tmp = prizeList[0];
        prizeList[0] = prizeList[randomIndex];
        prizeList[randomIndex] = tmp;
        prizeList[0].gameObject.layer = 5;
        ShuffleFullList(prizeList);
    } 
    public void GenerateListObjects(List<Prize> _prizeList)
    {
        for (int i = 0; i < prizeList.Count; i++)
        {
            prizeList[i].TakeInfo(_prizeList[i]);
        }

         ShuffleFullList(prizeList);
    }
}
