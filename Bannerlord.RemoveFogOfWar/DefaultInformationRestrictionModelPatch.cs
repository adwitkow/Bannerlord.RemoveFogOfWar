using HarmonyLib;
using HarmonyLib.BUTR.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace Bannerlord.RemoveFogOfWar
{
    static class DefaultInformationRestrictionModelPatch
    {
        public static void Apply(Harmony harmony)
        {
            var settlementMethodToPatch = AccessTools2.Method(typeof(DefaultInformationRestrictionModel),
                nameof(DefaultInformationRestrictionModel.DoesPlayerKnowDetailsOf),
                new[] { typeof(Settlement) });
            var heroMethodToPatch = AccessTools2.Method(typeof(DefaultInformationRestrictionModel),
                nameof(DefaultInformationRestrictionModel.DoesPlayerKnowDetailsOf),
                new[] { typeof(Hero) });
            var settlementPrefixMethod = AccessTools2.Method(typeof(DefaultInformationRestrictionModelPatch),
                nameof(DoesPlayerKnowDetailsOfSettlementPrefix));
            var heroPrefixMethod = AccessTools2.Method(typeof(DefaultInformationRestrictionModelPatch),
                nameof(DoesPlayerKnowDetailsOfHeroPrefix));

            harmony.TryPatch(settlementMethodToPatch, prefix: settlementPrefixMethod);
            harmony.TryPatch(heroMethodToPatch, prefix: heroPrefixMethod);
        }

        private static bool DoesPlayerKnowDetailsOfSettlementPrefix(ref bool __result)
        {
            if (Settings.Instance.EnableForFiefs)
            {
                __result = true;
                return false;
            }

            return true;
        }

        private static bool DoesPlayerKnowDetailsOfHeroPrefix(ref bool __result)
        {
            if (Settings.Instance.EnableForHeroes)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}
