using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWork : StateSuper<Miner>
{
    private static StateWork _instance = null;
    private StateWork() { }
    private StateWork(StateWork state) { }

    public static StateWork Instance()
    {
        if (_instance == null) _instance = new StateWork();
        return _instance;
    }
    public override void Enter(Miner t)
    {
        //위치전환
        t.SetLocation(MAGADATA.LocationType.WORK);

    }

    public override void Execute(Miner t)
    {
        t.Tired();
        t.MakeGold();
        if (t.FullGold()) t.GetStateMachine().ChangeState(StateBank.Instance());

    }

    public override void Exit(Miner t)
    {
    }
    public override bool OnMessage(Miner t, MAGADATA.Telegram tel)
    {
        return false;
    }
}
