using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Newtone.Core.Languages
{
    public class Localization
    {
        private static LocalizationBase CurrentLocalization = GetCurrentLanguage();

        private static LocalizationBase GetCurrentLanguage()
        {
            string culture = GlobalData.CurrentLanguage ?? CultureInfo.CurrentCulture.Name;

            if (culture.ToLower().Contains("pl"))
                return new LocalizationPL();
            else if (culture.ToLower().Contains("ru") || culture.ToLower().Contains("be") || culture.ToLower().Contains("uk"))
                return new LocalizationRU();
            else
                return new LocalizationEN();

        }
        public static void RefreshLanguage()
        {
            CurrentLocalization = GetCurrentLanguage();
        }

        /// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Autor: Mateusz Nejman
/// </summary>
public static string AboutAuthor { get { return CurrentLocalization.AboutAuthor; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwarzacz umożliwia słuchanie muzyki z youtube, oraz lokalnie. Autor nie ponosi odpowiedzialności za to, w jaki sposób użytkownik używa mediów z podanych serwisów.
/// </summary>
public static string AboutDesc { get { return CurrentLocalization.AboutDesc; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Strona autora
/// </summary>
public static string AboutWWW { get { return CurrentLocalization.AboutWWW; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj
/// </summary>
public static string Add { get { return CurrentLocalization.Add; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodać tagi?
/// </summary>
public static string AddTags { get { return CurrentLocalization.AddTags; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wykonawca
/// </summary>
public static string Artist { get { return CurrentLocalization.Artist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wykonawcy
/// </summary>
public static string Artists { get { return CurrentLocalization.Artists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Automatycznie konwertuj do mp3
/// </summary>
public static string AutoConvert { get { return CurrentLocalization.AutoConvert; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Czy chcesz automatycznie aktualizować pobrane playlisty?
/// </summary>
public static string AutoDownload { get { return CurrentLocalization.AutoDownload; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Naciśnij jeszcze raz, aby wyjść
/// </summary>
public static string BackPressed { get { return CurrentLocalization.BackPressed; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Anuluj
/// </summary>
public static string Cancel { get { return CurrentLocalization.Cancel; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zmień nazwę
/// </summary>
public static string ChangeName { get { return CurrentLocalization.ChangeName; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz playlistę
/// </summary>
public static string ChoosePlaylist { get { return CurrentLocalization.ChoosePlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyczyść
/// </summary>
public static string Clear { get { return CurrentLocalization.Clear; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Połącz
/// </summary>
public static string Connect { get { return CurrentLocalization.Connect; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Konwersja
/// </summary>
public static string Conversion { get { return CurrentLocalization.Conversion; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pliki wejściowe
/// </summary>
public static string ConversionInputFiles { get { return CurrentLocalization.ConversionInputFiles; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Folder wyjściowy
/// </summary>
public static string ConversionOutputFolder { get { return CurrentLocalization.ConversionOutputFolder; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Format wyjściowy
/// </summary>
public static string ConversionOutputFormat { get { return CurrentLocalization.ConversionOutputFormat; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Konwertuj
/// </summary>
public static string Convert { get { return CurrentLocalization.Convert; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Okładka
/// </summary>
public static string Cover { get { return CurrentLocalization.Cover; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wczytaj okładkę
/// </summary>
public static string CoverLoad { get { return CurrentLocalization.CoverLoad; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisz okładkę
/// </summary>
public static string CoverSave { get { return CurrentLocalization.CoverSave; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Rozłącz
/// </summary>
public static string Disconnect { get { return CurrentLocalization.Disconnect; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Plik jest uszkodzony
/// </summary>
public static string FileCorrupted { get { return CurrentLocalization.FileCorrupted; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Folder nie istnieje
/// </summary>
public static string FolderExists { get { return CurrentLocalization.FolderExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Informacje
/// </summary>
public static string Informations { get { return CurrentLocalization.Informations; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Instrukcja
/// </summary>
public static string Instruction { get { return CurrentLocalization.Instruction; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu English
/// </summary>
public static string LanguageEN { get { return CurrentLocalization.LanguageEN; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Polski
/// </summary>
public static string LanguagePL { get { return CurrentLocalization.LanguagePL; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Русский
/// </summary>
public static string LanguageRU { get { return CurrentLocalization.LanguageRU; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ostatnio odtwarzane
/// </summary>
public static string LastViews { get { return CurrentLocalization.LastViews; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Biblioteka
/// </summary>
public static string Library { get { return CurrentLocalization.Library; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Strona główna
/// </summary>
public static string MainPage { get { return CurrentLocalization.MainPage; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Najczęściej odtwarzane
/// </summary>
public static string MostViews { get { return CurrentLocalization.MostViews; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nowa playlista
/// </summary>
public static string NewPlaylist { get { return CurrentLocalization.NewPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wprowadź nazwę playlisty
/// </summary>
public static string NewPlaylistHint { get { return CurrentLocalization.NewPlaylistHint; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dalej
/// </summary>
public static string Next { get { return CurrentLocalization.Next; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nie
/// </summary>
public static string No { get { return CurrentLocalization.No; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Brak dostępu do internetu
/// </summary>
public static string NoConnection { get { return CurrentLocalization.NoConnection; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Brak pobierania w toku
/// </summary>
public static string NoDownloads { get { return CurrentLocalization.NoDownloads; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Przyznaj uprawnienia
/// </summary>
public static string PermissionGrant { get { return CurrentLocalization.PermissionGrant; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwarzacz wymaga uprawnień do zapisu danych po to, aby móc pobierać muzykę oraz zapisywać ustawienia
/// </summary>
public static string PermissionInfo { get { return CurrentLocalization.PermissionInfo; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Playlista
/// </summary>
public static string Playlist { get { return CurrentLocalization.Playlist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utworzyć nową playlistę z pobranymi utworami?
/// </summary>
public static string PlaylistDownload { get { return CurrentLocalization.PlaylistDownload; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Istnieje już playlista z taką nazwą
/// </summary>
public static string PlaylistExists { get { return CurrentLocalization.PlaylistExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pobrać playlistę czy utwór?
/// </summary>
public static string PlaylistOrTrack { get { return CurrentLocalization.PlaylistOrTrack; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwórz
/// </summary>
public static string PlaylistPlay { get { return CurrentLocalization.PlaylistPlay; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Playlisty
/// </summary>
public static string Playlists { get { return CurrentLocalization.Playlists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Postęp
/// </summary>
public static string Progress { get { return CurrentLocalization.Progress; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pytanie
/// </summary>
public static string Question { get { return CurrentLocalization.Question; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usunąć plik
/// </summary>
public static string QuestionDelete { get { return CurrentLocalization.QuestionDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu z playlisty
/// </summary>
public static string QuestionDeleteFromPlaylist { get { return CurrentLocalization.QuestionDeleteFromPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usunąć playlistę
/// </summary>
public static string QuestionDeletePlaylist { get { return CurrentLocalization.QuestionDeletePlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 
/// </summary>
public static string QuestionDeletePlaylistg { get { return CurrentLocalization.QuestionDeletePlaylistg; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Gotowe
/// </summary>
public static string Ready { get { return CurrentLocalization.Ready; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odbierz
/// </summary>
public static string Receive { get { return CurrentLocalization.Receive; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Kod odbiorcy
/// </summary>
public static string ReceiverCode { get { return CurrentLocalization.ReceiverCode; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zamień z istniejącymi plikami
/// </summary>
public static string ReplaceWithExists { get { return CurrentLocalization.ReplaceWithExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisz
/// </summary>
public static string Save { get { return CurrentLocalization.Save; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Szukaj
/// </summary>
public static string Search { get { return CurrentLocalization.Search; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Historia wyszukiwania
/// </summary>
public static string SearchHistory { get { return CurrentLocalization.SearchHistory; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyszukiwanie...
/// </summary>
public static string Searching { get { return CurrentLocalization.Searching; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Do wyszukiwarki możesz wkleić link do utworu, playlisty, lub wpisać tytuł.
/// </summary>
public static string SearchTip { get { return CurrentLocalization.SearchTip; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz
/// </summary>
public static string Select { get { return CurrentLocalization.Select; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz folder
/// </summary>
public static string SelectFolder { get { return CurrentLocalization.SelectFolder; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyślij
/// </summary>
public static string Send { get { return CurrentLocalization.Send; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ustawienia
/// </summary>
public static string Settings { get { return CurrentLocalization.Settings; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wygeneruj tagi dla plików lokalnych
/// </summary>
public static string Settings0 { get { return CurrentLocalization.Settings0; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Automatyczne tagi
/// </summary>
public static string Settings1 { get { return CurrentLocalization.Settings1; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyczyść wszystkie dane
/// </summary>
public static string Settings2 { get { return CurrentLocalization.Settings2; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz motyw
/// </summary>
public static string Settings3 { get { return CurrentLocalization.Settings3; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj folder do listy skanowanych folderów
/// </summary>
public static string Settings4 { get { return CurrentLocalization.Settings4; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Język
/// </summary>
public static string Settings5 { get { return CurrentLocalization.Settings5; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zmiany będą widoczne po ponownym uruchomieniu aplikacji
/// </summary>
public static string SettingsChanges { get { return CurrentLocalization.SettingsChanges; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pomyślnie usunięto
/// </summary>
public static string SnackDelete { get { return CurrentLocalization.SnackDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Plik nie istnieje
/// </summary>
public static string SnackFileExists { get { return CurrentLocalization.SnackFileExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodano do playlisty
/// </summary>
public static string SnackPlaylist { get { return CurrentLocalization.SnackPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodano do kolejki
/// </summary>
public static string SnackQueue { get { return CurrentLocalization.SnackQueue; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do wysłania
/// </summary>
public static string SyncAdd { get { return CurrentLocalization.SyncAdd; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do wysłania (playlista)
/// </summary>
public static string SyncAddPlaylist { get { return CurrentLocalization.SyncAddPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 1. Podłącz urządzenia do tej samej sieci
/// </summary>
public static string SyncHelp1 { get { return CurrentLocalization.SyncHelp1; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 2. Wpisz kod lub poczekaj na połączenie
/// </summary>
public static string SyncHelp2 { get { return CurrentLocalization.SyncHelp2; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 2. Wpisz kod
/// </summary>
public static string SyncHelp2Desktop { get { return CurrentLocalization.SyncHelp2Desktop; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 3. Wybierz odpowiednią opcję
/// </summary>
public static string SyncHelp3 { get { return CurrentLocalization.SyncHelp3; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Synchronizacja z telefonem
/// </summary>
public static string SyncPhone { get { return CurrentLocalization.SyncPhone; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odbieranie plików
/// </summary>
public static string SyncReceiving { get { return CurrentLocalization.SyncReceiving; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wysyłanie plików
/// </summary>
public static string SyncSending { get { return CurrentLocalization.SyncSending; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pokaż pliki do wysłania
/// </summary>
public static string SyncShowFiles { get { return CurrentLocalization.SyncShowFiles; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ciemny
/// </summary>
public static string ThemeDark { get { return CurrentLocalization.ThemeDark; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Domyślny
/// </summary>
public static string ThemeDefault { get { return CurrentLocalization.ThemeDefault; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Różowy
/// </summary>
public static string ThemeLight { get { return CurrentLocalization.ThemeLight; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Tytuł
/// </summary>
public static string Title { get { return CurrentLocalization.Title; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pobieranie
/// </summary>
public static string TitleDownloads { get { return CurrentLocalization.TitleDownloads; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utwór
/// </summary>
public static string Track { get { return CurrentLocalization.Track; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisanych utworów
/// </summary>
public static string TrackCount { get { return CurrentLocalization.TrackCount; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utworów
/// </summary>
public static string TrackCountPlaylist { get { return CurrentLocalization.TrackCountPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usuń
/// </summary>
public static string TrackMenuDelete { get { return CurrentLocalization.TrackMenuDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Edytuj
/// </summary>
public static string TrackMenuEdit { get { return CurrentLocalization.TrackMenuEdit; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do playlisty
/// </summary>
public static string TrackMenuPlaylist { get { return CurrentLocalization.TrackMenuPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do kolejki
/// </summary>
public static string TrackMenuQueue { get { return CurrentLocalization.TrackMenuQueue; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utwory
/// </summary>
public static string Tracks { get { return CurrentLocalization.Tracks; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nieznany wykonawca
/// </summary>
public static string UnknownArtist { get { return CurrentLocalization.UnknownArtist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wypakowano
/// </summary>
public static string Unpacked { get { return CurrentLocalization.Unpacked; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Uwaga
/// </summary>
public static string Warning { get { return CurrentLocalization.Warning; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Tak
/// </summary>
public static string Yes { get { return CurrentLocalization.Yes; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Twój kod
/// </summary>
public static string YourCode { get { return CurrentLocalization.YourCode; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wystąpił błąd spowodowany zmianami w serwisie YouTube. Proszę czekać na aktualizację uwzględniający podane zmiany.
/// </summary>
public static string YoutubeError { get { return CurrentLocalization.YoutubeError; } }

public abstract class LocalizationBase{
public string AboutAuthor = "Autor: Mateusz Nejman";
public string AboutDesc = "Odtwarzacz umożliwia słuchanie muzyki z youtube, oraz lokalnie. Autor nie ponosi odpowiedzialności za to, w jaki sposób użytkownik używa mediów z podanych serwisów.";
public string AboutWWW = "Strona autora";
public string Add = "Dodaj";
public string AddTags = "Dodać tagi?";
public string Artist = "Wykonawca";
public string Artists = "Wykonawcy";
public string AutoConvert = "Automatycznie konwertuj do mp3";
public string AutoDownload = "Czy chcesz automatycznie aktualizować pobrane playlisty?";
public string BackPressed = "Naciśnij jeszcze raz, aby wyjść";
public string Cancel = "Anuluj";
public string ChangeName = "Zmień nazwę";
public string ChoosePlaylist = "Wybierz playlistę";
public string Clear = "Wyczyść";
public string Connect = "Połącz";
public string Conversion = "Konwersja";
public string ConversionInputFiles = "Pliki wejściowe";
public string ConversionOutputFolder = "Folder wyjściowy";
public string ConversionOutputFormat = "Format wyjściowy";
public string Convert = "Konwertuj";
public string Cover = "Okładka";
public string CoverLoad = "Wczytaj okładkę";
public string CoverSave = "Zapisz okładkę";
public string Disconnect = "Rozłącz";
public string FileCorrupted = "Plik jest uszkodzony";
public string FolderExists = "Folder nie istnieje";
public string Informations = "Informacje";
public string Instruction = "Instrukcja";
public string LanguageEN = "English";
public string LanguagePL = "Polski";
public string LanguageRU = "Русский";
public string LastViews = "Ostatnio odtwarzane";
public string Library = "Biblioteka";
public string MainPage = "Strona główna";
public string MostViews = "Najczęściej odtwarzane";
public string NewPlaylist = "Nowa playlista";
public string NewPlaylistHint = "Wprowadź nazwę playlisty";
public string Next = "Dalej";
public string No = "Nie";
public string NoConnection = "Brak dostępu do internetu";
public string NoDownloads = "Brak pobierania w toku";
public string PermissionGrant = "Przyznaj uprawnienia";
public string PermissionInfo = "Odtwarzacz wymaga uprawnień do zapisu danych po to, aby móc pobierać muzykę oraz zapisywać ustawienia";
public string Playlist = "Playlista";
public string PlaylistDownload = "Utworzyć nową playlistę z pobranymi utworami?";
public string PlaylistExists = "Istnieje już playlista z taką nazwą";
public string PlaylistOrTrack = "Pobrać playlistę czy utwór?";
public string PlaylistPlay = "Odtwórz";
public string Playlists = "Playlisty";
public string Progress = "Postęp";
public string Question = "Pytanie";
public string QuestionDelete = "Usunąć plik";
public string QuestionDeleteFromPlaylist = "z playlisty";
public string QuestionDeletePlaylist = "Usunąć playlistę";
public string QuestionDeletePlaylistg = "";
public string Ready = "Gotowe";
public string Receive = "Odbierz";
public string ReceiverCode = "Kod odbiorcy";
public string ReplaceWithExists = "Zamień z istniejącymi plikami";
public string Save = "Zapisz";
public string Search = "Szukaj";
public string SearchHistory = "Historia wyszukiwania";
public string Searching = "Wyszukiwanie...";
public string SearchTip = "Do wyszukiwarki możesz wkleić link do utworu, playlisty, lub wpisać tytuł.";
public string Select = "Wybierz";
public string SelectFolder = "Wybierz folder";
public string Send = "Wyślij";
public string Settings = "Ustawienia";
public string Settings0 = "Wygeneruj tagi dla plików lokalnych";
public string Settings1 = "Automatyczne tagi";
public string Settings2 = "Wyczyść wszystkie dane";
public string Settings3 = "Wybierz motyw";
public string Settings4 = "Dodaj folder do listy skanowanych folderów";
public string Settings5 = "Język";
public string SettingsChanges = "Zmiany będą widoczne po ponownym uruchomieniu aplikacji";
public string SnackDelete = "Pomyślnie usunięto";
public string SnackFileExists = "Plik nie istnieje";
public string SnackPlaylist = "Dodano do playlisty";
public string SnackQueue = "Dodano do kolejki";
public string SyncAdd = "Dodaj do wysłania";
public string SyncAddPlaylist = "Dodaj do wysłania (playlista)";
public string SyncHelp1 = "1. Podłącz urządzenia do tej samej sieci";
public string SyncHelp2 = "2. Wpisz kod lub poczekaj na połączenie";
public string SyncHelp2Desktop = "2. Wpisz kod";
public string SyncHelp3 = "3. Wybierz odpowiednią opcję";
public string SyncPhone = "Synchronizacja z telefonem";
public string SyncReceiving = "Odbieranie plików";
public string SyncSending = "Wysyłanie plików";
public string SyncShowFiles = "Pokaż pliki do wysłania";
public string ThemeDark = "Ciemny";
public string ThemeDefault = "Domyślny";
public string ThemeLight = "Różowy";
public string Title = "Tytuł";
public string TitleDownloads = "Pobieranie";
public string Track = "Utwór";
public string TrackCount = "Zapisanych utworów";
public string TrackCountPlaylist = "Utworów";
public string TrackMenuDelete = "Usuń";
public string TrackMenuEdit = "Edytuj";
public string TrackMenuPlaylist = "Dodaj do playlisty";
public string TrackMenuQueue = "Dodaj do kolejki";
public string Tracks = "Utwory";
public string UnknownArtist = "Nieznany wykonawca";
public string Unpacked = "Wypakowano";
public string Warning = "Uwaga";
public string Yes = "Tak";
public string YourCode = "Twój kod";
public string YoutubeError = "Wystąpił błąd spowodowany zmianami w serwisie YouTube. Proszę czekać na aktualizację uwzględniający podane zmiany.";
}
    }
}
