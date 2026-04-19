using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace drinkgame.Models
{
    internal class GameModels
    {
    }

    [Preserve(AllMembers = true)]
    public class Player
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("challengesCompleted")]
        public int ChallengesCompleted { get; set; }

        [JsonPropertyName("challengesSkipped")]
        public int ChallengesSkipped { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Challenge
    {
        public string Text { get; set; }
        public int Difficulty { get; set; } // 1-5
    }

    public static class ChallengeData
    {
        public static List<Challenge> Challenges { get; } = new()
        {
            // ==================== DIFFICULTY 1 - SOFT (20 challenges) ====================
            new Challenge { Text = "Bea o gură dacă ai mai mult de 2 pisici", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă azi ai purtat ceva roșu", Difficulty = 1 },
            new Challenge { Text = "Complimentează pe persoana din stânga ta", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai ieșit din casă astazi", Difficulty = 1 },
            new Challenge { Text = "Spune o bancă cuiva din joc", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai visat ceva ciudat noaptea trecută", Difficulty = 1 },
            new Challenge { Text = "Fă o mimă și ceilalți ghicesc", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă azi ai mâncat ciocolată", Difficulty = 1 },
            new Challenge { Text = "Imită vocea unui celebru om politic", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai o tatuaj ascuns", Difficulty = 1 },
            new Challenge { Text = "Cântă 10 secunde din piesa ta preferată", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai fost vreodată într-un club", Difficulty = 1 },
            new Challenge { Text = "Spune un secret mic ceilalți jucători", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă portul pantofi confortabili e prioritatea ta", Difficulty = 1 },
            new Challenge { Text = "Fă o cursă de mâncat (fără mâini) cu ceilalți", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă azi ai folosit mai mult de 30 minute socialele", Difficulty = 1 },
            new Challenge { Text = "Descrie cineva din grup fără să spui numele", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai vorbit cu cineva nou săptămâna asta", Difficulty = 1 },
            new Challenge { Text = "Fă un accent din alta țară pentru următoarele 2 runde", Difficulty = 1 },
            new Challenge { Text = "Bea o gură dacă ai fost super productiv azi", Difficulty = 1 },

            // ==================== DIFFICULTY 2 - EASY (20 challenges) ====================
            new Challenge { Text = "Bea o gură pentru fiecare crush pe care l-ai avut", Difficulty = 2 },
            new Challenge { Text = "Spune cel mai cringe moment al tău din liceu", Difficulty = 2 },
            new Challenge { Text = "Imită mersul unui animal timp de 1 minut", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare limbă pe care o vorbești", Difficulty = 2 },
            new Challenge { Text = "Spune unei persoane ce ți-ar plăcea s-o schimbi la ea", Difficulty = 2 },
            new Challenge { Text = "Fă un selfie ciudat și pun-o in chat", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare fractura pe care ai avut-o", Difficulty = 2 },
            new Challenge { Text = "Dansează 30 de secunde fără muzică", Difficulty = 2 },
            new Challenge { Text = "Spune cel mai ciudat lucru pe care l-ai mâncat vreodată", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare tatuaj pe care ai vrea sa faci", Difficulty = 2 },
            new Challenge { Text = "Fă o legătură între doi jucători și zi de ce se potrivesc", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare sport pe care l-ai încercat", Difficulty = 2 },
            new Challenge { Text = "Spune-i cuiva din grup pe cine îl invidiezI cel mai mult", Difficulty = 2 },
            new Challenge { Text = "Imită persoana din dreapta ta timp de urmatoarea runda", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare țară pe care ai vizitat-o", Difficulty = 2 },
            new Challenge { Text = "Cântă cu vocea pe dos o bucată celebră", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare piercing pe care ai vrea", Difficulty = 2 },
            new Challenge { Text = "Spune cele 3 lucruri care te enervează cel mai mult", Difficulty = 2 },
            new Challenge { Text = "Fă o pană de curent și nimeni nu vorbește 1 minut", Difficulty = 2 },
            new Challenge { Text = "Bea o gură pentru fiecare Netflix show pe care l-ai terminat", Difficulty = 2 },

            // ==================== DIFFICULTY 3 - MEDIUM (20 challenges) ====================
            new Challenge { Text = "Bea o gură și du-te să faci 20 de flotări", Difficulty = 3 },
            new Challenge { Text = "Spune pe cine din grup ar trebui sa-si schimbe meseria", Difficulty = 3 },
            new Challenge { Text = "Imită o persoană celebră timp de 2 minute și lasă ceilalți să ghicească", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și cere permisiunea sa te săruti pe frunte pe cineva", Difficulty = 3 },
            new Challenge { Text = "Spune-i cuiva din grup cel mai neașteptat lucru despre tine", Difficulty = 3 },
            new Challenge { Text = "Fă un TikTok dans și trimite-l grupului", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și zile cuiva ca i-ar plăcea mai mult dacă ar fi mai încredut", Difficulty = 3 },
            new Challenge { Text = "Spune pe cine din grup ai flirta dacă ar fi o situație diferită", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și fă 5 minute workout-ul celui mai greu", Difficulty = 3 },
            new Challenge { Text = "Spune-ți cea mai mare frică și motivul", Difficulty = 3 },
            new Challenge { Text = "Imită vocea cuiva din grup pentru urmatoarele 2 runde", Difficulty = 3 },
            new Challenge { Text = "Bea o gură pentru fiecare cuvânt grobian pe care-l spui următoarele 3 minute", Difficulty = 3 },
            new Challenge { Text = "Spune cui din grup i-ai ascunde ceva dacă ar trebui", Difficulty = 3 },
            new Challenge { Text = "Fă o confesiune mică dar reală despre viața ta sexuală", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și cere cuiva permisiunea de a-i lua o fotografie", Difficulty = 3 },
            new Challenge { Text = "Spune pe cine din grup crezi că ar fi cel mai bun iubit", Difficulty = 3 },
            new Challenge { Text = "Fă un video de 15 secunde în care spui ceva embarrassing", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și schimbă locul cu cineva pentru urmatoarele 2 runde", Difficulty = 3 },
            new Challenge { Text = "Spune-i omului din stânga ta ce ți-ar plăcea sa-i schimbi la aspectul fizic", Difficulty = 3 },
            new Challenge { Text = "Bea o gură și nu mai foloseşti cuvântul 'si' următoarele 5 minute", Difficulty = 3 },

            // ==================== DIFFICULTY 4 - HARD (20 challenges) ====================
            new Challenge { Text = "Spune-i cuiva din grup cum te-ar putea satisface complet", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și sărută pe gură persoana din stânga ta", Difficulty = 4 },
            new Challenge { Text = "Spune cel mai darkul secret care nu i-ai spus nimănui", Difficulty = 4 },
            new Challenge { Text = "Bea o gură pentru fiecare persoană din grup cu care ai flirtat", Difficulty = 4 },
            new Challenge { Text = "Fă un gest romantic unei persoane din grup care nu e cuplul tău", Difficulty = 4 },
            new Challenge { Text = "Spune ce cred ceilalți greșit despre tine și corectează-i", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și stai în genunchi în fața grupului 30 de secunde", Difficulty = 4 },
            new Challenge { Text = "Spune-i cuiva din grup ce te-ar face sa renunți la relația ta", Difficulty = 4 },
            new Challenge { Text = "Imită actul sexual timp de 20 de secunde fără sunete", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și fă o propunere de căsătorie dramatică omului din dreapta", Difficulty = 4 },
            new Challenge { Text = "Spune-ți cea mai strictă judecată despre cineva din grup", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și fă sex telefonic cu o persoană din grup (joc de rol)", Difficulty = 4 },
            new Challenge { Text = "Spune pe cine din grup ai vrea sa fie într-un FFM encounter", Difficulty = 4 },
            new Challenge { Text = "Bea o gură pentru fiecare dată în care ai fost infidel", Difficulty = 4 },
            new Challenge { Text = "Fă o cerere în căsătorie neașteptată cuiva din grup", Difficulty = 4 },
            new Challenge { Text = "Spune cea mai ciudată fantzie sexuală pe care ai avut-o", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și ține mâna omului din stânga timp de urmatoarele 3 runde", Difficulty = 4 },
            new Challenge { Text = "Spune pe cine din grup ai fi omorât pentru o noapte cu altcineva", Difficulty = 4 },
            new Challenge { Text = "Bea o gură și trimite un mesaj provocator la contactul tău favorit", Difficulty = 4 },
            new Challenge { Text = "Fă o dare ciudată cuiva din grup și ei trebuie s-o facă", Difficulty = 4 },

            // ==================== DIFFICULTY 5 - LEGENDARY (20 challenges) ====================
            new Challenge { Text = "Bea o gură și întreba-i pe ceilalți ce miros ai tu sexual", Difficulty = 5 },
            new Challenge { Text = "Spune care e cea mai ciudată fantzie sexuală a ta și detaliază-o", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și arată-i grupului cel mai ciudat video din telefon", Difficulty = 5 },
            new Challenge { Text = "Fă o sarcină sexuală unui jucător și ei trebuie s-o facă", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și ridică-te și spun-le-i pe stradă cât de sexy sunt", Difficulty = 5 },
            new Challenge { Text = "Spune cui din grup i-ai face sex și cu cine nu, motivând", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și fă o ofertă sexuală explicită cuiva din grup", Difficulty = 5 },
            new Challenge { Text = "Arată-ți cel mai intim loc din corpul tău grupului", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și cere unui bărbat sex în schimbul unui pariu", Difficulty = 5 },
            new Challenge { Text = "Spune cel mai murdar gând care ți-a trecut prin cap astazi", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și vorbește despre experiența ta cu pron timp de 2 minutes", Difficulty = 5 },
            new Challenge { Text = "Fă-i unui jucător o propunere de sex cu detalii specifice", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și recitează o scenă sexual-a dintr-un film celebru", Difficulty = 5 },
            new Challenge { Text = "Spune-ți cea mai obscură tabu sexuală și nu judam nimic", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și trimite un mesaj sexual unui număr random din lista ta", Difficulty = 5 },
            new Challenge { Text = "Fă o dată sexuală cu cineva din grup în următoarele 48 de ore", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și vorbește deschis despre pornografia ta preferată", Difficulty = 5 },
            new Challenge { Text = "Spune cine e persoana pe care ai vrea sa o bagi in trei și detaliaza", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și fă o sex call cu cineva din grup live", Difficulty = 5 },
            new Challenge { Text = "Bea o gură și expune-ți cel mai murdar secret cu ceilalți", Difficulty = 5 },
        };
    }
}
