using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBank : StateSuper<Miner>
{
    private static StateBank _instance=null;
    private StateBank() { }
    private StateBank(StateBank state) { }
 
    public static StateBank Instance()
    {
        if(_instance==null) _instance = new StateBank(); 
        return _instance;
    }

    public override void Enter(Miner t)
    {
        //위치전환
        t.SetLocation(MAGADATA.LocationType.BANK);

    }

    public override void Execute(Miner t)
    {
        t.SavingMoney();

    }

    public override void Exit(Miner t)
    {
    }
}
