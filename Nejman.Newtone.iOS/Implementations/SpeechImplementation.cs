using AVFoundation;
using Foundation;
using Nejman.Newtone.Mobile;
using Nejman.Newtone.Mobile.Contracts;
using Nejman.Newtone.Mobile.ViewModels;
using Nejman.Newtone.Mobile.Views;
using Speech;
using System.Threading.Tasks;

namespace Nejman.Newtone.iOS.Implementations
{
    public class SpeechImplementation : ISpeech
    {
        private readonly AVAudioEngine engine;
        private readonly SFSpeechRecognizer speech;
        private SFSpeechAudioBufferRecognitionRequest request;
        private SFSpeechRecognitionTask task;
        private string resultString;
        private NSTimer timer;

        public SpeechImplementation()
        {
            engine = new AVAudioEngine();
            speech = new SFSpeechRecognizer();
        }
        public void Initialize()
        {
            //Nothing happens
        }

        public void OpenSearchPage(string search)
        {
            ShellHelpers.GoTo($"{nameof(SearchPage)}?{nameof(SearchViewModel.SearchQuery)}={search}");
        }

        public void StartSpeech()
        {
            if(!SpeechPermission())
            {
                return;
            }

            if(engine.Running)
            {
                Stop();
            }

            Start();
        }

        private bool SpeechPermission()
        {
            bool authorized = false;
            SFSpeechRecognizer.RequestAuthorization(status =>
            {
                authorized = status == SFSpeechRecognizerAuthorizationStatus.Authorized;
            });

            return authorized;
        }

        private void Stop()
        {
            if(engine.Running)
            {
                engine.Stop();
                engine.InputNode.RemoveTapOnBus(0);
                task?.Cancel();
                request.EndAudio();
                request = null;
                task = null;
            }
        }

        private void Start()
        {
            timer = NSTimer.CreateRepeatingScheduledTimer(5, timer1 =>
            {
                if (timer != null)
                {
                    timer.Invalidate();
                    timer = null;
                }

                if (engine.Running)
                {
                    Stop();
                }
            });

            task?.Cancel();
            task = null;

            var session = AVAudioSession.SharedInstance();
            NSError error = session.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            session.SetMode(AVAudioSession.ModeDefault, out error);
            error = session.SetActive(true, AVAudioSessionSetActiveOptions.NotifyOthersOnDeactivation);
            session.OverrideOutputAudioPort(AVAudioSessionPortOverride.Speaker, out error);
            request = new SFSpeechAudioBufferRecognitionRequest();

            var input = engine.InputNode;

            if(input == null)
            {
                return;
            }

            var format = input.GetBusOutputFormat(0);
            input.InstallTapOnBus(0, 1024, format, (buffer, when) =>
            {
                request?.Append(buffer);
            });

            engine.Prepare();
            engine.StartAndReturnError(out error);

            task = speech.GetRecognitionTask(request, (result, taskError) =>
            {
                if(result != null)
                {
                    resultString = result.BestTranscription.FormattedString;
                    Task.Run(async () => await Mobile.Implementations.SpeechImplementation.Process(resultString));
                    timer.Invalidate();
                    timer = null;
                    timer = NSTimer.CreateRepeatingScheduledTimer(5, timer1 =>
                    {
                        if (timer != null)
                        {
                            timer.Invalidate();
                            timer = null;
                        }

                        if (engine.Running)
                        {
                            Stop();
                        }
                    });
                }

                if(taskError != null)
                {
                    Stop();
                }
            });
        }
    }
}