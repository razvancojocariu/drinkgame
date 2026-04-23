using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using drinkgame.Models;
using Microsoft.Maui.Controls;
using System.Text.Json;

namespace drinkgame.ViewModels;

public partial class GameViewModel : ObservableObject
{
    private readonly Random _random = new();
    private const int MaxRounds = 30;
    private List<string> _shuffledChallenges = new();
    private int _challengeIndex = 0;
    private int _pendingWheelCategory = -1;

    public event Action<int>? SinfulWheelSpinRequested;

    [ObservableProperty]
    private ObservableCollection<Player> players = new();

    [ObservableProperty]
    private string currentChallenge;

    [ObservableProperty]
    private Player currentPlayer;

    [ObservableProperty]
    private int round;

    [ObservableProperty]
    private bool isGameFinished;

    [ObservableProperty]
    private bool isWheelVisible;

    [ObservableProperty]
    private bool isWheelResultVisible;

    public List<string> Challenges { get; set; }
    public List<string> KinkyPool { get; set; }
    public List<string> GroupPool { get; set; }
    public List<string> ImmunityPool { get; set; }
    public List<string> NewRulePool { get; set; }

    public GameViewModel()
    {
        LoadChallenges();
        LoadSpecialPools();

        Round = 0;
        IsGameFinished = false;
        IsWheelVisible = false;
    }

    private void LoadChallenges()
    {
        Challenges = new List<string>{
    "Toți cei care au mâncat azi dimineață beau 1 shot!",
    "{0}, trimite un emoji aleatoriu ultimei persoane cu care ai vorbit pe WhatsApp.",
    "Toți cei care poartă ceva albastru beau 1 shot!",
    "{0}, fă 10 genuflexiuni acum!",
    "Toți cei care au un animal de companie beau 1 shot!",
    "{0}, schimbă-ți poza de profil pe WhatsApp cu o poză făcută acum.",
    "Toți cei care au mai băut ieri beau 1 shot!",
    "{0}, spune un fapt aleatoriu despre tine pe care nimeni nu îl știe.",
    "Toți cei care au Netflix beau 1 shot!",
    "{0}, imită persoana din dreapta ta timp de 1 minut.",
    "Toți cei care au mai mult de 2 aplicații de social media beau 1 shot!",
    "{0}, spune alfabetul invers cât poți de repede.",
    "Toți cei care poartă șosete beau 1 shot!",
    "{0}, dă like la ultima poză a primei persoane din lista de contacte.",
    "Toți cei care au călătorit în afara țării în ultimul an beau 1 shot!",
    "{0}, fă o poză urâtă cu tine și trimite-o în grupul de WhatsApp al familiei.",
    "Toți cei care au mâncat pizza în ultima săptămână beau 1 shot!",
    "{0}, sună pe cineva care nu e de față și cântă-i 'La mulți ani'!",
    "Toți cei care au un tatuaj beau 1 shot!",
    "{0}, postează un selfie acum pe stories.",
    "Toți cei care conduc beau suc în loc de shot!",
    "{0}, vorbește cu accent britanic pentru 3 minute.",
    "Toți cei care au mai mult de 500 de poze în galerie beau 1 shot!",
    "{0}, trimite un mesaj tip 'mă gândesc la tine' cuiva aleatoriu din contacte.",
    "Toți cei care au mâncat ciocolată azi beau 1 shot!",
    "{0}, stai în echilibru pe un picior timp de 30 de secunde.",
    "Toți cei care au ochelari beau 1 shot!",
    "{0}, descrie persoana din stânga ta folosind doar adjective de animale.",
    "Toți cei care au mai mult de 3 aplicații de jocuri beau 1 shot!",
    "{0}, numără cu voce tare de la 20 la 1 în mai puțin de 5 secunde.",
    "Toți cei care au blocat pe cineva în ultimele 6 luni beau 1 shot!",
    "{0}, dă telefonul persoanei din stânga pentru 2 minute (fără acces la poze).",
    "Toți cei care au plâns la un film beau 1 shot!",
    "{0}, citește cu voce tare ultimele 3 mesaje primite pe Instagram sau WhatsApp.",
    "Toți cei care au mâncat singuri în ultima săptămână beau 1 shot!",
    "{0}, fă-ți o poză acum cu cel mai apropiat obiect de lângă tine în gură.",
    "Toți cei care au încheiat o relație prin mesaj beau 2 shoturi!",
    "{0}, arată notificările de pe ecranul de blocare întregului grup.",
    "Toți cei care au trimis un mesaj greșit cuiva beau 1 shot!",
    "{0}, fă o flotare sau bea 2 shoturi!",
    "Toți cei care au dat ghosting cuiva beau 1 shot!",
    "{0}, deschide TikTok/Reels și dansează pe primul video pe care îl vezi.",
    "Toți cei care au dormit mai puțin de 5 ore noaptea trecută beau 1 shot!",
    "{0}, arată grupului ultimul meme salvat în galerie.",
    "Toți cei care au mâncat fast food azi beau 1 shot!",
    "{0}, scrie un status pe WhatsApp ales de grupul de față.",
    "Toți cei care au urmărit un cont fără să îi spună persoanei beau 1 shot!",
    "{0}, fă 20 de sărituri cu mâinile sus acum!",
    "Toți cei care au cumpărat ceva online în ultima săptămână beau 1 shot!",
    "{0}, arată grupului ultima conversație de pe Messenger.",
    "Toți cei care au o fotografie jenantă în galerie beau 1 shot!",
    "{0}, trimite un mesaj cu 'ce mai faci?' unui fost sau unei foste.",
    "Toți cei care au cântat singuri în mașină beau 1 shot!",
    "{0}, lasă grupul să îți vadă primele 10 persoane din lista de apeluri recente.",
    "Toți cei care au mințit în ultimele 24 de ore beau 1 shot (pe onoare!)", // <--- Virgula lipsea aici
    "{0}, fă o imitație a unui actor celebru, grupul trebuie să ghicească cine e.",
    "Toți cei care au mai mult de 50 de mesaje necitite beau 1 shot!",
    "{0}, spune cel mai jenant lucru pe care l-ai cumpărat online.",
    "Toți cei care au postat ceva bând alcool pe social media beau 1 shot!",
    "{0}, lasă o persoană din grup să îți scrie un status pe care trebuie să îl postezi.",
    "Toți cei care au mințit un părinte în ultima lună beau 2 shoturi!",
    "{0}, arată grupului ultimele 5 persoane căutate pe Instagram.",
    "Toți cei care au stalkerit un profil mai mult de 10 minute beau 1 shot!",
    "{0}, sună-ți părinții și spune-le că ai un anunț important (grupul decide ce spui).",
    "Toți cei care au râs când nu trebuia beau 1 shot!",
    "{0}, dă voie unui jucător să citească orice conversație de pe telefonul tău.",
    "Toți cei care au un secret față de cineva din grup beau 2 shoturi!",
    "{0}, arată ultimele 3 persoane căutate pe Google.",
    "Toți cei care au vorbit de rău pe cineva din grup beau 2 shoturi!",
    "{0}, fă 1 minut de planșă acum sau bei 3 shoturi!",
    "Toți cei care au primit un mesaj și nu au răspuns intenționat beau 1 shot!",
    "{0}, citește cu voce tare un mesaj de la prima ta iubire în fața grupului.",
    "Toți cei care au furat mâncare din frigiderul altcuiva beau 1 shot!",
    "{0}, grupul alege un contact și tu îi trimiți un selfie cu mesajul 'te-am visat'.",
    "Toți cei care au cumpărat alcool pentru minori beau 2 shoturi!",
    "{0}, arată celui din dreapta coșul de cumpărare de pe orice platformă online.",
    "Toți care au dat de mâncare unui animal de stradă beau 1 shot!",
    "{0}, fă 10 flotări sau bei 3 shoturi!",
    "Toți care au adormit la o petrecere beau 1 shot!",
    "{0}, lasă grupul să dea scroll prin galeria ta foto timp de 2 minute.",
    "Toți care au vomitat de la alcool beau 1 shot!",
    "{0}, lasă grupul să îți schimbe poza de profil pe WhatsApp pentru 10 minute.",
    "Toți care au uitat ziua de naștere a unui prieten apropiat beau 1 shot!",
    "{0}, spune cu voce tare cele mai jenante 3 momente din viața ta.",
    "Toți care au un crush activ în prezent beau 2 shoturi!",
    "{0}, grupul îți dictează un mesaj pe care îl trimiți unui prieten care nu e de față.",
    "Toți care au plâns la o reclamă beau 1 shot!",
    "{0}, arată tuturor suma cheltuită în ultima lună pe food delivery.",
    "Toți care au condus după ce au băut beau 3 shoturi (și să vă fie rușine!)",
    "{0}, grupul alege orice persoană din telefonul tău și trebuie să o suni acum.",
    "Toți cei care au citit mesajele altcuiva fără știre beau 2 shoturi!",
    "{0}, trimite mesajul 'Trebuie să îți spun ceva important' unui contact ales de grup.",
    "Toți care s-au prefăcut că nu văd un apel beau 2 shoturi!",
    "{0}, grupul îți accesează lista de achiziții din App Store/Play Store.",
    "Toți care au un folder ascuns sau privat pe telefon beau 2 shoturi!",
    "{0}, postează o poză jenantă pe story cu textul ales de grup.",
    "Toți care au inventat o scuză ca să scape de o întâlnire beau 1 shot!",
    "{0}, grupul vede suma totală din extrasul tău de cont de luna trecută.",
    "Toți care au mințit cu 'sunt pe drum' beau 2 shoturi!",
    "{0}, trimite un emoji cu sărut unui fost sau unei foste.",
    "Toți care au un mesaj redactat dar netrimis beau 1 shot!",
    "{0}, arată notele tale private întregului grup.",
    "Toți care s-au prefăcut bolnavi ca să chiulească beau 1 shot!",
    "{0}, grupul vede ultimele 5 videoclipuri vizionate de tine pe YouTube.",
    "Toți care au plâns fără motiv clar în ultima lună beau 1 shot!",
    "{0}, fă o declarație de dragoste exagerată cuiva din local.",
    "Toți care au mâncat ceva căzut pe jos beau 1 shot!",
    "{0}, grupul îți vede istoricul de navigare din ultimele 24 de ore.",
    "Toți care au cerut cuiva să mintă pentru ei beau 2 shoturi!",
    "{0}, trimite 'Îmi e dor de tine' ultimei persoane vorbite acum un an.",
    "Toți care s-au trezit lângă cineva 'regretabil' beau 2 shoturi!",
    "{0}, grupul dictează un status de Facebook pe care îl ții 30 min.",
    "Toți care au fost concediați sau au chiulit beau 1 shot!",
    "{0}, dă voie unui jucător să trimită orice mesaj de pe telefonul tău.",
    "Toți care au mâncat în pat beau 1 shot!",
    "{0}, grupul vede suma cheltuită pe alcool luna asta pe card.",
    "Toți care au mințit în această seară beau 3 shoturi!",
    "{0}, fă un tur al camerei în live pe Instagram timp de 1 minut.",
    "Toți care au un cont secret pe social media beau 3 shoturi!",
    "{0}, scrie un mesaj sincer cu ce crezi despre cineva ales de grup.",
    "Toți care au o relație nesigură acum beau 3 shoturi!",
    "{0}, grupul are acces complet la telefonul tău timp de 3 minute.",
    "Toți care au trișat vreodată într-o relație beau 3 shoturi!",
    "{0}, sună-ți un fost și spune-i 'îmi pare rău' fără explicații.",
    "Toți care au furat ceva beau 2 shoturi!",
    "{0}, grupul vede ultimele poze șterse din telefon.",
    "Toți care au mințit în relații beau 3 shoturi!",
    "{0}, postează pe Facebook o poză cu tine de când erai mic.",
    "Toți care au un secret nespus nimănui niciodată beau 3 shoturi!",
    "{0}, grupul vede istoricul tău Incognito.",
    "Toți care s-au trezit undeva fără să știe cum au ajuns acolo beau 2 shoturi!",
    "{0}, trimite un mesaj sincer cuiva cu care ai un conflict.",
    "Toți care au o fantezie nespusă partenerului beau 2 shoturi!",
    "{0}, spune cel mai jenant lucru făcut pentru cineva care nu te plăcea.",
    "Toți care au intrat undeva fără bilet beau 1 shot!",
    "{0}, scrie cel mai sincer mesaj despre cineva ales de grup.",
    "Toți care au plătit pentru cineva care nu merita beau 2 shoturi!",
    "{0}, grupul îți vede toate abonamentele active.",
    "Toți care au evitat pe cineva intenționat o săptămână beau 2 shoturi!",
    "{0}, trimite un mesaj de dragoste serios cuiva din contacte.",
    "Toți care au dat vina pe altcineva pentru greșeala lor beau 2 shoturi!",
    "{0}, postează pe LinkedIn ce îți dictează grupul acum.",
    "Toți care au o relație de love-hate cu cineva din grup beau 3 shoturi!",
    "{0}, grupul citește o conversație completă la alegere.",
    "Toți care au sabotat pe cineva beau 3 shoturi!",
    "{0}, grupul îți schimbă poza de profil peste tot pentru o oră.",
    "Toți care au plâns din cauza unei persoane din grup beau 2 shoturi!",
    "{0}, spune cel mai mare secret al tău acum.",
    "Toți care se regăsesc în mai mult de 10 provocări beau 3 shoturi finale!",
    "Toată lumea bea un shot și spune ceva sincer despre cel din dreapta!"
};
    }

    private void LoadSpecialPools()
    {
       KinkyPool = new List<string>{
    "Stai cu ochii închiși și lasă 2 persoane să te atingă ușor — trebuie să ghicești cine e",
    "Ține pe cineva de talie și menține contactul apropiat 1 minut",
    "Lasă pe cineva să-ți aleagă o propoziție pe care trebuie să o spui seducător altcuiva",
    "Fă contact vizual cu cineva și mușcă-ți buza seducător",
    "Lasă persoana din dreapta să-ți testeze reacțiile (te atinge ușor pe braț/gât și trebuie să rămâi calm)",
    "Lasă grupul să aleagă pe cine trebuie să ții de mână următoarele 3 runde",
    "Lasă persoana din fața ta să-ți pună o regulă pe care trebuie s-o respecți 10 minute",
    "Alege o persoană de același sex și atinge-i fața într-un mod senzual",
    "Switch roles: cineva îți spune cum să te comporți (timid / dominant / misterios) și trebuie să intri în rol",
    "Alege 2 persoane din grup și creează un moment senzual cu ambele persoane deodată",
    "Fă un dans senzual persoanei pe care o alege persoana din stânga ta",
    "Persoana din stânga trebuie să te lege la ochi și să te sărute pe gât 5 secunde",
    "Trebuie să săruți o persoană îmbrăcată în negru",
    "Atinge-i pieptul persoanei din fața ta",
    "Alege 2 persoane din grup de același sex și atinge-le buzele senzual în același timp",
    "Trebuie să stai în șezut și să lași o persoană din grup să stea peste tine 1 tură",
    "Alege o persoană de același sex și o persoană de sex opus care să vină lângă tine și pe care trebuie să le săruți pe gât în timp ce le tragi de păr ușor, senzual",
    "Pune-te în genunchi în fața unei persoane de sex opus și spune-i \"am fost un băiat/o fată rea, pedepsește-mă!\"",
    "Alege o melodie senzuală și timp de 10 secunde trebuie să dansezi"
};

         GroupPool = new List<string>{
    "Toată lumea pune un deget pe masă. Ultimul care o face, bea un shot!",
    "Toți băieții trebuie să facă un compliment fetelor. Cine e cel mai stângaci, bea!",
    "Regula Săpunului: Toată lumea trebuie să se țină de mâini și să facă un val de 3 ori fără să se desprindă. Cine greșește, bea!",
    "Toată lumea alege un partener de băut pentru următoarele 2 runde. Când unul bea, trebuie să bea și celălalt!",
    "Toți trebuie să facă o poză de grup cu mușchi (ca la sală). Toți beți un shot după!",
    "Concurs de privit în ochi: Toți alegeți o persoană și vă priviți 10 secunde. Cine râde primul, bea!",
    "Toată lumea trebuie să spună un secret rușinos. Cine se bâlbâie, bea!",
    "Tortura de grup: Toți trebuie să-l înconjoare pe cel mai timid din grup și să-l convingă să bea un shot",
    "Toți cei care au șosete în picioare trebuie să bea. Cei desculți sunt șefii rundei!",
    "Toți trebuie să cânte refrenul unei manele celebre. Cine cântă cel mai fals, bea!",
    "Toată lumea face o piramidă umană (sau măcar încearcă!). Cine cade primul, bea!",
    "Toți băieții trebuie să sărute pe frunte o fată din grup. Cine refuză, bea dublu!"
};

        ImmunityPool = new List<string>
        {
            "Ești imun acum!",
            "Poți refuza provocarea!",
            "Alege pe altcineva să bea!"
        };

        NewRulePool = new List<string>
        {
            "Regulă nouă: Pentru 3 ture, înainte de a face o provocare, toți trebuie să spună „Da, șefu'! Acum fac\". Cine uită, bea un shot!",
            "Regulă nouă: Toate fetele trebuie să dea un shot!",
            "Regulă nouă: Toți băieții trebuie să mixeze 2 băuturi și să le bea!",
            "Regulă nouă: Pentru 5 runde nu clipește nimeni! Cine clipește primul, bea.",
            "Regulă nouă: Pentru 3 runde cine ridică mâna sus ultimul, bea un shot!",
            "Regulă nouă: Pentru 10 minute, toți băieții trebuie să sărute mâna unei fete înainte să bea. Cine uită, bea dublu!",
            "Regulă nouă: Pentru 10 minute, toate fetele trebuie să aleagă un băiat pe care îl vor mângâia în păr atunci când cineva bea.",
            "Regulă nouă: Nimeni nu râde! Cine râde, bea."
        };
    }

    private void ShuffleChallenges()
    {
        _shuffledChallenges = Challenges.OrderBy(x => _random.Next()).ToList();
        _challengeIndex = 0;
    }

    public void SetPlayers(IEnumerable<Player> incomingPlayers)
    {
        Players.Clear();
        foreach (var p in incomingPlayers)
        {
            Players.Add(p);
        }

        ShuffleChallenges();
        Round = 1;
        IsGameFinished = false;
        IsWheelVisible = false;

        GetNextChallenge();
    }

    [RelayCommand]
    public async Task NextChallenge()
    {
        if (IsGameFinished || IsWheelVisible)
            return;

        if (Round >= MaxRounds)
        {
            IsGameFinished = true;
            CurrentChallenge = "Joc terminat! Ați supraviețuit?";
            return;
        }

        if (CurrentPlayer != null)
            CurrentPlayer.ChallengesCompleted++;

        Round++;
        GetNextChallenge();
    }

    [RelayCommand]
    public void SkipChallenge()
    {
        if (IsGameFinished || IsWheelVisible)
            return;

        if (CurrentPlayer != null)
            CurrentPlayer.ChallengesSkipped++;

        GetNextChallenge();
    }

    public void GetNextChallenge()
    {
        if (Players.Count == 0)
            return;

        CurrentPlayer = Players[_random.Next(Players.Count)];

        double wheelChance = _random.NextDouble();

        if (wheelChance < 0.03)
        {
            IsWheelVisible = true;
            CurrentChallenge = "🎡 Se întâmplă roata...";
            int categoryIndex = _random.Next(0, 4);
            _pendingWheelCategory = categoryIndex;
            SinfulWheelSpinRequested?.Invoke(categoryIndex);
            return;
        }

        if (_challengeIndex >= _shuffledChallenges.Count)
            ShuffleChallenges();

        var text = _shuffledChallenges[_challengeIndex++];

        CurrentChallenge = text.Contains("{0}")
            ? string.Format(text, CurrentPlayer.Name)
            : text;
    }

    public void SetChallengeFromWheel(int index)
    {
        int categoryToUse = _pendingWheelCategory >= 0 ? _pendingWheelCategory : index;

        string res = categoryToUse switch
        {
            0 => KinkyPool[_random.Next(KinkyPool.Count)],
            1 => GroupPool[_random.Next(GroupPool.Count)],
            2 => NewRulePool[_random.Next(NewRulePool.Count)],
            3 => ImmunityPool[_random.Next(ImmunityPool.Count)],
            _ => "Provocare!"
        };

        var luckyPlayer = Players[_random.Next(Players.Count)];

        CurrentChallenge = $"🎡 {luckyPlayer.Name}, {res.ToLower()}";

        IsWheelVisible = false;
        _pendingWheelCategory = -1;
    }

    [RelayCommand]
    public void ResetGameProgress()
    {
        ShuffleChallenges();
        Round = 1;
        IsGameFinished = false;
        GetNextChallenge();
    }

    [RelayCommand]
    public async Task GoToMainMenu()
    {
        if (IsGameFinished)
        {
            await Shell.Current.GoToAsync("///MainPage");
            return;
        }

        bool confirmed = await Shell.Current.DisplayAlert(
            "Ieși din joc?",
            "Ești sigur că vrei să renunți?",
            "Da, renunț",
            "Nu, continui");

        if (confirmed)
            await Shell.Current.GoToAsync("///MainPage");
    }
}
