using System;

/******************************题目****************************
2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和
响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。
**************************************************************/

namespace 闹钟
{
    public class Clock
    {

        public int Hour { get; set; }       //当前时
        public int Minute { get; set; }     //当前分
        public int Second { get; set; }     //当前秒
        public bool IfAlarm { get; set; }     //是否设定响铃时间
        public int AlarmHour { get; set; }      //响铃时
        public int AlarmMinute { get; set; }        //响铃分
        public int AlarmSecond { get; set; }        //响铃秒

        public delegate void TickHandler();
        public event TickHandler OnTick;
        public event TickHandler OnAlarm;

        public void Tick()
        {
            OnTick();
        }
        public void Alarm()
        {
            if (AlarmHour == Hour && AlarmMinute == Minute && AlarmSecond == Second)
                OnAlarm();
        }

        public void Update()
        {
            Second++;
            if(Second==60)
            {
                Second = 0;
                Minute++;
                if(Minute==60)
                {
                    Minute = 0;
                    Hour++;
                    if(Hour==24)
                    {
                        Hour = 0;
                    }
                }
            }
        }
    }

    class Program
    {
        static Clock clock = new Clock();
        static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            clock.Tick();
            clock.Alarm();
            clock.Update();
        }
        static void Main(string[] args)
        {
            clock.OnTick += Tick;
            clock.OnAlarm += Alarm;
            void Tick()
            {
                Console.WriteLine($"Ring……当前时间：{clock.Hour}:{clock.Minute}:{clock.Second}");
            }
            void Alarm()
            {
                Console.WriteLine($"Alarm……当前时间：{clock.Hour}:{clock.Minute}:{clock.Second}");
            }

            clock.Hour = 23;
            clock.Minute = 58;
            clock.Second = 0;
            clock.AlarmHour = 23;
            clock.AlarmMinute = 59;
            clock.AlarmSecond = 58;

            System.Timers.Timer timer;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            Console.ReadLine();
        }
    }
}
