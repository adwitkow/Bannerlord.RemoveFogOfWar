using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Settlements;

namespace Bannerlord.RemoveFogOfWar.Models;

internal class NoFogOfWarInformationRestrictionModel : InformationRestrictionModel
{
    public override bool DoesPlayerKnowDetailsOf(Settlement settlement)
    {
        if (Settings.Instance.EnableForFiefs)
        {
            return true;
        }

        return BaseModel.DoesPlayerKnowDetailsOf(settlement);
    }

    public override bool DoesPlayerKnowDetailsOf(Hero hero)
    {
        if (Settings.Instance.EnableForHeroes)
        {
            return true;
        }

        return BaseModel.DoesPlayerKnowDetailsOf(hero);
    }
}
