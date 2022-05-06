using System;
using AppKit;
using Foundation;


namespace FzzzBzzz
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        // Make declarations

        NSSpeechSynthesizer synth = new NSSpeechSynthesizer();

        public int countfrom;
        public int countto;
        public bool doneCheck = false;
        bool pressed = false;


        public void Fizzer()
        {
            string x;
           
            if (countfrom <= countto)
            {
                if (countfrom % 3 == 0)
                {
                    x = "FIZZ";
                }
                else if (countfrom % 5 == 0)
                {
                    x = "BUZZ";
                }
                else
                {
                    x = countfrom.ToString();
                }

                outField.StringValue = x;
                synth.StartSpeakingString(x);

                countfrom++;
            }
            else
            {
                outField.StringValue = "Done!";
                doneCheck = true;
                pressed = false;
                buttonDisplay.Title = "GO";
                return;
            }
            
        }

        public void Timer()
        {
            // In a just world I wouldn't have to use these NS functions and could access glorious .NET resources
            var timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(1.0), delegate { Fizzer(); });

            timer.Fire();

            if (doneCheck == true)
            {
                timer.Invalidate();
                timer.Dispose();
                timer = null;
            }
        }


        partial void pushButton(AppKit.NSButton sender)
        {
            bool numcheck = int.TryParse(inField.StringValue, out int number);

            countto = number;
            countfrom = 1;

            if (pressed == true)
            {
                inField.StringValue = "";
                inField.PlaceholderString = "New Number?";
            }
            else if (numcheck == false)
            {
                outField.StringValue = "Want Number!";
            }
            else if (numcheck == true)
            {
                inField.StringValue = "";
                inField.PlaceholderString = "Counting";
                buttonDisplay.Title = "STOP";

                Timer();
                pressed = true;
            }

        }

    }

}
