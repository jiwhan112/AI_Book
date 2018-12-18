using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : BaseGameEntity
{
    // State
    StateMachine<Miner> mStateMachine;
    // Data
    int iGold;
    int iThirst;
    int iTired;
    int iBankMoney;
    MAGADATA.LocationType eLocation;
    float Turn=1;

    public Miner(int ID) : base(ID)
    {
        iGold=0;
         iThirst=10;
         iTired=0;
         iBankMoney=0;
        eLocation = MAGADATA.LocationType.HOME;
        mStateMachine = new StateMachine<Miner>(this);
        mStateMachine.SetCurrentState(StateHome.Instance());
        mStateMachine.SetGlobalState(null);
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
    public void Thirsty() { --iThirst; }
    public void Tired() { iTired++; }
    public void MakeGold() { iGold++; }
    public void Recovery() { iTired--; }
    public void SavingMoney() { iBankMoney += iGold;iGold = 0; }
    public void GoBar() { iThirst++; }
    public void PayBar() { iBankMoney--; }
    public void SetLocation(MAGADATA.LocationType o) { eLocation = o; }

    //Get
    public int GetGold() { return iGold; }
    public int GetThirst() { return iThirst; }
    public int GetTired() { return iTired; }
    public int GetBankMoney() { return iBankMoney; }

    // DataCheck
    public bool FullGold() { return iGold > 5 ? true : false; }
    public bool AllRecovery() { return iTired<=0 ? true : false; }
    public bool ThrstyToBar() { return iThirst <= 1 ? true : false; }

}
