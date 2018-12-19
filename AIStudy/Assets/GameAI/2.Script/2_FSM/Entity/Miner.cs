using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : FSMBaseGameEntity
{
    // State
    StateMachine<Miner> mStateMachine;
    // Data
    public int iGold;
    public int iThirst;
    public int iTired;
    public int iBankMoney;
    public MAGADATA.LocationType eLocation;
    float Turn=1;

    public override void INIT(int id)
    {
        base.INIT(id);
        iGold = 0;
        iThirst = 10;
        iTired = 10;
        iBankMoney = 0;
        eLocation = MAGADATA.LocationType.HOME;
        mStateMachine = new StateMachine<Miner>(this);
        mStateMachine.SetCurrentState(StateHome.Instance());
        mStateMachine.SetGlobalState(StateGlobal.Instance());
    }

    private void Start()
    {
        INIT(1);
    }
    private void Update()
    {
        EntityUpdate();
    }
    public override void EntityUpdate()
    {
        Turn -= Time.deltaTime;
        if (Turn < 0)
        {
            base.EntityUpdate();
            Thirsty();
            mStateMachine.UPDATE();
            Turn = 1;
        }
    }


    // DataUpdate
    public void Thirsty() { iThirst--; }
    public void Tired() { iTired--; }
    public void MakeGold() { iGold++; }
    public void Recovery() { iTired+=2; }
    public void SavingMoney() { iBankMoney += iGold;iGold = 0; }
    public void GoBar() { iThirst+=3; }
    public bool PayBar() { if (iBankMoney > 0) { iBankMoney--; return true; } else return false; }
    public void SetLocation(MAGADATA.LocationType o) { eLocation = o; }

    //Get
    public int GetGold() { return iGold; }
    public int GetThirst() { return iThirst; }
    public int GetTired() { return iTired; }
    public int GetBankMoney() { return iBankMoney; }

    public StateMachine<Miner> GetStateMachine() { return mStateMachine; }
    // DataCheck
    public bool FullGold() { return iGold > 5 ? true : false; }
    public bool FullThirsty() { return iThirst > 8 ? true : false; }
    
    public bool AllRecovery() { return iTired>=10 ? true : false; }
    public bool ThrstyToBar() { return iThirst <= 1 ? true : false; }
    public bool TiredtoHome() { return iTired <= 1 ? true : false; }

    public override bool HandleMessage(MAGADATA.Telegram msg)
    {
        return mStateMachine.HandleMessage(msg);
    }
}
