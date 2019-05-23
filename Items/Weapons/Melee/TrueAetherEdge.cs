using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace DraconicMastery.Items.Weapons.Melee
{
    public class TrueAetherEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Aether Edge");
            Tooltip.SetDefault("Aetheric Judgement");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.width = 60;
            item.height = 70;
            item.knockBack = 7;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 7, 20, 0);
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
            item.melee = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("AetherBeam");
            item.shootSpeed = 12f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 480);
        }
    }
}
