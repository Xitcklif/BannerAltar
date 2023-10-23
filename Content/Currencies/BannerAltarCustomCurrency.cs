using Terraria.ModLoader;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BannerAltar.Content.Currencies
{
    public class BannerAltarCustomCurrency : CustomCurrencySingleCoin
    {
        public BannerAltarCustomCurrency(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
        {
            this.CurrencyTextKey = CurrencyTextKey;
            CurrencyTextColor = Color.BlueViolet;
        }
    }
}