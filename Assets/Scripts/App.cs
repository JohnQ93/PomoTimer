using System;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using System.Diagnostics;

namespace PomoTimerApp
{
    public class App : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new TimerPage();
        }
    }

    public class TimerPage : StatefulWidget
    {
        public override State createState()
        {
            return new TimerPageState();
        }
    }

    class TimerPageState : State<TimerPage>
    {
        public readonly static TimeSpan DELAY = TimeSpan.FromMilliseconds(100);

        private string mTimeText = "25:00";

        public override void initState()
        {
            base.initState();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var timer = Window.instance.periodic(DELAY, () =>
            {
                UnityEngine.Debug.LogFormat("DELAYED:{0}", stopwatch.Elapsed.TotalSeconds);
                setState(() =>
                {
                    mTimeText = string.Format("{0}:{1}", 24 - stopwatch.Elapsed.Minutes, 59 - stopwatch.Elapsed.Seconds);
                });
            });
        }

        public override Widget build(BuildContext context)
        {
            return new Text(data: mTimeText, style: new TextStyle(
                color: Colors.white,
                fontSize: 50
            ));
        }
    }
}