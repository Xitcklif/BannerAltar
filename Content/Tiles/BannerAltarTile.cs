using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.Audio;
using Terraria.GameContent.ObjectInteractions;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;

using log4net.Repository.Hierarchy;

using BannerAltar.Content.Items.Placeable;
using BannerAltar.Content.Tiles;
using BannerAltar;

namespace BannerAltar.Content.Tiles
{
    public class BannerAltarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileContainer[Type] = true;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(1, 2);
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(GetInstance<BannerAltarTileEntity>().Hook_AfterPlacement, -1, 0, true);

            TileID.Sets.IsAContainer[Type] = true;

            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<BannerAltarItem>();
        }

        public override bool RightClick(int i, int j)
        {
            Mod bannerBonanza = null;

            try
            {
                bannerBonanza = ModLoader.GetMod("BannerBonanza");
            }
            catch (System.Collections.Generic.KeyNotFoundException e)
            {
                Main.NewText($"Mod Banner Bonanza wasn't found");
                return false;
            }

            Tile tile = Main.tile[i, j];
            int left = i - (tile.TileFrameX % 54 / 18);
            int top = j - (tile.TileFrameY / 18);

            if (ModContent.GetModTile(Main.tile[left, top + 4].TileType).FullName.Equals("BannerBonanza/BannerRackTile"))
            {
                ModContent.GetModTile(Main.tile[left, top + 4].TileType).RightClick(left, top + 4);
            }

            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            GetInstance<BannerAltarTileEntity>().Kill(i, j);
        }
    }
}