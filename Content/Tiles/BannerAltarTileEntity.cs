using log4net.Repository.Hierarchy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ModLoader.IO;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

using BannerAltar;
using BannerAltar.Content.Tiles;

namespace BannerAltar.Content.Tiles
{
    public class BannerAltarTileEntity : ModTileEntity
    {
        public override bool IsTileValidForEntity(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            return tile.HasTile && tile.TileType == TileType<BannerAltarTile>() && tile.TileFrameX % 54 == 0 && tile.TileFrameY == 0;
        }

        public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileSquare(Main.myPlayer, i + 1, j + 1, 4);
                NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type, 0f, 0, 0, 0);

                return -1;
            }

            int num = Place(i, j);
            return num;
        }

        public override void Update()
        {
            int i = this.Position.X;
            int j = this.Position.Y;

            Tile tile = Main.tile[i, j];
            int left = i - (tile.TileFrameX % 54 / 18);
            int top = j - (tile.TileFrameY / 18);

            if (ModContent.GetModTile(Main.tile[left, top + 4].TileType).FullName.Equals("BannerBonanza/BannerRackTile"))
            {
                BannerAltar.aboveTheRack = true;
            }
            else
            {
                BannerAltar.aboveTheRack = false;
            }

            if (BannerAltar.aboveTheRack)
            {
                ModContent.GetModTile(Main.tile[left, top + 4].TileType).NearbyEffects(left, top + 4, true);
            }
        }
    }
}