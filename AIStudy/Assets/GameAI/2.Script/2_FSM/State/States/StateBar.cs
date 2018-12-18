using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar : StateSuper<Miner>
{
    private static StateBar _instance = null;
    private StateBar() { }
    private StateBar(StateBar state) { }

    public static StateBar Instance()
    {
        if (_instance == null) _instance = new StateBar();
        return _instance;
    }

    public override void Enter(Miner t)
    {
        //위치전환
        t.SetLocation(MAGADATA.LocationType.BAR);

    }

    public override void Execute(Miner t)
    {
        t.GoBar();
        t.PayBar();
    }

    public override void Exit(Miner t)
    {
    }
}
