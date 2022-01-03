using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using Synapse.Translation;

namespace TimerSynapse
{
    [PluginInformation(
        Name = "TimerSynapse",
        Author = "Antoniofo",
        Description = "Respawn Timer in Synapse",
        LoadPriority = 0,
        SynapseMajor = 2,
        SynapseMinor = 8,
        SynapsePatch = 1,
        Version = "v.2.1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [SynapseTranslation]
        public static SynapseTranslation<Translations> Translations { get; set; }

        public override void Load()
        {
            Server.Get.Events.Round.RoundStartEvent += OnRoundStart;
            Translations.AddTranslation(new Translations());
            Translations.AddTranslation(new Translations
            {
                And = "et",
                CI = "<color=#004d00>Insurgé du Chaos</color>",
                NTF = "<color=blue>Nine-Tailed Fox</color>",
                Min = "Minute",
                Sec = "seconde",
                YoullRes = "<color=#ffa31a>Vous allez respawn dans:</color>",
                YoullBe = "<color=yellow>Vous allez respawn en:</color>",
                AutoS = true

            }, "FRENCH");
            Translations.AddTranslation(new Translations
            {
                And = "und",
                CI = "<color=#004d00>Chaos-Aufstand</color>",
                NTF = "<color=blue>Nine-Tailed Fox</color>",
                Min = "Minuten",
                Sec = "Sekunde",
                YoullRes = "<color=#ffa31a>Du wirst wieder spawnen:</color>",
                YoullBe = "<color=yellow>Du wirst wieder spawnen:</color>",
                AutoS = false

            }, "GERMAN");
            base.Load();
        }

        CoroutineHandle TimerCoroutine;
        public void OnRoundStart()
        {
            if (TimerCoroutine.IsRunning)
            {
                Timing.KillCoroutines(TimerCoroutine);
            }
            TimerCoroutine = Timing.RunCoroutine(TimerShow());
        }

        private IEnumerator<float> TimerShow()
        {
            while (Round.Get.RoundIsActive) 
            {
                yield return Timing.WaitForSeconds(1);

                try
                {
                    int Res = (int)Math.Round(Map.Get.Round.NextRespawn);
                    string Text;
                    bool Boolean = Translations.ActiveTranslation.AutoS;
                    if (Res % 60 == 0)
                    {
                        Text = $"{Translations.ActiveTranslation.YoullRes} \n {Res / 60} {Translations.ActiveTranslation.Min}{(Res / 60 <= 1 && Boolean ? "" : "s")}";
                        if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 1)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.CI}";
                        }
                        else if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 2)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.NTF}";
                        }
                    }
                    else if (Res / 60 > 0)
                    {
                        Text = $"{Translations.ActiveTranslation.YoullRes} \n {(Res / 60)} {Translations.ActiveTranslation.Min}{(Res / 60 <= 1 && Boolean ? "" : "s")} {Translations.ActiveTranslation.And} { Res % 60} {Translations.ActiveTranslation.Sec}{(Res % 60 <= 1 && Boolean ? "" : "s")}";
                        if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 1)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.CI}";
                        }
                        else if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 2)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.NTF}";
                        }
                    }
                    else
                    {
                        Text = $"{Translations.ActiveTranslation.YoullRes} \n { Res % 60} {Translations.ActiveTranslation.Sec}{(Res % 60 <= 1 && Boolean ? "" : "s")}";
                        if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 1)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.CI}";
                        }
                        else if ((int)Respawning.RespawnManager.Singleton.NextKnownTeam == 2)
                        {
                            Text += "\n";
                            Text += $"{Translations.ActiveTranslation.YoullBe} {Translations.ActiveTranslation.NTF}";
                        }
                    }
                    foreach (Player player in RoleType.Spectator.GetPlayers())
                    {
                        player.GiveTextHint($"{Text}", 1.2f);
                    }
                }
                catch (Exception err)
                {
                    SynapseController.Server.Logger.Error($"Error: {err}");
                    continue;
                }
            }
        }
    }
}
