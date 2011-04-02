using BuildMonitorMicro.TestHarness.Properties;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace BuildMonitorMicro.TestHarness
{
    public class ConsoleWindow : Window
    {
        private readonly Font _small = Resources.GetFont(Resources.FontResources.Small);
        private readonly Font _arial14 = Resources.GetFont(Resources.FontResources.Arial14);

        private readonly TextFlow _log;
        private readonly Text _timeText;
        private readonly Brush _solidBlack = new SolidColorBrush(Color.Black);

        public ConsoleWindow(string windowTitle)
        {
            var panel = new StackPanel();

            _timeText = new Text(_arial14, windowTitle)
                            {
                                TextAlignment = TextAlignment.Right,
                                VerticalAlignment = VerticalAlignment.Top,
                                ForeColor = ColorUtility.ColorFromRGB(255, 255, 0)
                            };

            panel.Children.Add(_timeText);

            var scroll = new ScrollViewer
                             {
                                 Height = SystemMetrics.ScreenHeight - _arial14.Height,
                                 Width = SystemMetrics.ScreenWidth,
                                 ScrollingStyle = ScrollingStyle.Last,
                                 Background = null,
                                 LineHeight = _small.Height
                             };

            panel.Children.Add(scroll);

            _log = new TextFlow
                       {
                           HorizontalAlignment = HorizontalAlignment.Left,
                           VerticalAlignment = VerticalAlignment.Top
                       };

            scroll.Child = _log;

            Background = _solidBlack;
            Child = panel;
        }

        public void WriteLine(string s)
        {
            Dispatcher.BeginInvoke(InvokedWriteLine, s);
        }

        private object InvokedWriteLine(object arg)
        {
            var message = (string)arg;

            _log.TextRuns.Add(new TextRun(message, _small, Color.White));
            _log.TextRuns.Add(TextRun.EndOfLine);
            ((ScrollViewer)_log.Parent).LineDown();

            return null;
        }

        protected virtual void OnStart() { }
    }
}