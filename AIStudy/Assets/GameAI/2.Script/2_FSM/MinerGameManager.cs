using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerGameManager : MonoBehaviour
{

    List<Miner> mMinerList;
    private void Start()
    {
        mMinerList = new List<Miner>();
        mMinerList.Add(new Miner(10));
        GetMinerListID();
    }
    private void Update()
    {

    }

    void GetMinerListID()
    {
        if (mMinerList!=null)
        {
            foreach (var item in mMinerList)
            {
                Debug.Log("ID=" + item.GetID());
            }
        }
    }
}
