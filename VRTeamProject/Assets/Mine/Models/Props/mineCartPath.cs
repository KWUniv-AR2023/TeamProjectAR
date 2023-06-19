using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class PathObject
{
    public GameObject parent;
    public bool reverse;
}

public class mineCartPath : MonoBehaviour
{


    public GameObject obj;
    //public GameObject[] railObject;
    public List<PathObject> railObject = new List<PathObject>();
    public float speed;
    public float maxSpeed = 20;
    public float minSpeed = 10;
    public int startChild = 0;
    public float degree = 0;
    public bool speedAutoIncrement = true;

    private Vector3 actualPosition;
    public int currentRailParent = 0;
    public int currentRailChild = 0;
    
    public Vector3 offset = new Vector3(0,0,0);
    public bool AutoPositionSet = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(AutoPositionSet);

        if(currentRailChild == 0)
            currentRailChild = startChild;
        if(AutoPositionSet)
            obj.transform.position = CurrentPathObject.parent.transform.GetChild(currentRailChild).gameObject.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = obj.transform.position;

        PathObject CurPathObj = CurrentPathObject;
        PathObject NxtPathObj = NextPathObject;

        GameObject curRailParent = CurPathObj.parent;
        GameObject curRail = curRailParent.transform.GetChild(currentRailChild).gameObject;
        obj.transform.position = Vector3.MoveTowards(actualPosition, curRail.transform.position+offset,
            speed * Time.deltaTime);
        var q1 = curRail;
        var q2 = NextRailObject;
        var p1 = Vector3.Magnitude(q1.transform.position - q2.transform.position + offset);
        var pc = Vector3.Magnitude(q1.transform.position - obj.transform.position + offset);

        var high = q1.transform.position.y - q2.transform.position.y + offset.y;

        

        if(high > 0) // current is higher then next slot
        {
            if(speed < maxSpeed) speed += high * Time.deltaTime;
            if(maxSpeed <= speed) speed = maxSpeed;
        }
        else if(high < 0)
        {
            if(speed > minSpeed) speed += high * Time.deltaTime ;
            if(speed <= minSpeed) speed = minSpeed;
        }
        if(speedAutoIncrement) speed += 0.000001f;

        var rot = Quaternion.Slerp(q2.transform.rotation, q1.transform.rotation, pc / p1);

        obj.transform.rotation = rot;
        obj.transform.Rotate(new Vector3(0, degree, 0));

        if (actualPosition == curRail.transform.position + offset)
        {
            if (CurPathObj.reverse) currentRailChild--;
            else currentRailChild++;
        }
        if (CurPathObj.reverse)
        {
            if (currentRailChild < 0)
            {
                currentRailParent++;
                currentRailChild = NxtPathObj.reverse ? NxtPathObj.parent.transform.childCount - 1 : 0;
            }
        }
        else
        {
            if ( curRailParent.transform.childCount <= currentRailChild )
            {
                currentRailParent++;
                currentRailChild = NxtPathObj.reverse ? NxtPathObj.parent.transform.childCount - 1 : 0;
            }
        }

        if (railObject.Count <= currentRailParent)
        {
            currentRailParent = 0;
        }
    }

    public GameObject GetCurrentPathObject()
    {
        return CurrentPathObject.parent;
    }

    PathObject CurrentPathObject
    {
        get => railObject[currentRailParent];
    }

    PathObject NextPathObject
    {
        get => railObject[(currentRailParent + 1) % railObject.Count];
    }

    PathObject PrevPathObject
    {
        get => railObject[(currentRailChild - 1) % railObject.Count];
    }

    public GameObject GetCurrentRailObject()
    {
        return CurrentRailObject;
    }

    GameObject CurrentRailObject
    {
        get => CurrentPathObject.parent.transform.GetChild(currentRailChild).gameObject;
    }



    GameObject FirstRailObject(PathObject obj)
    {
        if (obj.reverse) return obj.parent.transform.GetChild(obj.parent.transform.childCount - 1).gameObject;
        else return obj.parent.transform.GetChild(0).gameObject;
    }

    GameObject NextRailObject
    {
        get
        {
            var cpo = CurrentPathObject.parent;
            if(CurrentPathObject.reverse)
            {
                if(currentRailChild - 1 < 0)
                    return FirstRailObject(NextPathObject);
                return cpo.transform.GetChild(currentRailChild - 1).gameObject;
            }
            else
            {
                if (cpo.transform.childCount <= currentRailChild + 1)
                    return FirstRailObject(NextPathObject);
                return cpo.transform.GetChild(currentRailChild + 1).gameObject;
            }
        }
    }

    GameObject PrevRailObject
    {
        get
        {
            var cpo = CurrentPathObject.parent;
            if (CurrentPathObject.reverse)
            {
                if (cpo.transform.childCount <= currentRailChild + 1)
                    return FirstRailObject(PrevPathObject).gameObject;
                else return cpo.transform.GetChild(currentRailChild + 1).gameObject;
            }
            else
            {
                if(currentRailChild - 1 < 0)
                    return FirstRailObject(PrevPathObject);
                else return cpo.transform.GetChild(transform.childCount - 1).gameObject;
            }
        }
    }

}
