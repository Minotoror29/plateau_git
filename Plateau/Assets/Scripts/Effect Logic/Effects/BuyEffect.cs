using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEffect : Effect
{
    private int _merchandiseToReveal;
    private int _merchandiseToBuy;

    public BuyEffect(TableManager tableManager, TileState state, string description, int merchandiseToReveal, int merchandiseToBuy) : base(tableManager, state, description)
    {
        _merchandiseToReveal = merchandiseToReveal;
        _merchandiseToBuy = merchandiseToBuy;
    }

    public override void Activate()
    {
        TableManager.BuyMerchandiseDisplay.gameObject.SetActive(true);
        TableManager.BuyMerchandiseDisplay.SetAbility(this);
        TableManager.BuyMerchandiseDisplay.SetArtifacts(_merchandiseToReveal);
    }

    public void Confirm(int boughtArtifacts)
    {
        TableManager.BuyMerchandiseDisplay.gameObject.SetActive(false);

        if (boughtArtifacts >= _merchandiseToBuy)
        {
            State.FlipTile();
        }

        if (TableManager.Player.Artifacts.Count > TableManager.Player.MaximumArtifacts)
        {
            TableManager.CurrentState.ChangeSubstate(new TableDiscardArtifactSubstate(TableManager, TableManager.Player.Artifacts.Count - TableManager.Player.MaximumArtifacts, this));
        }
        else
        {
            ResolveEffect();
        }
    }
}
