﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using ValkyrieTools;

namespace Assets.Scripts.Content
{
    [TestClass]
    public class DictionaryI18nTest
    {
        private static DictionaryI18n sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Disble logger
            ValkyrieDebug.enabled = false;
            
            // Sample dictionary
            string[] file = new string[10]
                {DictionaryI18n.FFG_LANGS,
                "MONSTER_BYAKHEE_ATTACK_01,\"The byakhee dives at you, its leathery wings like scythes (; 2). If you pass, you narrowly duck the creature's strike. If you fail, you are whipped to the ground by a swooping blow; suffer 1 Damage and become Dazed.\",\"El byakhee se lanza en picado hacia ti con sus alas correosas similares a guadañas (; 2). Si superas la tirada, te agachas y esquivas por los pelos el ataque de la criatura. Si fallas la tirada, te derriba violentamente con un ataque de pasada; sufres 1 de Daño y adquieres el estado Desconcertado.\",\"Le Byakhee pique vers vous, ses ailes membraneuses déployées tels des faux ( ; 2). En cas de succès, vous évitez de justesse l'attaque de la créature. En cas d'échec, vous êtes fauché ; subissez 1 Dégât et devenez Sonné.\",Mit messerscharfen Schwingen stürzt der Byakhee auf dich zu (; 2). Bei Erfolg kannst du dich im letzten Moment abrollen. Bei Misserfolg wirst du von den Beinen gerissen; du erleidest 1 Schaden und du wirst benommen.,\"La creatura si tuffa verso di te, agitando le sue ali membranose come falci (: 2). Se hai successo, schivi il colpo della creatura chinandoti. Se fallisci, vieni scagliato a terra da un ampio fendente; subisci 1 danno e diventa frastornato.\",\"O byakhee mergulha em sua direção, e você vê as asas coriáceas em forma de gadanhas (; 2). Se passar, você se esquiva por pouco do ataque da criatura. Se falhar, as asas açoitam no golpe rasante, e você vai ao chão; sofra 1 Dano e fique Desnorteado.\",\"Byakhee nurkuje na ciebie, jego skórzaste skrzydła tną jak kosy (; 2). Jeśli zdałeś, w ostatniej chwili padasz na ziemię. Jeśli nie zdałeś, zostajesz powalony siłą uderzenia; przyjmujesz 1 kartę Obrażenia i otrzymujesz stan Oszołomiony.\",ビヤーキーは君に飛びかかった。皮のような翼はまるで鎌のようだ(; 2)。成功：そいつの攻撃をギリギリかわした。 失敗：その急襲を受け、地面にもんどりうって倒れた。；ダメージカードを１枚得て、放心状態になる。,拜亞基向你衝來，張開它如同鐮刀般的堅韌翅膀（；2）。如果檢定成功，你勉強躲過了那隻生物的襲擊。如果檢定失敗，你被猛烈的衝擊打倒在地；受到1點傷害并進入眩暈狀態。",
                "ATTACK_FIREARM_VS_SPIRIT_03,\"You fire at the specter. It does not work. Instead, you focus your mind and scream at it, \"\"Get out!\"\" (+1). The monster suffers damage equal to your test result.\",Disparas al espectro. No sirve de nada. Decides cambiar de estrategia; te concentras y exhortas a la aparición a que se marche (+1). El monstruo sufre tanto Daño como el resultado de tu tirada.,\"Vous tirez sur le spectre, en pure perte. Vous décidez alors de vous concentrer et de hurler : « Fiche le camp ! » (+1). Le monstre subit des dégâts égaux au résultat de votre test.\",\"Du feuerst auf das Gespenst. Als es nicht reagiert, konzentrierst du dich und schreist: „Weiche!“ (+1). Das Monster erleidet Schaden in Höhe deines Probenergebnisses.\",\"Apri il fuoco contro lo spettro ma i colpi non hanno nessun effetto, quindi cerchi di concentrarti sulla creatura urlandole di sparire (+1). Il mostro subisce danni pari al risultato della tua prova.\",\"Você atira contra o espectro. Nada acontece. Em vez disso, você concentra sua mente e grita: “Saia daqui!” (+1). O monstro sofre dano igual ao resultado do seu teste.\",\"Strzelasz do widma. To nie działa. Zamiast tego koncentrujesz się i krzyczysz w jego kierunku, „Przepadnij!” (+1). Potwór przyjmuje obrażenia równe wynikowi twojego testu.\",君はその霊を撃ったが、まるで効果はなかった。そこで君は、精神を集中して、「悪霊退散！」と叫んだ(+1)。；モンスターは、この判定の成功数に等しいダメージを受ける。,你向鬼魂開槍，但是並不起作用。於是，你全神貫注地朝它大喊道：“走開！”（+1）。怪物受到等同於檢定結果的傷害",
                "MONSTER_THRALL_MOVE_01,The {0} moves 2 spaces toward the nearest investigator. Then it attacks the investigator in its space with the highest .,,,Das Monster „{0}“ bewegt sich um 2 Felder auf den nächsten Ermittler zu. Dann greift es den Ermittler mit der höchsten  auf seinem Feld an.,,,\"{0} przemieszcza się o 2 pola w kierunku najbliższego badacza. Następnie atakuje tego badacza na swoim polu, który ma największą .\"",
                "PARAMETER,parameter,parametro,,,,,",
                "CUTSCENE_1_PROLOGUE,\"Your adventure begins with a note shoved under your door. Scrawled in large, unpracticed letters: \\n\\n[i]Hey stupid heroes! \\n\\nEverything is terrible! The Lair of All Goblins has been overrun by wicked things that dumb heroes like you always fight. You must come here, beat them up, and break their things to stop the unthinkable: the end of all goblins! You obviously don’t know where the Lair of All Goblins is, so I drew a map. Don’t lose it!\\n\\nYour fearsome master, \\n\\nSplig\\n\\n[/i]The map is rough but legible, leading to a place you clearly recognize as the Parigreth ruins. Having nothing better to do, you gather your gear and depart.\"",
                "event1.text,parameter,parametro,,,,,",
                "event1.button,parameter,parametro,,,,,",
                "event2.text,parameter,parametro,,,,,",
                "event12.text,parameter,parametro,,,,,"
                };

            sut = new DictionaryI18n(file, DictionaryI18n.DEFAULT_LANG, DictionaryI18n.DEFAULT_LANG);
        }

        [TestInitialize]
        public void TestInitialize_setDefaultLang()
        {
            sut.setCurrentLanguage(DictionaryI18n.DEFAULT_LANG);
        }

        [TestMethod]
        public void TestByakhee()
        {
            EntryI18n value;
            sut.tryGetValue("MONSTER_BYAKHEE_ATTACK_01", out value);
            Assert.IsNotNull(value.getCurrentOrDefaultLanguageString());
        }

        [TestMethod]
        public void TestDobleQuoted()
        {
            EntryI18n value;
            sut.tryGetValue("ATTACK_FIREARM_VS_SPIRIT_03", out value);
            Assert.IsNotNull(value.getCurrentOrDefaultLanguageString());
        }

        [TestMethod]
        public void TestThrallMove()
        {
            EntryI18n value;
            sut.tryGetValue("MONSTER_THRALL_MOVE_01", out value);
            Assert.IsNotNull(value.getCurrentOrDefaultLanguageString());
        }

        [TestMethod]
        public void TestNewLineScreenValue_containsNewLine()
        {
            EntryI18n value;
            sut.tryGetValue("CUTSCENE_1_PROLOGUE", out value);
            System.Diagnostics.Debug.WriteLine(value.getCurrentOrDefaultLanguageString());
            Assert.IsTrue(value.getCurrentOrDefaultLanguageString().Contains("\n"));
        }

        [TestMethod]
        public void TestNewLineInternalValue_DoesntContainsNewLine()
        {
            EntryI18n value;
            sut.tryGetValue("CUTSCENE_1_PROLOGUE", out value);
            System.Diagnostics.Debug.WriteLine(value.ToString());
            Assert.IsFalse(value.ToString().Contains(System.Environment.NewLine));
        }

        [TestMethod]
        public void TestSerializeMultipleFiles(){

            Dictionary <string,List<string>> dictMultipleSerialization = sut.SerializeMultiple();
            Assert.IsTrue(dictMultipleSerialization.Keys.Count == 9);
        }

        [TestMethod]
        public void TestSerializeMultipleFiles_EnglishSpanish()
        {
            // Sample dictionary
            string[] fileEnglishSpanish = new string[6]
                {DictionaryI18n.FFG_LANGS,
                "MONSTER_BYAKHEE_ATTACK_01,\"The byakhee dives at you, its leathery wings like scythes (; 2). If you pass, you narrowly duck the creature's strike. If you fail, you are whipped to the ground by a swooping blow; suffer 1 Damage and become Dazed.\",\"El byakhee se lanza en picado hacia ti con sus alas correosas similares a guadañas (; 2). Si superas la tirada, te agachas y esquivas por los pelos el ataque de la criatura. Si fallas la tirada, te derriba violentamente con un ataque de pasada; sufres 1 de Daño y adquieres el estado Desconcertado.\"",
                "ATTACK_FIREARM_VS_SPIRIT_03,\"You fire at the specter. It does not work. Instead, you focus your mind and scream at it, \"\"Get out!\"\" (+1). The monster suffers damage equal to your test result.\",Disparas al espectro. No sirve de nada. Decides cambiar de estrategia; te concentras y exhortas a la aparición a que se marche (+1). El monstruo sufre tanto Daño como el resultado de tu tirada.",
                "MONSTER_THRALL_MOVE_01,The {0} moves 2 spaces toward the nearest investigator. Then it attacks the investigator in its space with the highest .,",
                "PARAMETER,parameter,parametro,,,,,",
                "CUTSCENE_1_PROLOGUE,\"Your adventure begins with a note shoved under your door. Scrawled in large, unpracticed letters: \\n\\n[i]Hey stupid heroes! \\n\\nEverything is terrible! The Lair of All Goblins has been overrun by wicked things that dumb heroes like you always fight. You must come here, beat them up, and break their things to stop the unthinkable: the end of all goblins! You obviously don’t know where the Lair of All Goblins is, so I drew a map. Don’t lose it!\\n\\nYour fearsome master, \\n\\nSplig\\n\\n[/i]The map is rough but legible, leading to a place you clearly recognize as the Parigreth ruins. Having nothing better to do, you gather your gear and depart.\""};

            DictionaryI18n newSut = new DictionaryI18n(fileEnglishSpanish, DictionaryI18n.DEFAULT_LANG, DictionaryI18n.DEFAULT_LANG);

            Dictionary<string, List<string>> dictMultipleSerialization = newSut.SerializeMultiple();

            Assert.IsTrue(dictMultipleSerialization.Keys.Count == 2);
        }

        [TestMethod]
        public void TestSerializedDictionariesJoinsCorrectly()
        {
            Dictionary<string,List<string>> dictionaries = sut.SerializeMultiple();

            DictionaryI18n partialLocalizationDict;
            DictionaryI18n localizationDict = null;

            foreach (string language in dictionaries.Keys)
            {
                partialLocalizationDict = new DictionaryI18n(dictionaries[language].ToArray(), language, language);

                if (localizationDict == null)
                {
                    localizationDict = partialLocalizationDict;
                }
                else
                {
                    localizationDict.AddRaw(partialLocalizationDict);
                }
            }

            sut.setDefaultLanguage(DictionaryI18n.DEFAULT_LANG);
            localizationDict.setDefaultLanguage(DictionaryI18n.DEFAULT_LANG);
            sut.flushRaw();
            localizationDict.flushRaw();
            // Compare languages
            for (int langPos = 0; langPos < localizationDict.getLanguages().Length; langPos++)
            {
                if (localizationDict.getLanguages()[langPos] != sut.getLanguages()[langPos])
                {
                    Assert.Fail(new StringBuilder()
                        .Append("Languages position don't match: Position:")
                        .Append(langPos)
                        .Append(" SourceLang:")
                        .Append(sut.getLanguages()[langPos])
                        .Append(" TargetLang:")
                        .Append(localizationDict.getLanguages()[langPos])
                        .ToString());
                }

                sut.setCurrentLanguage(localizationDict.getLanguages()[langPos]);
                localizationDict.setCurrentLanguage(localizationDict.getLanguages()[langPos]);

            }
        }

        [TestMethod]
        public void TestRemovePrefix()
        {
            sut.RemoveKeyPrefix("event2");

            Assert.IsNotNull(sut);
        }
    }
}