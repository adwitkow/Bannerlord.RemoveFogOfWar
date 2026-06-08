using HarmonyLib;
using HarmonyLib.BUTR.Extensions;
using Helpers;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Bannerlord.RemoveFogOfWar.Patches;

public static class HeroHelperPatch
{
    public static void Apply(Harmony harmony)
    {
        var methodToPatch = AccessTools2.Method(typeof(HeroHelper),
            nameof(HeroHelper.GetLastSeenText));
        var prefixMethod = AccessTools2.Method(typeof(HeroHelperPatch),
            nameof(GetLastSeenTextPrefix));

        harmony.Patch(methodToPatch, prefix: prefixMethod);
    }

    private static bool GetLastSeenTextPrefix(ref TextObject __result, Hero hero)
    {
        if (Settings.Instance.EnableForHeroes)
        {
            var settlement = GetClosestSettlement(hero);
            var isInSettlement = settlement == hero.CurrentSettlement;

            var textObject = GameTexts.FindText("str_last_seen_encyclopedia_entry");
            textObject.SetTextVariable("SETTLEMENT", settlement.EncyclopediaLinkWithName);
            textObject.SetTextVariable("IS_IN_SETTLEMENT", isInSettlement ? 1 : 0);

            __result = textObject;

            return false;
        }

        return true;
    }

    private static Settlement? GetClosestSettlement(Hero hero)
    {
        return Settlement.All
            .OrderBy(settlement => settlement.Position.DistanceSquared(hero.GetCampaignPosition()))
            .FirstOrDefault();
    }
}
