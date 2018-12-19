using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 각 Miner들을 관리하는 클래스
/// </summary>
public class MinerGameManager : Singleton<MinerGameManager>
{
    [SerializeField]
    Dictionary<int, Miner> mMinerMap;
    
    static int ID = 0;
    private void Start()
    {
        ID = 0;
        mMinerMap = new Dictionary<int, Miner>();
        for (int i = 0; i < 3; i++)
        {
            CreateMiner(i);
        }
    }

    private void Update()
    {
        foreach (var item in mMinerMap)
        {
            item.Value.EntityUpdate();
        }
    }
    // 생성
    void CreateMiner(int id)
    {
        GameObject s = new GameObject();
        s.transform.SetParent(this.transform);
        s.transform.position = Vector3.zero;
        s.AddComponent<Miner>();
        s.GetComponent<Miner>().INIT(id);
        mMinerMap.Add(id, s.GetComponent<Miner>());
    }
    // 삭제
    void RemoveMiner(int id)
    {
        Destroy(mMinerMap[id].gameObject);
        mMinerMap.Remove(id);        
    }
    // 특정 객체 반환
    public Miner GetMiner(int id)
    {
        return mMinerMap[id];
    }


}
