using Terraria.ModLoader;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using BannerAltar.Content.Currencies;
using BannerAltar.Content.Items.Placeable;
using BannerAltar.Content.Tiles;

namespace BannerAltar
{

    // TODO: Might need a message at end with a Recipe.FindRecipes(); call.
    enum BannerAltarMessageType : byte
    {
        RequestSuperBannerStealBanners,
        //	NotifySuperBannerStringOutOfDate,
    }

    public partial class BannerAltar : Mod
    {
        public const string AssetPath = $"{nameof(BannerAltar)}/Assets/";

        public static int BannerAltarCustomCurrencyId;
        public static bool aboveTheRack = false;

        public override void Load()
        {
            // Registers a new custom currency
            BannerAltarCustomCurrencyId = CustomCurrencyManager.RegisterCurrency(new BannerAltarCustomCurrency(ModContent.ItemType<BannerAltarItem>(), 1L, "BannerAltarCustomCurrency"));

            if (!ModLoader.TryGetMod("BannerBonanza", out _))
            {
                Logger.Error("BannerBonanza missing");
                throw new FileNotFoundException();
            }
        }

        public override void Unload()
        {
            // The Unload() methods can be used for unloading/disposing/clearing special objects, unsubscribing from events, or for undoing some of your mod's actions.
            // Be sure to always write unloading code when there is a chance of some of your mod's objects being kept present inside the vanilla assembly.
            // The most common reason for that to happen comes from using events, NOT counting On.* and IL.* code-injection namespaces.
            // If you subscribe to an event - be sure to eventually unsubscribe from it.

            // NOTE: When writing unload code - be sure use 'defensive programming'. Or, in other words, you should always assume that everything in the mod you're unloading might've not even been initialized yet.
            // NOTE: There is rarely a need to null-out values of static fields, since TML aims to completely dispose mod assemblies in-between mod reloads.
        }
    }
}