using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAbility : Ability
{
    private int _merchandiseToReveal;
    private int _merchandiseToBuy;

    public BuyAbility(TableManager tableManager, TileState state, int merchandiseToReveal, int merchandiseToBuy) : base(tableManager, state)
    {
        _merchandiseToReveal = merchandiseToReveal;
        _merchandiseToBuy = merchandiseToBuy;
    }

    public override void Activate(Player player)
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

        ResolveAbility();
    }
}
