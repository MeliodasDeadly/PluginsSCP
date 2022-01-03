using Synapse.Translation;
using System.ComponentModel;

namespace TimerSynapse
{
    public class Translations : IPluginTranslation
    {

        public string YoullRes { get; set; } = "<color=#ffa31a>Your will respawn in:</color>";

        public string YoullBe { get; set; } = "<color=yellow>Your will be:</color>";

        public string NTF { get; set; } = "<color=blue>Nine-Tailed Fox</color>";

        public string CI { get; set; } = "<color=#004d00>Chaos Insurgency</color>";

        [Description("When there is multiple minute or second i will automatically add a 's' for ENGLISH and FRENCH ONLY")]
        public string Min { get; set; } = "Minute";
        public string Sec { get; set; } = "Second";

        public string And { get; set; } = "and";
        public bool AutoS { get; set; } = true;


    }
}
