using System.Collections;
using System.Collections.Generic;
using THClimbTower;

[Card(999)]
public class TestCard : AbstractPlayerCard
{
    public override void CardLogic(AbstractCharactor reciver)
    {
        UnityEngine.Debug.Log("From Hotfix Card");
    }
}
