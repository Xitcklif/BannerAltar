using Terraria.ModLoader;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ObjectData;
using BannerAltar.Content.Items.Placeable;

namespace BannerAltar.Content.Recipes
{
    public class BannerAltarRecipe : ModSystem
    {
        public static RecipeGroup BannerAltarRecipeGroup;

        public override void Unload()
        {
            BannerAltarRecipeGroup = null;
        }

        public override void AddRecipeGroups()
        {
            BannerAltarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<BannerAltarItem>())}",
                ModContent.ItemType<BannerAltarItem>(), ModContent.ItemType<BannerAltarItem>());

            RecipeGroup.RegisterGroup("BannerAltar:BannerAltarItem", BannerAltarRecipeGroup);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<BannerAltarItem>(), 1)
                .AddIngredient(ItemID.ShadewoodTable, 1)
                .AddIngredient(ItemID.HoneyChair, 2)
                .AddIngredient(ItemID.BirdBanner, 1)
                .AddIngredient(ItemID.BunnyBanner, 1)
                .AddIngredient(ItemID.GoldfishBanner, 1)

                .AddTile(TileID.DemonAltar)
                
                .Register();

            Recipe.Create(ModContent.ItemType<BannerAltarItem>(), 1)
                .AddIngredient(ItemID.EbonwoodTable, 1)
                .AddIngredient(ItemID.HoneyChair, 2)
                .AddIngredient(ItemID.BirdBanner, 1)
                .AddIngredient(ItemID.BunnyBanner, 1)
                .AddIngredient(ItemID.GoldfishBanner, 1)

                .AddTile(TileID.DemonAltar)
                
                .Register();
        }
    }
}