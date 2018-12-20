using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEntityManager : MonoBehaviour {

    public GameObject PreObject;
    public Text text;
    [SerializeField]    
    Dictionary<int, Vehicle> mVehicleMap;

    static int ID = 0;
    private void Start()
    {
        ID = 0;
        mVehicleMap = new Dictionary<int, Vehicle>();
        for (int i = 0; i < 1; i++)
        {
            CreateMiner(i);
        }
    }

    private void Update()
    {
        foreach (var item in mVehicleMap)
        {
            item.Value.UPDATE();
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 MousePos = Input.mousePosition;
            Vector2 ScreenToWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, 10));
            text.text =
                "MousePos:" + MousePos + "\n" +
            "ScreenToViewportPoint:" + ScreenToWorldPoint + "\n";
            foreach (var item in mVehicleMap)
            {
                item.Value.SetTarget(ScreenToWorldPoint);
            }
            
        }
    }
    // 생성
    void CreateMiner(int id)
    {
        GameObject s = Instantiate(PreObject);
        s.transform.SetParent(this.transform);
        s.transform.position = Vector3.zero;
        s.AddComponent<Vehicle>();
        s.GetComponent<Vehicle>().Active();
        s.SetActive(true);
        mVehicleMap.Add(id, s.GetComponent<Vehicle>());
    }
    // 삭제
    void RemoveMiner(int id)
    {
        Destroy(mVehicleMap[id].gameObject);
        mVehicleMap.Remove(id);
    }
    // 특정 객체 반환
    public Vehicle GetMiner(int id)
    {
        return mVehicleMap[id];
    }

}
