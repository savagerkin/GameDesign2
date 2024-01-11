using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    bool BarCreationStarted = false;
    public Bar CurrentBar;
    public GameObject BarToInstantiate;
    public Transform barParent;
    public Points CurrentStartPoint;
    public Points CurrentEndPoint;
    public GameObject PointToInstantiate;
    public Transform PointParent;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (BarCreationStarted == false)
        {
            BarCreationStarted = true;
            StartBarCreation(Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(eventData.position)));
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                FinishBarCreation();
            }else if (eventData.button == PointerEventData.InputButton.Right)
            {
                BarCreationStarted = false;
                DeleteCurrentBar();
            }
        }
    }

    private void DeleteCurrentBar()
    {
        Destroy(CurrentBar.gameObject);
        if (CurrentStartPoint.ConnectedBars.Count == 0 && CurrentStartPoint.Runtime == true)
        {
            Destroy(CurrentStartPoint.gameObject);
        }
        if (CurrentEndPoint.ConnectedBars.Count == 0 && CurrentEndPoint.Runtime == true)
        {
            Destroy(CurrentEndPoint.gameObject);
        }
    }

    private void FinishBarCreation()
    {
        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);
        StartBarCreation(CurrentEndPoint.transform.position);
    }

    private void StartBarCreation(Vector2 StartPosition)
    {
        CurrentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>();
        CurrentBar.StartPosition = StartPosition;
        CurrentStartPoint = Instantiate(PointToInstantiate, StartPosition, Quaternion.identity, PointParent).GetComponent<Points>();
        CurrentEndPoint = Instantiate(PointToInstantiate, StartPosition, Quaternion.identity, PointParent).GetComponent<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BarCreationStarted == true)
        {
            CurrentEndPoint.transform.position = (Vector2)Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            CurrentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);
        }
    }
}
