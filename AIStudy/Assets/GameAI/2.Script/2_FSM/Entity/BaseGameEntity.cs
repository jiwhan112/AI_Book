using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameEntity : MonoBehaviour {

    int iID;
    static int iNextValidID;

    public BaseGameEntity(int ID)
    {
        SetID(ID);
    }

    public virtual void EntityUpdate()
    { }
    

    void SetID(int id)
    {
        iID = id;
    }
    public int GetID(){return  iID;}

}
