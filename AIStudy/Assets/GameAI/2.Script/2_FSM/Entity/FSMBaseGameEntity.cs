using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMBaseGameEntity : MonoBehaviour {
    [SerializeField]
    int iID;
    static int iNextValidID;


    public virtual void INIT(int id)
    {
        SetID(id);
    }
    public virtual void EntityUpdate()
    { }
    

    void SetID(int id)
    {
        iID = id;
    }
    public int GetID(){return  iID;}

    public abstract bool HandleMessage(MAGADATA.Telegram msg);
}
