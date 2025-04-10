using System.Drawing;
using TradingPlatform.BusinessLayer;

namespace HelloWorldIndicator
{
    public class HelloWorldIndicator : Indicator
    {
        private Indicator _ema;

        public HelloWorldIndicator()
        {
            Name = "My Indicator";
            Description = "Hello World Indicator"; 
            SeparateWindow = true;
            _ema = null;

            AddLineSeries("EMA5 50", Color.Magenta);
        }

        public override string ShortName => "HWI";

        protected override void OnInit()
        {
            base.OnInit();
            
            AddIndicator(_ema = Core.Indicators.BuiltIn.EMA(50, PriceType.Close));
        }

        protected override void OnUpdate(UpdateArgs args)
        {
            base.OnUpdate(args);
            
            SetValue(_ema.GetValue());
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _ema?.Dispose();
            _ema = null;
        }
    }
}