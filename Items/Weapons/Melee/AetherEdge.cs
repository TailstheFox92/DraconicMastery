using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DraconicMastery.Items.Weapons.Melee
{
	public class AetherEdge: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aether Edge");
			Tooltip.SetDefault("Give Burn");
		}
		public override void SetDefaults()
		{
			item.damage = 46;
			item.melee = true;
			item.width = 48;
			item.height = 58;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 480);
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BladeofGrass);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
