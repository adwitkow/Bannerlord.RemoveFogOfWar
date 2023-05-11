using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace Bannerlord.RemoveFogOfWar
{
    internal class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => "RemoveFogOfWarSettings1.0";

        public override string DisplayName => "Remove Fog of War";

        public override string FolderName => "RemoveFogOfWar";

        public override string FormatType => "json2";

        [SettingPropertyBool("{=0mDkVTWn}Heroes", RequireRestart = false)]
        public bool EnableForHeroes { get; set; } = true;

        [SettingPropertyBool("{=jpBpwgAs}Settlements", RequireRestart = false)]
        public bool EnableForFiefs { get; set; } = true;
    }
}
