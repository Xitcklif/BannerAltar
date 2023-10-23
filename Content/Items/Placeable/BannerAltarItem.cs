using Terraria.ModLoader;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ObjectData;
using BannerAltar.Content.Tiles;

namespace BannerAltar.Content.Items.Placeable
{
    public class BannerAltarItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<BannerAltarTile>());
            Item.width = 38;
            Item.height = 42;

            /*The value of the item in copper coins. 
             * Item.buyPrice & Item.sellPrice are helper methods that returns 
             * costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
             */
            Item.value = Item.buyPrice(silver: 10);

            //Отображаемое имя
            Item.SetNameOverride("Banner altar");
        }
    }
}