using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarCreator : MonoBehaviour, IPointerDownHandler
{
    public GameManager myGameManager;

    public GameObject ConcreteBar;
    public GameObject BrickBar;
    public GameObject WoodBar;
    public GameObject SteelBar;

    bool BarCreationStarted = false;

    public Bar CurrentBar;

    public GameObject BarToInstantiate;
    public Transform barParent;
    public GameObject PointToInstantiate;
    public Transform PointParent;

    public Points CurrentStartPoint;
    public Points CurrentEndPoint;


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
                if (myGameManager.CanPlaceItem(CurrentBar.actualCost))
                {
                    FinishBarCreation();
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
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
        if (GameManager.AllPoints.ContainsKey(CurrentEndPoint.transform.position))
        {
            Destroy(CurrentEndPoint.gameObject);
            CurrentEndPoint = GameManager.AllPoints[CurrentEndPoint.transform.position];
        }
        else
        {
            GameManager.AllPoints.Add(CurrentEndPoint.transform.position, CurrentEndPoint);
        }

        CurrentStartPoint.ConnectedBars.Add(CurrentBar);
        CurrentEndPoint.ConnectedBars.Add(CurrentBar);

        CurrentBar.StartJoint.connectedBody = CurrentStartPoint.rbd;
        CurrentBar.StartJoint.anchor = CurrentBar.transform.InverseTransformPoint(CurrentBar.StartPosition);
        CurrentBar.EndJoint.connectedBody = CurrentEndPoint.rbd;
        CurrentBar.EndJoint.anchor = CurrentBar.transform.InverseTransformPoint(CurrentEndPoint.transform.position);

        myGameManager.UpdateBudget(CurrentBar.actualCost);

        StartBarCreation(CurrentEndPoint.transform.position);
    }

    private void StartBarCreation(Vector2 StartPosition)
    {
        CurrentBar = Instantiate(BarToInstantiate, barParent).GetComponent<Bar>();
        CurrentBar.StartPosition = StartPosition;

        if (GameManager.AllPoints.ContainsKey(StartPosition))
        {
            CurrentStartPoint = GameManager.AllPoints[StartPosition];
        }
        else
        {
            CurrentStartPoint = Instantiate(PointToInstantiate, StartPosition, Quaternion.identity, PointParent)
                .GetComponent<Points>();
            GameManager.AllPoints.Add(StartPosition, CurrentStartPoint);
        }

        CurrentEndPoint = Instantiate(PointToInstantiate, StartPosition, Quaternion.identity, PointParent)
            .GetComponent<Points>();
    }

    // Update is called once per frame
    void Update()
    {

        if (BarCreationStarted == true)
        {
            Vector2 EndPosition = (Vector2)Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector2 Dir = EndPosition - CurrentBar.StartPosition;
            Vector2 ClampedPosition = CurrentBar.StartPosition + Vector2.ClampMagnitude(Dir, CurrentBar.maxLength);


            CurrentEndPoint.transform.position =
                (Vector2)Vector2Int.RoundToInt(
                    ClampedPosition); //FloorToInt is prefered however it causes some problem with unsymetric world
            CurrentEndPoint.PointID = CurrentEndPoint.transform.position;
            CurrentBar.UpdateCreatingBar(CurrentEndPoint.transform.position);
        }
    }
}