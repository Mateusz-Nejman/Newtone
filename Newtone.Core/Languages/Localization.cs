using System.Globalization;

namespace Newtone.Core.Languages
{
    public class Localization
    {
        private static LocalizationBase CurrentLocalization = GetCurrentLanguage();

        private static LocalizationBase GetCurrentLanguage()
        {
            string culture = GlobalData.Current.CurrentLanguage ?? CultureInfo.CurrentCulture.Name;

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
public static string AboutAuthor { get { return CurrentLocalization.BaseAboutAuthor; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwarzacz umożliwia słuchanie muzyki z youtube, oraz lokalnie. Autor nie ponosi odpowiedzialności za to, w jaki sposób użytkownik używa mediów z podanych serwisów.
/// </summary>
public static string AboutDesc { get { return CurrentLocalization.BaseAboutDesc; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Strona autora
/// </summary>
public static string AboutWWW { get { return CurrentLocalization.BaseAboutWWW; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj
/// </summary>
public static string Add { get { return CurrentLocalization.BaseAdd; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodać tagi?
/// </summary>
public static string AddTags { get { return CurrentLocalization.BaseAddTags; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wykonawca
/// </summary>
public static string Artist { get { return CurrentLocalization.BaseArtist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wykonawcy
/// </summary>
public static string Artists { get { return CurrentLocalization.BaseArtists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Automatycznie konwertuj do mp3
/// </summary>
public static string AutoConvert { get { return CurrentLocalization.BaseAutoConvert; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Czy chcesz automatycznie aktualizować pobrane playlisty?
/// </summary>
public static string AutoDownload { get { return CurrentLocalization.BaseAutoDownload; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Naciśnij jeszcze raz, aby wyjść
/// </summary>
public static string BackPressed { get { return CurrentLocalization.BaseBackPressed; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Anuluj
/// </summary>
public static string Cancel { get { return CurrentLocalization.BaseCancel; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zmień nazwę
/// </summary>
public static string ChangeName { get { return CurrentLocalization.BaseChangeName; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz playlistę
/// </summary>
public static string ChoosePlaylist { get { return CurrentLocalization.BaseChoosePlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyczyść
/// </summary>
public static string Clear { get { return CurrentLocalization.BaseClear; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Połącz
/// </summary>
public static string Connect { get { return CurrentLocalization.BaseConnect; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Konwersja
/// </summary>
public static string Conversion { get { return CurrentLocalization.BaseConversion; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pliki wejściowe
/// </summary>
public static string ConversionInputFiles { get { return CurrentLocalization.BaseConversionInputFiles; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Folder wyjściowy
/// </summary>
public static string ConversionOutputFolder { get { return CurrentLocalization.BaseConversionOutputFolder; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Format wyjściowy
/// </summary>
public static string ConversionOutputFormat { get { return CurrentLocalization.BaseConversionOutputFormat; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Konwertuj
/// </summary>
public static string Convert { get { return CurrentLocalization.BaseConvert; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Okładka
/// </summary>
public static string Cover { get { return CurrentLocalization.BaseCover; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wczytaj okładkę
/// </summary>
public static string CoverLoad { get { return CurrentLocalization.BaseCoverLoad; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisz okładkę
/// </summary>
public static string CoverSave { get { return CurrentLocalization.BaseCoverSave; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Rozłącz
/// </summary>
public static string Disconnect { get { return CurrentLocalization.BaseDisconnect; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Plik jest uszkodzony
/// </summary>
public static string FileCorrupted { get { return CurrentLocalization.BaseFileCorrupted; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pobrano
/// </summary>
public static string FileDownloaded { get { return CurrentLocalization.BaseFileDownloaded; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Folder nie istnieje
/// </summary>
public static string FolderExists { get { return CurrentLocalization.BaseFolderExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Informacje
/// </summary>
public static string Informations { get { return CurrentLocalization.BaseInformations; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Instrukcja
/// </summary>
public static string Instruction { get { return CurrentLocalization.BaseInstruction; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu English
/// </summary>
public static string LanguageEN { get { return CurrentLocalization.BaseLanguageEN; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Polski
/// </summary>
public static string LanguagePL { get { return CurrentLocalization.BaseLanguagePL; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Русский
/// </summary>
public static string LanguageRU { get { return CurrentLocalization.BaseLanguageRU; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ostatnio odtwarzane
/// </summary>
public static string LastViews { get { return CurrentLocalization.BaseLastViews; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Biblioteka
/// </summary>
public static string Library { get { return CurrentLocalization.BaseLibrary; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Strona główna
/// </summary>
public static string MainPage { get { return CurrentLocalization.BaseMainPage; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Najczęściej odtwarzane
/// </summary>
public static string MostViews { get { return CurrentLocalization.BaseMostViews; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nowa playlista
/// </summary>
public static string NewPlaylist { get { return CurrentLocalization.BaseNewPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wprowadź nazwę playlisty
/// </summary>
public static string NewPlaylistHint { get { return CurrentLocalization.BaseNewPlaylistHint; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dalej
/// </summary>
public static string Next { get { return CurrentLocalization.BaseNext; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nie
/// </summary>
public static string No { get { return CurrentLocalization.BaseNo; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Brak dostępu do internetu
/// </summary>
public static string NoConnection { get { return CurrentLocalization.BaseNoConnection; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Brak pobierania w toku
/// </summary>
public static string NoDownloads { get { return CurrentLocalization.BaseNoDownloads; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Przyznaj uprawnienia
/// </summary>
public static string PermissionGrant { get { return CurrentLocalization.BasePermissionGrant; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwarzacz wymaga uprawnień do zapisu danych po to, aby móc pobierać muzykę oraz zapisywać ustawienia
/// </summary>
public static string PermissionInfo { get { return CurrentLocalization.BasePermissionInfo; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Playlista
/// </summary>
public static string Playlist { get { return CurrentLocalization.BasePlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utworzyć nową playlistę z pobranymi utworami?
/// </summary>
public static string PlaylistDownload { get { return CurrentLocalization.BasePlaylistDownload; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Istnieje już playlista z taką nazwą
/// </summary>
public static string PlaylistExists { get { return CurrentLocalization.BasePlaylistExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pobrać playlistę czy utwór?
/// </summary>
public static string PlaylistOrTrack { get { return CurrentLocalization.BasePlaylistOrTrack; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odtwórz
/// </summary>
public static string PlaylistPlay { get { return CurrentLocalization.BasePlaylistPlay; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Playlisty
/// </summary>
public static string Playlists { get { return CurrentLocalization.BasePlaylists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Postęp
/// </summary>
public static string Progress { get { return CurrentLocalization.BaseProgress; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pytanie
/// </summary>
public static string Question { get { return CurrentLocalization.BaseQuestion; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usunąć plik
/// </summary>
public static string QuestionDelete { get { return CurrentLocalization.BaseQuestionDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu z playlisty
/// </summary>
public static string QuestionDeleteFromPlaylist { get { return CurrentLocalization.BaseQuestionDeleteFromPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usunąć playlistę
/// </summary>
public static string QuestionDeletePlaylist { get { return CurrentLocalization.BaseQuestionDeletePlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 
/// </summary>
public static string QuestionDeletePlaylistg { get { return CurrentLocalization.BaseQuestionDeletePlaylistg; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Gotowe
/// </summary>
public static string Ready { get { return CurrentLocalization.BaseReady; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odbierz
/// </summary>
public static string Receive { get { return CurrentLocalization.BaseReceive; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Kod odbiorcy
/// </summary>
public static string ReceiverCode { get { return CurrentLocalization.BaseReceiverCode; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zamień z istniejącymi plikami
/// </summary>
public static string ReplaceWithExists { get { return CurrentLocalization.BaseReplaceWithExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisz
/// </summary>
public static string Save { get { return CurrentLocalization.BaseSave; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Szukaj
/// </summary>
public static string Search { get { return CurrentLocalization.BaseSearch; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Historia wyszukiwania
/// </summary>
public static string SearchHistory { get { return CurrentLocalization.BaseSearchHistory; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyszukiwanie...
/// </summary>
public static string Searching { get { return CurrentLocalization.BaseSearching; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Do wyszukiwarki możesz wkleić link do utworu, playlisty, lub wpisać tytuł.
/// </summary>
public static string SearchTip { get { return CurrentLocalization.BaseSearchTip; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz
/// </summary>
public static string Select { get { return CurrentLocalization.BaseSelect; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz folder
/// </summary>
public static string SelectFolder { get { return CurrentLocalization.BaseSelectFolder; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyślij
/// </summary>
public static string Send { get { return CurrentLocalization.BaseSend; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ustawienia
/// </summary>
public static string Settings { get { return CurrentLocalization.BaseSettings; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wygeneruj tagi dla plików lokalnych
/// </summary>
public static string Settings0 { get { return CurrentLocalization.BaseSettings0; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Automatyczne tagi
/// </summary>
public static string Settings1 { get { return CurrentLocalization.BaseSettings1; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wyczyść wszystkie dane
/// </summary>
public static string Settings2 { get { return CurrentLocalization.BaseSettings2; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wybierz motyw
/// </summary>
public static string Settings3 { get { return CurrentLocalization.BaseSettings3; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj folder do listy skanowanych folderów
/// </summary>
public static string Settings4 { get { return CurrentLocalization.BaseSettings4; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Język
/// </summary>
public static string Settings5 { get { return CurrentLocalization.BaseSettings5; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zmiany będą widoczne po ponownym uruchomieniu aplikacji
/// </summary>
public static string SettingsChanges { get { return CurrentLocalization.BaseSettingsChanges; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pomyślnie usunięto
/// </summary>
public static string SnackDelete { get { return CurrentLocalization.BaseSnackDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Plik nie istnieje
/// </summary>
public static string SnackFileExists { get { return CurrentLocalization.BaseSnackFileExists; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodano do playlisty
/// </summary>
public static string SnackPlaylist { get { return CurrentLocalization.BaseSnackPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodano do kolejki
/// </summary>
public static string SnackQueue { get { return CurrentLocalization.BaseSnackQueue; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do wysłania
/// </summary>
public static string SyncAdd { get { return CurrentLocalization.BaseSyncAdd; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do wysłania (playlista)
/// </summary>
public static string SyncAddPlaylist { get { return CurrentLocalization.BaseSyncAddPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 1. Podłącz urządzenia do tej samej sieci
/// </summary>
public static string SyncHelp1 { get { return CurrentLocalization.BaseSyncHelp1; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 2. Wpisz kod lub poczekaj na połączenie
/// </summary>
public static string SyncHelp2 { get { return CurrentLocalization.BaseSyncHelp2; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 2. Wpisz kod
/// </summary>
public static string SyncHelp2Desktop { get { return CurrentLocalization.BaseSyncHelp2Desktop; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu 3. Wybierz odpowiednią opcję
/// </summary>
public static string SyncHelp3 { get { return CurrentLocalization.BaseSyncHelp3; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Synchronizacja z telefonem
/// </summary>
public static string SyncPhone { get { return CurrentLocalization.BaseSyncPhone; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Odbieranie plików
/// </summary>
public static string SyncReceiving { get { return CurrentLocalization.BaseSyncReceiving; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wysyłanie plików
/// </summary>
public static string SyncSending { get { return CurrentLocalization.BaseSyncSending; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pokaż pliki do wysłania
/// </summary>
public static string SyncShowFiles { get { return CurrentLocalization.BaseSyncShowFiles; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Ciemny
/// </summary>
public static string ThemeDark { get { return CurrentLocalization.BaseThemeDark; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Domyślny
/// </summary>
public static string ThemeDefault { get { return CurrentLocalization.BaseThemeDefault; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Różowy
/// </summary>
public static string ThemeLight { get { return CurrentLocalization.BaseThemeLight; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Tytuł
/// </summary>
public static string Title { get { return CurrentLocalization.BaseTitle; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Pobieranie
/// </summary>
public static string TitleDownloads { get { return CurrentLocalization.BaseTitleDownloads; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utwór
/// </summary>
public static string Track { get { return CurrentLocalization.BaseTrack; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Zapisanych utworów
/// </summary>
public static string TrackCount { get { return CurrentLocalization.BaseTrackCount; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utworów
/// </summary>
public static string TrackCountPlaylist { get { return CurrentLocalization.BaseTrackCountPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Usuń
/// </summary>
public static string TrackMenuDelete { get { return CurrentLocalization.BaseTrackMenuDelete; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Edytuj
/// </summary>
public static string TrackMenuEdit { get { return CurrentLocalization.BaseTrackMenuEdit; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do playlisty
/// </summary>
public static string TrackMenuPlaylist { get { return CurrentLocalization.BaseTrackMenuPlaylist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Dodaj do kolejki
/// </summary>
public static string TrackMenuQueue { get { return CurrentLocalization.BaseTrackMenuQueue; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Utwory
/// </summary>
public static string Tracks { get { return CurrentLocalization.BaseTracks; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Nieznany wykonawca
/// </summary>
public static string UnknownArtist { get { return CurrentLocalization.BaseUnknownArtist; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wypakowano
/// </summary>
public static string Unpacked { get { return CurrentLocalization.BaseUnpacked; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Uwaga
/// </summary>
public static string Warning { get { return CurrentLocalization.BaseWarning; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Tak
/// </summary>
public static string Yes { get { return CurrentLocalization.BaseYes; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Twój kod
/// </summary>
public static string YourCode { get { return CurrentLocalization.BaseYourCode; } }
/// <summary>
/// Wyszukuje zlokalizowany ciąg podobny do ciągu Wystąpił błąd spowodowany zmianami w serwisie YouTube. Proszę czekać na aktualizację uwzględniający podane zmiany.
/// </summary>
public static string YoutubeError { get { return CurrentLocalization.BaseYoutubeError; } }

public abstract class LocalizationBase{
public string BaseAboutAuthor { get; }
public string BaseAboutDesc { get; }
public string BaseAboutWWW { get; }
public string BaseAdd { get; }
public string BaseAddTags { get; }
public string BaseArtist { get; }
public string BaseArtists { get; }
public string BaseAutoConvert { get; }
public string BaseAutoDownload { get; }
public string BaseBackPressed { get; }
public string BaseCancel { get; }
public string BaseChangeName { get; }
public string BaseChoosePlaylist { get; }
public string BaseClear { get; }
public string BaseConnect { get; }
public string BaseConversion { get; }
public string BaseConversionInputFiles { get; }
public string BaseConversionOutputFolder { get; }
public string BaseConversionOutputFormat { get; }
public string BaseConvert { get; }
public string BaseCover { get; }
public string BaseCoverLoad { get; }
public string BaseCoverSave { get; }
public string BaseDisconnect { get; }
public string BaseFileCorrupted { get; }
public string BaseFileDownloaded { get; }
public string BaseFolderExists { get; }
public string BaseInformations { get; }
public string BaseInstruction { get; }
public string BaseLanguageEN { get; }
public string BaseLanguagePL { get; }
public string BaseLanguageRU { get; }
public string BaseLastViews { get; }
public string BaseLibrary { get; }
public string BaseMainPage { get; }
public string BaseMostViews { get; }
public string BaseNewPlaylist { get; }
public string BaseNewPlaylistHint { get; }
public string BaseNext { get; }
public string BaseNo { get; }
public string BaseNoConnection { get; }
public string BaseNoDownloads { get; }
public string BasePermissionGrant { get; }
public string BasePermissionInfo { get; }
public string BasePlaylist { get; }
public string BasePlaylistDownload { get; }
public string BasePlaylistExists { get; }
public string BasePlaylistOrTrack { get; }
public string BasePlaylistPlay { get; }
public string BasePlaylists { get; }
public string BaseProgress { get; }
public string BaseQuestion { get; }
public string BaseQuestionDelete { get; }
public string BaseQuestionDeleteFromPlaylist { get; }
public string BaseQuestionDeletePlaylist { get; }
public string BaseQuestionDeletePlaylistg { get; }
public string BaseReady { get; }
public string BaseReceive { get; }
public string BaseReceiverCode { get; }
public string BaseReplaceWithExists { get; }
public string BaseSave { get; }
public string BaseSearch { get; }
public string BaseSearchHistory { get; }
public string BaseSearching { get; }
public string BaseSearchTip { get; }
public string BaseSelect { get; }
public string BaseSelectFolder { get; }
public string BaseSend { get; }
public string BaseSettings { get; }
public string BaseSettings0 { get; }
public string BaseSettings1 { get; }
public string BaseSettings2 { get; }
public string BaseSettings3 { get; }
public string BaseSettings4 { get; }
public string BaseSettings5 { get; }
public string BaseSettingsChanges { get; }
public string BaseSnackDelete { get; }
public string BaseSnackFileExists { get; }
public string BaseSnackPlaylist { get; }
public string BaseSnackQueue { get; }
public string BaseSyncAdd { get; }
public string BaseSyncAddPlaylist { get; }
public string BaseSyncHelp1 { get; }
public string BaseSyncHelp2 { get; }
public string BaseSyncHelp2Desktop { get; }
public string BaseSyncHelp3 { get; }
public string BaseSyncPhone { get; }
public string BaseSyncReceiving { get; }
public string BaseSyncSending { get; }
public string BaseSyncShowFiles { get; }
public string BaseThemeDark { get; }
public string BaseThemeDefault { get; }
public string BaseThemeLight { get; }
public string BaseTitle { get; }
public string BaseTitleDownloads { get; }
public string BaseTrack { get; }
public string BaseTrackCount { get; }
public string BaseTrackCountPlaylist { get; }
public string BaseTrackMenuDelete { get; }
public string BaseTrackMenuEdit { get; }
public string BaseTrackMenuPlaylist { get; }
public string BaseTrackMenuQueue { get; }
public string BaseTracks { get; }
public string BaseUnknownArtist { get; }
public string BaseUnpacked { get; }
public string BaseWarning { get; }
public string BaseYes { get; }
public string BaseYourCode { get; }
public string BaseYoutubeError { get; }
}
    }
}
